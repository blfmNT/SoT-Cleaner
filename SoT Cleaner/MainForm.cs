using System.ComponentModel;
using System.Diagnostics;
using System.Management;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.ServiceProcess;
using static HWID_Changer.WinAPI;
using static HWID_Changer.Utils;

namespace HWID_Changer
{
    public struct service
    {
        public string Name;
        public bool wasRunning;

        public service(string Name)
        {
            this.Name = Name;
            wasRunning = false;
        }
    }

    public struct VSNData
    {
        public string volume;
        public string serialNumber = "FFFF-FFFF";

        public VSNData(string volume, string serialNumber)
        {
            this.volume = volume;
            this.serialNumber = serialNumber;
        }
    }

    public struct HWIDProfileData
    {
        public List<VSNData> driversData;
        public string CS = "FFFFFF";
        public string BS = "FFFFFFFF";
        public string SS = "FFFFFFFF";
        public string PSN = "FFFFFFFFFFFFFF";

        public HWIDProfileData()
        {
            driversData = new List<VSNData>();
        }

        public void Clear()
        {
            CS = "FFFFFF";
            BS = "FFFFFFFF";
            SS = "FFFFFFFF";
            PSN = "FFFFFFFFFFFFFF";
            driversData.Clear();
        }
    }


    public partial class MainForm : Form
    {
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string RandomHEXString(int length)
        {
            const string chars = "ABCDEF0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private  string validateVSN(string serial)
        {
            return serial.Replace('-','F').Remove(4,1).Insert(4, "-");
        }

        private void updateProfilesList(bool afterDelete = false)
        {
            if (afterDelete)
            {
                profilesBox.Items.Remove(profilesBox.SelectedItem.ToString());
                profilesBox.SelectedIndex = 0;
            }
            else
            {
                profilesBox.Items.Clear();

                //init profiles
                if (!Directory.Exists(profilesDir))
                    Directory.CreateDirectory(profilesDir);


                var profiles = Directory.EnumerateFiles(profilesDir);

                if (profiles.Count() > 0)
                {

                    foreach (var fileName in profiles)
                    {
                        string profileName = fileName.Split("\\").Last();
                        profilesBox.Items.Add(profileName);
                    }

                }
                profilesBox.Items.Add("New profile");
            }

        }

        private HWIDProfileData parseProfileFile(string fileName)
        {
            HWIDProfileData retData = new HWIDProfileData();

            using (StreamReader sr = File.OpenText(fileName))
            {
                string s;

                while ((s = sr.ReadLine()) != null)
                {
                    string[] parts = s.Split("=");

                    //1 symbol for disks
                    if (parts[0].Length == 1)
                    {
                        retData.driversData.Add(new VSNData(parts[0], parts[1]));
                    }

                    //motherboard stuff
                    else if (parts[0] == "CS")
                    {
                        retData.CS = parts[1];
                    }
                    else if (parts[0] == "BS")
                    {
                        retData.BS = parts[1];
                    }
                    else if (parts[0] == "SS")
                    {
                        retData.SS = parts[1];
                    }
                    else if (parts[0] == "PSN")
                    {
                        retData.PSN = parts[1];
                    }

                }
            }

            return retData;
        }

        public bool saveProfileFile(HWIDProfileData data, string fileName)
        {
            using (StreamWriter sw = File.CreateText(fileName))
            {
                try
                {
                    foreach (VSNData vsnd in data.driversData)
                    {
                        sw.WriteLine(vsnd.volume + "=" + vsnd.serialNumber);
                    }

                    sw.WriteLine("CS=" + data.CS);
                    sw.WriteLine("BS=" + data.BS);
                    sw.WriteLine("SS=" + data.SS);
                    sw.WriteLine("PSN=" + data.PSN);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }

        private void systemRestart()
        {
            ManagementBaseObject mboShutdown = null;
            ManagementClass mcWin32 = new ManagementClass("Win32_OperatingSystem");
            mcWin32.Get();

            // You can't shutdown without security privileges
            mcWin32.Scope.Options.EnablePrivileges = true;
            ManagementBaseObject mboShutdownParams =
                     mcWin32.GetMethodParameters("Win32Shutdown");

            // Flag 1 means we want to shut down the system. Use "2" to reboot.
            mboShutdownParams["Flags"] = "2";
            mboShutdownParams["Reserved"] = "0";
            foreach (ManagementObject manObj in mcWin32.GetInstances())
            {
                mboShutdown = manObj.InvokeMethod("Win32Shutdown",
                                               mboShutdownParams, null);
            }

        }

        void setStatus(string status)
        {
            statusLabel1.Text = "Status: " + status;
        }

        //bool deleteRegKeyTree(string rootKey, string key)
        //{
        //    RegistryKey registryKey;
        //    switch(rootKey)
        //    {
        //        case ""
        //    }

        //}

        //global variables
        static string appDir = System.AppContext.BaseDirectory;
        static string profilesDir = appDir + "profiles";
        static HWIDProfileData mainProfileData = new HWIDProfileData();
        public const string HexLetters = "0123456789ABCDEF\b"; // \b is the BackSpace character


        public MainForm()
        {
            InitializeComponent();

            updateProfilesList();

            //retrieve list of disks
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            if (allDrives.Count() > 0)
            {
                foreach (DriveInfo driveInfo in allDrives)
                {
                    if (driveInfo.DriveType != DriveType.Fixed)
                        continue;

                    driveNameBox.Items.Add(driveInfo.Name.ToString());
                }
                driveNameBox.SelectedIndex = 0;
            }
        }

        private void VSNboxRnd_Click(object sender, EventArgs e)
        {
            if (driveNameBox.SelectedIndex == -1)
            {
                MessageBox.Show("Drive is not selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string vsnR = RandomHEXString(8);
            vsnR = vsnR.Insert(4, "-");
            VSNtextBox.Text = vsnR;

        }

        private void profilesBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedProfile = profilesBox.Text;

            mainProfileData.Clear();

            if (selectedProfile != "New profile")
            {
                string profilePath = profilesDir + "\\" + selectedProfile;
                deleteProfilebtn.Enabled = true;

                if (File.Exists(profilePath))
                {
                    mainProfileData = parseProfileFile(profilePath);

                    if (mainProfileData.driversData.Count > 0)
                        for (int i = 0; i < mainProfileData.driversData.Count(); i++)
                        {
                            string driveName = (string)driveNameBox.SelectedItem;
                            if (driveName == mainProfileData.driversData[i].volume + ":\\")
                            {
                                VSNtextBox.Text = mainProfileData.driversData[i].serialNumber;
                                break;
                            }
                        }
                    else
                        VSNtextBox.Text = "FFFF-FFFF";
                }
            }
            else
            {
                VSNtextBox.Text = "FFFF-FFFF";
                deleteProfilebtn.Enabled = false;
            }

            CStextBox.Text = mainProfileData.CS;
            BStextBox.Text = mainProfileData.BS;
            PSNtextBox.Text = mainProfileData.PSN;
            SStextBox.Text = mainProfileData.SS;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            string pName = profilesBox.Text;

            if (pName == "New profile")
            {
                MessageBox.Show("Enter valid name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                profilesBox.Focus();
                return;
            }
            string profileName = profilesDir + "\\" + pName;

            if (saveProfileFile(mainProfileData, profileName))
            {
                MessageBox.Show("Profile has been saved", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                deleteProfilebtn.Enabled = true;
            }
            else
            {
                MessageBox.Show("Profile has not been saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            updateProfilesList();
        }

        private void driveNameBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string drive = (string)driveNameBox.SelectedItem;
            drive = drive.Substring(0, 1);
            VSNtextBox.Clear();

            for (int i = 0; i < mainProfileData.driversData.Count; i++)
            {
                if (mainProfileData.driversData[i].volume == drive)
                {
                    VSNtextBox.Text = mainProfileData.driversData[i].serialNumber;
                }
            }

            if (VSNtextBox.Text == "")
                VSNtextBox.Text = "FFFF-FFFF";
        }

        private void CSbtnRnd_Click(object sender, EventArgs e)
        {
            CStextBox.Text = RandomHEXString(6);
        }

        private void BSbtnRnd_Click(object sender, EventArgs e)
        {
            BStextBox.Text = RandomHEXString(8);
        }

        private void PSNbtnRnd_Click(object sender, EventArgs e)
        {
            PSNtextBox.Text = RandomHEXString(14);
        }

        private void SSbtnRnd_Click(object sender, EventArgs e)
        {
            SStextBox.Text = RandomHEXString(8);
        }

        private void VSNtextBox_TextChanged(object sender, EventArgs e)
        {

            if (VSNtextBox.Text == "")
                return;

            VSNtextBox.Text = validateVSN(VSNtextBox.Text);

            string drive = (string)driveNameBox.SelectedItem;
            drive = drive.Substring(0, 1);
            bool found = false;
            VSNData tmpVSNData;

            if (mainProfileData.driversData.Count > 0)
            {
                for (int i = 0; i < mainProfileData.driversData.Count; i++)
                {
                    if (mainProfileData.driversData[i].volume == drive)
                    {
                        found = true;
                        tmpVSNData = mainProfileData.driversData[i];
                        tmpVSNData.serialNumber = VSNtextBox.Text;

                        mainProfileData.driversData[i] = tmpVSNData;
                    }
                }

                if (!found)
                    mainProfileData.driversData.Add(new VSNData(drive, VSNtextBox.Text));

            }
            else
                mainProfileData.driversData.Add(new VSNData(drive, VSNtextBox.Text));

        }

        private void CStextBox_TextChanged(object sender, EventArgs e)
        {
            if (CStextBox.Text != "")
                mainProfileData.CS = CStextBox.Text;
            else
                mainProfileData.CS = "FFFFFF";
        }

        private void BStextBox_TextChanged(object sender, EventArgs e)
        {
            if (BStextBox.Text != "")
                mainProfileData.BS = BStextBox.Text;
            else
                mainProfileData.BS = "FFFFFFFF";
        }

        private void PSNtextBox_TextChanged(object sender, EventArgs e)
        {
            if (PSNtextBox.Text != "")
                mainProfileData.PSN = PSNtextBox.Text;
            else
                mainProfileData.PSN = "FFFFFFFFFFFFFF";
        }

        private void SStextBox_TextChanged(object sender, EventArgs e)
        {
            if (SStextBox.Text != "")
                mainProfileData.SS = SStextBox.Text;
            else
                mainProfileData.SS = "FFFFFFFF";
        }

        private void deleteProfilebtn_Click(object sender, EventArgs e)
        {
            string selectedProfile = profilesBox.Text;
            string profilePath = profilesDir + "\\" + selectedProfile;

            if (profilesBox.SelectedIndex > -1 && selectedProfile != "New profile")
            {
                DialogResult dlgResult = MessageBox.Show("You really want to delete " + selectedProfile, "Profile delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dlgResult == DialogResult.Yes)
                {
                    if (File.Exists(profilePath))
                    {
                        try
                        {
                            File.Delete(profilePath);
                            updateProfilesList(true);

                            MessageBox.Show("Sucessfully deleted " + selectedProfile, "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch(IOException ex)
                        {
                            MessageBox.Show("Unable to delete profile " + selectedProfile, ex.Message,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
            }
        }

        private void allRandombtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < driveNameBox.Items.Count; i++)
            {
                driveNameBox.SelectedIndex = i;
                VSNboxRnd.PerformClick();
            }
            CSbtnRnd.PerformClick();
            BSbtnRnd.PerformClick();
            PSNbtnRnd.PerformClick();
            SSbtnRnd.PerformClick();

        }


        private void btnApplyProfile_Click(object sender, EventArgs e)
        {
            if (!File.Exists("volumeid.exe") || !File.Exists("volumeid64.exe"))
            {
                MessageBox.Show("Volumeid or Volumeid64 is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            setStatus("Start applying");

            driveNameBox.Enabled = !driveNameBox.Enabled;
            VSNtextBox.Enabled = !VSNtextBox.Enabled;
            CStextBox.Enabled = !CStextBox.Enabled;
            BStextBox.Enabled = !BStextBox.Enabled;
            PSNtextBox.Enabled = !PSNtextBox.Enabled;
            SStextBox.Enabled = !SStextBox.Enabled;


            Process volume = new Process();
            volume.StartInfo.FileName = "volumeid.exe";
            volume.StartInfo.UseShellExecute = false;
            volume.StartInfo.CreateNoWindow = true;

            foreach (VSNData vsnd in mainProfileData.driversData)
            {
                volume.StartInfo.Arguments = vsnd.volume + ": " + vsnd.serialNumber;
                volume.Start();
                volume.WaitForExit();
            }


            Process ami = new Process();
            ami.StartInfo.FileName = "AMIDEWINx64.exe";
            ami.StartInfo.UseShellExecute = false;
            ami.StartInfo.CreateNoWindow = true;

            ami.StartInfo.Arguments = "/CS " + mainProfileData.CS;
            ami.Start();
            ami.WaitForExit();

            ami.StartInfo.Arguments = "/BS " + mainProfileData.BS;
            ami.Start();
            ami.WaitForExit();
            ami.StartInfo.Arguments = "/PSN " + mainProfileData.PSN;
            ami.Start();
            ami.WaitForExit();
            ami.StartInfo.Arguments = "/SS " + mainProfileData.SS;
            ami.Start();
            ami.WaitForExit();

            ami.StartInfo.Arguments = "/SU AUTO";
            ami.Start();
            ami.WaitForExit();

            if (restartCB.Checked)
                systemRestart();
            else
                MessageBox.Show("All changes will applied after system reboot", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            driveNameBox.Enabled = !driveNameBox.Enabled;
            VSNtextBox.Enabled = !VSNtextBox.Enabled;
            CStextBox.Enabled = !CStextBox.Enabled;
            BStextBox.Enabled = !BStextBox.Enabled;
            PSNtextBox.Enabled = !PSNtextBox.Enabled;
            SStextBox.Enabled = !SStextBox.Enabled;

            setStatus("HWIDS have been changed, restart the system");

        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuExit_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            setStatus("Idle");
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void registryCleanBtn_Click(object sender, EventArgs e)
        {
            setStatus("start registry cleaner");
            this.Enabled = false;

            string regKeysFileName = appDir + "regkeys.txt";
            SoTCleaner.CleanRegistry(regKeysFileName);

            registryCleanBtn.Enabled = true;
            setStatus("registry cleared");
            this.Enabled = true;
            System.Media.SystemSounds.Beep.Play();
        }

        private void credentialsCleanBtn_Click(object sender, EventArgs e)
        {
            setStatus("start credentials cleaner");
            credentialsCleanBtn.Enabled = false;
            this.Enabled = false;

            string UserName = Environment.UserName;

            try
            {
                foreach (var credential in CredentialManager.EnumerateCrendentials())
                {
                    CredentialManager.DeleteCredential(credential.ApplicationName, credential.CredentialType, 0);
                }
            }
            catch (Exception)
            { 
                //idc
            }

            RunAsDesktopUser(Environment.CurrentDirectory +  "\\ul-credentialsremoval.bat");

            credentialsCleanBtn.Enabled = true;
            setStatus("credentials cleared");
            this.Enabled = true;
            System.Media.SystemSounds.Beep.Play();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            service[] services = new service[] {
                new service("XblAuthManager"),
                new service ("GamingServices"),
                new service ("GamingServicesNet")
            };
            

            for (int i = 0; i < services.Length; i++)
            {
                ServiceController serviceController = new ServiceController();
                serviceController.ServiceName = services[i].Name;

                if (serviceController.Status == ServiceControllerStatus.Running)
                {
                    services[i].wasRunning = true;
                    try
                    {
                        setStatus("Stopping " + services[i].Name);
                        serviceController.Stop();
                        serviceController.WaitForStatus(ServiceControllerStatus.Stopped);
                    }
                    catch (InvalidOperationException)
                    {
                        setStatus("Couldn't stop the service " + services[i].Name);
                    }

                }
                this.Enabled = true;
            }

            string cacheFile = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Microsoft\\XboxLive\\AuthStateCache.dat";
            if (File.Exists(cacheFile))
                File.Delete(cacheFile);

            System.Media.SystemSounds.Beep.Play();
            setStatus("XBOX Auth cache file removed");

            string NSALcachePath = "C:\\ProgramData\\Microsoft\\XboxLive";
            if (Directory.Exists(NSALcachePath))
                Directory.Delete(NSALcachePath, true);

        }

        private void loadCurrentIDS_Click(object sender, EventArgs e)
        {
            setStatus("Loading current known HWIDS");

            Process vol = new Process();
            vol.StartInfo.UseShellExecute = false;
            vol.StartInfo.CreateNoWindow = true;
            vol.StartInfo.FileName = "cmd";
            vol.StartInfo.RedirectStandardOutput = true;
            vol.StartInfo.RedirectStandardInput = true;


            for (int i=0; i<driveNameBox.Items.Count; i++)
            {
                driveNameBox.SelectedIndex = i;

                string driveL = driveNameBox.Items[i].ToString();
                driveL = driveL.Substring(0, driveL.Length - 1);
                vol.Start();

                StreamWriter streamWriter = vol.StandardInput;

                streamWriter.WriteLine("vol " + driveL);
                streamWriter.Close(); 
                vol.WaitForExit();

                string output = vol.StandardOutput.ReadToEnd();
                if (output != null)
                {
                    output = output.Substring(output.IndexOf("Volume Serial Number is ") + 24);
                    output = output.Substring(0, 9);
                    VSNtextBox.Text = output;
                }

            }

            Process scStop = new Process();
            scStop.StartInfo.FileName = "sc";
            scStop.StartInfo.CreateNoWindow = true;
            scStop.StartInfo.UseShellExecute = false;
            scStop.StartInfo.Arguments = "stop amifldrv64";
            scStop.Start();
            scStop.WaitForExit();

            Process ami = new Process();
            ami.StartInfo.FileName = "AMIDEWINx64.exe";
            ami.StartInfo.CreateNoWindow = true;
            ami.StartInfo.UseShellExecute = false;
            ami.StartInfo.Arguments = "/ALL all.txt";
            ami.Start();
            ami.WaitForExit();

            string splitStr = "\"";

            foreach (string line in File.ReadLines("all.txt"))
            {
                string valueSub = line.Substring(line.IndexOf(splitStr) + splitStr.Length);
                valueSub = valueSub.Substring(0, valueSub.Length - 1);

                if (line.Contains("(/SS)System Serial number"))
                    SStextBox.Text = valueSub;
                if (line.Contains("(/BS)Baseboard Serial number"))
                    BStextBox.Text = valueSub;
                if (line.Contains("(/CS)Chassis Serial number"))
                    CStextBox.Text = valueSub;
                if (line.Contains("(/PSN)Processor Serial Num."))
                    PSNtextBox.Text = valueSub;
            }

            File.Delete("all.txt");

            setStatus("Known HWIDS loaded");

        }

        private void driveNameBox_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void VSNtextBox_KeyDown(object sender, KeyEventArgs e)
        {
            

        }

        private void VSNtextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //char[] allowedChars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

            //foreach (char character in VSNtextBox.Text.ToUpper().ToArray())
            //{
            //    if (!allowedChars.Contains(character))
            //    {
            //        System.Windows.Forms.MessageBox.Show(string.Format("'{0}' is not a hexadecimal character", character));
            //        e.Cancel = true;
            //    }
            //}
        }

        private void VSNtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            string allowedLetters = "-0123456789abcdefABCDEF\b"; // \b is the BackSpace character

            if (!allowedLetters.Contains(e.KeyChar))
                e.Handled = true;

        }

        private void BStextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!HexLetters.Contains(e.KeyChar)) e.Handled = true;

        }

        private void BStextBox_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void CStextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!HexLetters.Contains(e.KeyChar)) e.Handled = true;
        }

        private void CStextBox_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void PSNtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!HexLetters.Contains(e.KeyChar)) e.Handled = true;
        }

        private void SStextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!HexLetters.Contains(e.KeyChar)) e.Handled = true;
        }
    }
}

