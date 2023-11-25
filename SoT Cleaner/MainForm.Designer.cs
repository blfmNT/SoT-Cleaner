namespace HWID_Changer
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.deleteProfilebtn = new System.Windows.Forms.Button();
            this.restartCB = new System.Windows.Forms.CheckBox();
            this.btnApplyProfile = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.profilesBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.loadCurrentIDS = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.allRandombtn = new System.Windows.Forms.Button();
            this.SSbtnRnd = new System.Windows.Forms.Button();
            this.SStextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PSNbtnRnd = new System.Windows.Forms.Button();
            this.PSNtextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BSbtnRnd = new System.Windows.Forms.Button();
            this.BStextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CSbtnRnd = new System.Windows.Forms.Button();
            this.CStextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.VSNboxRnd = new System.Windows.Forms.Button();
            this.driveNameBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.VSNtextBox = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cleamXboxLoginCacheBtn = new System.Windows.Forms.Button();
            this.credentialsCleanBtn = new System.Windows.Forms.Button();
            this.registryCleanBtn = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.deleteProfilebtn);
            this.groupBox1.Controls.Add(this.restartCB);
            this.groupBox1.Controls.Add(this.btnApplyProfile);
            this.groupBox1.Controls.Add(this.saveBtn);
            this.groupBox1.Controls.Add(this.profilesBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 172);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Profiles";
            // 
            // deleteProfilebtn
            // 
            this.deleteProfilebtn.Enabled = false;
            this.deleteProfilebtn.Location = new System.Drawing.Point(6, 83);
            this.deleteProfilebtn.Name = "deleteProfilebtn";
            this.deleteProfilebtn.Size = new System.Drawing.Size(188, 23);
            this.deleteProfilebtn.TabIndex = 5;
            this.deleteProfilebtn.Text = "Delete";
            this.deleteProfilebtn.UseVisualStyleBackColor = true;
            this.deleteProfilebtn.Click += new System.EventHandler(this.deleteProfilebtn_Click);
            // 
            // restartCB
            // 
            this.restartCB.AutoSize = true;
            this.restartCB.Location = new System.Drawing.Point(6, 112);
            this.restartCB.Name = "restartCB";
            this.restartCB.Size = new System.Drawing.Size(121, 19);
            this.restartCB.TabIndex = 4;
            this.restartCB.Text = "Restart after apply";
            this.restartCB.UseVisualStyleBackColor = true;
            // 
            // btnApplyProfile
            // 
            this.btnApplyProfile.Location = new System.Drawing.Point(6, 137);
            this.btnApplyProfile.Name = "btnApplyProfile";
            this.btnApplyProfile.Size = new System.Drawing.Size(188, 23);
            this.btnApplyProfile.TabIndex = 3;
            this.btnApplyProfile.Text = "Apply";
            this.btnApplyProfile.UseVisualStyleBackColor = true;
            this.btnApplyProfile.Click += new System.EventHandler(this.btnApplyProfile_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(6, 51);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(188, 23);
            this.saveBtn.TabIndex = 2;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // profilesBox
            // 
            this.profilesBox.FormattingEnabled = true;
            this.profilesBox.Location = new System.Drawing.Point(6, 22);
            this.profilesBox.Name = "profilesBox";
            this.profilesBox.Size = new System.Drawing.Size(188, 23);
            this.profilesBox.TabIndex = 0;
            this.profilesBox.Text = "Choose profile or create one";
            this.profilesBox.SelectedIndexChanged += new System.EventHandler(this.profilesBox_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.loadCurrentIDS);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.VSNboxRnd);
            this.groupBox2.Controls.Add(this.driveNameBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.VSNtextBox);
            this.groupBox2.Location = new System.Drawing.Point(218, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(316, 334);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data";
            // 
            // loadCurrentIDS
            // 
            this.loadCurrentIDS.Location = new System.Drawing.Point(12, 302);
            this.loadCurrentIDS.Name = "loadCurrentIDS";
            this.loadCurrentIDS.Size = new System.Drawing.Size(298, 23);
            this.loadCurrentIDS.TabIndex = 6;
            this.loadCurrentIDS.Text = "Load current IDs";
            this.loadCurrentIDS.UseVisualStyleBackColor = true;
            this.loadCurrentIDS.Click += new System.EventHandler(this.loadCurrentIDS_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.allRandombtn);
            this.groupBox3.Controls.Add(this.SSbtnRnd);
            this.groupBox3.Controls.Add(this.SStextBox);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.PSNbtnRnd);
            this.groupBox3.Controls.Add(this.PSNtextBox);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.BSbtnRnd);
            this.groupBox3.Controls.Add(this.BStextBox);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.CSbtnRnd);
            this.groupBox3.Controls.Add(this.CStextBox);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(6, 68);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(310, 232);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Motherboard";
            // 
            // allRandombtn
            // 
            this.allRandombtn.Location = new System.Drawing.Point(6, 200);
            this.allRandombtn.Name = "allRandombtn";
            this.allRandombtn.Size = new System.Drawing.Size(297, 23);
            this.allRandombtn.TabIndex = 14;
            this.allRandombtn.Text = "All Random";
            this.allRandombtn.UseVisualStyleBackColor = true;
            this.allRandombtn.Click += new System.EventHandler(this.allRandombtn_Click);
            // 
            // SSbtnRnd
            // 
            this.SSbtnRnd.Location = new System.Drawing.Point(278, 172);
            this.SSbtnRnd.Name = "SSbtnRnd";
            this.SSbtnRnd.Size = new System.Drawing.Size(25, 23);
            this.SSbtnRnd.TabIndex = 13;
            this.SSbtnRnd.Text = "?";
            this.SSbtnRnd.UseVisualStyleBackColor = true;
            this.SSbtnRnd.Click += new System.EventHandler(this.SSbtnRnd_Click);
            // 
            // SStextBox
            // 
            this.SStextBox.Location = new System.Drawing.Point(6, 172);
            this.SStextBox.MaxLength = 8;
            this.SStextBox.Name = "SStextBox";
            this.SStextBox.Size = new System.Drawing.Size(266, 23);
            this.SStextBox.TabIndex = 12;
            this.SStextBox.TextChanged += new System.EventHandler(this.SStextBox_TextChanged);
            this.SStextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SStextBox_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "System Serial number";
            // 
            // PSNbtnRnd
            // 
            this.PSNbtnRnd.Location = new System.Drawing.Point(278, 128);
            this.PSNbtnRnd.Name = "PSNbtnRnd";
            this.PSNbtnRnd.Size = new System.Drawing.Size(25, 23);
            this.PSNbtnRnd.TabIndex = 10;
            this.PSNbtnRnd.Text = "?";
            this.PSNbtnRnd.UseVisualStyleBackColor = true;
            this.PSNbtnRnd.Click += new System.EventHandler(this.PSNbtnRnd_Click);
            // 
            // PSNtextBox
            // 
            this.PSNtextBox.Location = new System.Drawing.Point(6, 128);
            this.PSNtextBox.MaxLength = 14;
            this.PSNtextBox.Name = "PSNtextBox";
            this.PSNtextBox.Size = new System.Drawing.Size(266, 23);
            this.PSNtextBox.TabIndex = 9;
            this.PSNtextBox.TextChanged += new System.EventHandler(this.PSNtextBox_TextChanged);
            this.PSNtextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PSNtextBox_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Processor Serial number";
            // 
            // BSbtnRnd
            // 
            this.BSbtnRnd.Location = new System.Drawing.Point(278, 81);
            this.BSbtnRnd.Name = "BSbtnRnd";
            this.BSbtnRnd.Size = new System.Drawing.Size(25, 23);
            this.BSbtnRnd.TabIndex = 7;
            this.BSbtnRnd.Text = "?";
            this.BSbtnRnd.UseVisualStyleBackColor = true;
            this.BSbtnRnd.Click += new System.EventHandler(this.BSbtnRnd_Click);
            // 
            // BStextBox
            // 
            this.BStextBox.Location = new System.Drawing.Point(6, 81);
            this.BStextBox.MaxLength = 8;
            this.BStextBox.Name = "BStextBox";
            this.BStextBox.Size = new System.Drawing.Size(266, 23);
            this.BStextBox.TabIndex = 6;
            this.BStextBox.TextChanged += new System.EventHandler(this.BStextBox_TextChanged);
            this.BStextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BStextBox_KeyDown);
            this.BStextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BStextBox_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Baseboard Serial number";
            // 
            // CSbtnRnd
            // 
            this.CSbtnRnd.Location = new System.Drawing.Point(278, 37);
            this.CSbtnRnd.Name = "CSbtnRnd";
            this.CSbtnRnd.Size = new System.Drawing.Size(25, 23);
            this.CSbtnRnd.TabIndex = 4;
            this.CSbtnRnd.Text = "?";
            this.CSbtnRnd.UseVisualStyleBackColor = true;
            this.CSbtnRnd.Click += new System.EventHandler(this.CSbtnRnd_Click);
            // 
            // CStextBox
            // 
            this.CStextBox.Location = new System.Drawing.Point(6, 37);
            this.CStextBox.MaxLength = 6;
            this.CStextBox.Name = "CStextBox";
            this.CStextBox.Size = new System.Drawing.Size(266, 23);
            this.CStextBox.TabIndex = 1;
            this.CStextBox.TextChanged += new System.EventHandler(this.CStextBox_TextChanged);
            this.CStextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CStextBox_KeyPress);
            this.CStextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CStextBox_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Chassis Serial number";
            // 
            // VSNboxRnd
            // 
            this.VSNboxRnd.Location = new System.Drawing.Point(284, 39);
            this.VSNboxRnd.Name = "VSNboxRnd";
            this.VSNboxRnd.Size = new System.Drawing.Size(25, 23);
            this.VSNboxRnd.TabIndex = 3;
            this.VSNboxRnd.Text = "?";
            this.VSNboxRnd.UseVisualStyleBackColor = true;
            this.VSNboxRnd.Click += new System.EventHandler(this.VSNboxRnd_Click);
            // 
            // driveNameBox
            // 
            this.driveNameBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.driveNameBox.FormattingEnabled = true;
            this.driveNameBox.Location = new System.Drawing.Point(6, 39);
            this.driveNameBox.Name = "driveNameBox";
            this.driveNameBox.Size = new System.Drawing.Size(53, 23);
            this.driveNameBox.TabIndex = 2;
            this.driveNameBox.SelectedIndexChanged += new System.EventHandler(this.driveNameBox_SelectedIndexChanged);
            this.driveNameBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.driveNameBox_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "VSN (Disks Serials)";
            // 
            // VSNtextBox
            // 
            this.VSNtextBox.Location = new System.Drawing.Point(65, 39);
            this.VSNtextBox.MaxLength = 9;
            this.VSNtextBox.Name = "VSNtextBox";
            this.VSNtextBox.Size = new System.Drawing.Size(213, 23);
            this.VSNtextBox.TabIndex = 0;
            this.VSNtextBox.TextChanged += new System.EventHandler(this.VSNtextBox_TextChanged);
            this.VSNtextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VSNtextBox_KeyDown);
            this.VSNtextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.VSNtextBox_KeyPress);
            this.VSNtextBox.Validating += new System.ComponentModel.CancelEventHandler(this.VSNtextBox_Validating);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cleamXboxLoginCacheBtn);
            this.groupBox4.Controls.Add(this.credentialsCleanBtn);
            this.groupBox4.Controls.Add(this.registryCleanBtn);
            this.groupBox4.Location = new System.Drawing.Point(12, 190);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 113);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "SoT Data Cleaner";
            // 
            // cleamXboxLoginCacheBtn
            // 
            this.cleamXboxLoginCacheBtn.Location = new System.Drawing.Point(6, 80);
            this.cleamXboxLoginCacheBtn.Name = "cleamXboxLoginCacheBtn";
            this.cleamXboxLoginCacheBtn.Size = new System.Drawing.Size(188, 23);
            this.cleamXboxLoginCacheBtn.TabIndex = 2;
            this.cleamXboxLoginCacheBtn.Text = "Clean XBL Cache";
            this.cleamXboxLoginCacheBtn.UseVisualStyleBackColor = true;
            this.cleamXboxLoginCacheBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // credentialsCleanBtn
            // 
            this.credentialsCleanBtn.Location = new System.Drawing.Point(6, 51);
            this.credentialsCleanBtn.Name = "credentialsCleanBtn";
            this.credentialsCleanBtn.Size = new System.Drawing.Size(188, 23);
            this.credentialsCleanBtn.TabIndex = 1;
            this.credentialsCleanBtn.Text = "Clean Credentials";
            this.credentialsCleanBtn.UseVisualStyleBackColor = true;
            this.credentialsCleanBtn.Click += new System.EventHandler(this.credentialsCleanBtn_Click);
            // 
            // registryCleanBtn
            // 
            this.registryCleanBtn.Location = new System.Drawing.Point(6, 22);
            this.registryCleanBtn.Name = "registryCleanBtn";
            this.registryCleanBtn.Size = new System.Drawing.Size(188, 23);
            this.registryCleanBtn.TabIndex = 0;
            this.registryCleanBtn.Text = "Clean Registry";
            this.registryCleanBtn.UseVisualStyleBackColor = true;
            this.registryCleanBtn.Click += new System.EventHandler(this.registryCleanBtn_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 352);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(542, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel1
            // 
            this.statusLabel1.Name = "statusLabel1";
            this.statusLabel1.Size = new System.Drawing.Size(42, 17);
            this.statusLabel1.Text = "Status:";
            this.statusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 374);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HWID Changer GUI and SoT cleaner by blfmNT";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private ComboBox profilesBox;
        private Button saveBtn;
        private GroupBox groupBox2;
        private Label label1;
        private TextBox VSNtextBox;
        private ComboBox driveNameBox;
        private Button VSNboxRnd;
        private GroupBox groupBox3;
        private Label label2;
        private Button CSbtnRnd;
        private TextBox CStextBox;
        private Button BSbtnRnd;
        private TextBox BStextBox;
        private Label label3;
        private Button SSbtnRnd;
        private TextBox SStextBox;
        private Label label4;
        private Button PSNbtnRnd;
        private TextBox PSNtextBox;
        private Label label5;
        private Button btnApplyProfile;
        private CheckBox restartCB;
        private Button deleteProfilebtn;
        private Button allRandombtn;
        private GroupBox groupBox4;
        private Button credentialsCleanBtn;
        private Button registryCleanBtn;
        private Button cleamXboxLoginCacheBtn;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statusLabel1;
        private Button loadCurrentIDS;
    }
}