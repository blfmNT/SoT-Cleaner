using Microsoft.VisualBasic.Devices;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace HWID_Changer
{
    internal class SoTCleaner
    {
        private static void DeleteRegKey(string path)
        {
            string type = path.Split('\\')[0];
            string sub_path = path.Replace(type + "\\", "");

            switch (type)
            {
                case "HKEY_CURRENT_USER":
                    if (Registry.CurrentUser.OpenSubKey(sub_path) != null)
                        Registry.CurrentUser.DeleteSubKeyTree(sub_path);
                    break;

                case "HKEY_LOCAL_MACHINE":
                    if (Registry.LocalMachine.OpenSubKey(sub_path) != null)
                        Registry.LocalMachine.DeleteSubKeyTree(sub_path);
                    break;

                case "HKEY_USERS":
                    if (Registry.Users.OpenSubKey(sub_path) != null)
                        Registry.Users.DeleteSubKeyTree(sub_path);
                    break;
            }
        }

        private static void DeleteRegValue(string path, string value)
        {
            string type = path.Split('\\')[0];
            string sub_path = path.Replace(type + "\\", "");

            MessageBox.Show(sub_path);

            switch (type)
            {
                case "HKEY_CURRENT_USER":
                    using (RegistryKey key = Registry.CurrentUser.OpenSubKey(sub_path, true))
                    {
                        if (key != null)
                        {
                            key.DeleteValue(value, false);
                            key.Close();
                        }
                    }
                    break;

                case "HKEY_LOCAL_MACHINE":
                    using (RegistryKey key = Registry.LocalMachine.OpenSubKey(sub_path, true))
                    {
                        if (key != null)
                        {
                            key.DeleteValue(value, false);
                            key.Close();
                        }

                    }
                    break;

                case "HKEY_USERS":
                    using (RegistryKey key = Registry.Users.OpenSubKey(sub_path, true))
                    {
                        if (key != null)
                        {
                            key.DeleteValue(value, false);
                            key.Close();
                        }
                    }
                    break;
            }
        }


        public static void CleanRegistry(String additionalKeys)
        {

            string[] defaultRegKeys = { "HKEY_CURRENT_USER\\Software\\Microsoft\\IdentityCRL",
                                 "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\OneSettings\\xbox",
                                 "HKEY_USERS\\.DEFAULT\\Software\\Microsoft\\IdentityCRL",
                                 "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\XboxLive",
                                 "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Applets\\Regedit"
            };

            //Computer\HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Applets\Regedit
            //DeleteRegValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Applets\\Regedit", "view");

            foreach(string keyName in defaultRegKeys)
            {
                DeleteRegKey(keyName);
            }
        }
    }
}
