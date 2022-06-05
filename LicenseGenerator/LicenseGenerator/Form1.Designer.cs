namespace LicenseGenerator
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.general = new System.Windows.Forms.TabPage();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btn_GenerateKey = new System.Windows.Forms.Button();
            this.rt_Key = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.details = new System.Windows.Forms.TabPage();
            this.label_Guid = new System.Windows.Forms.Label();
            this.txt_Guid = new System.Windows.Forms.TextBox();
            this.btn_createLicense = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_User = new System.Windows.Forms.ComboBox();
            this.cb_Type = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txt_Email = new System.Windows.Forms.TextBox();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.log = new System.Windows.Forms.TabPage();
            this.rt_Log = new System.Windows.Forms.RichTextBox();
            this.archive = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tv_Archive = new System.Windows.Forms.TreeView();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.tabControl1.SuspendLayout();
            this.general.SuspendLayout();
            this.details.SuspendLayout();
            this.log.SuspendLayout();
            this.archive.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.general);
            this.tabControl1.Controls.Add(this.details);
            this.tabControl1.Controls.Add(this.log);
            this.tabControl1.Controls.Add(this.archive);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(305, 301);
            this.tabControl1.TabIndex = 0;
            // 
            // general
            // 
            this.general.Controls.Add(this.checkBox1);
            this.general.Controls.Add(this.btn_GenerateKey);
            this.general.Controls.Add(this.rt_Key);
            this.general.Controls.Add(this.label1);
            this.general.Controls.Add(this.txt_Password);
            this.general.Location = new System.Drawing.Point(4, 22);
            this.general.Name = "general";
            this.general.Size = new System.Drawing.Size(297, 275);
            this.general.TabIndex = 0;
            this.general.Text = "general";
            this.general.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 134);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(100, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "add to archive?";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btn_GenerateKey
            // 
            this.btn_GenerateKey.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_GenerateKey.Location = new System.Drawing.Point(6, 157);
            this.btn_GenerateKey.Name = "btn_GenerateKey";
            this.btn_GenerateKey.Size = new System.Drawing.Size(288, 114);
            this.btn_GenerateKey.TabIndex = 3;
            this.btn_GenerateKey.Text = "create Key";
            this.btn_GenerateKey.UseVisualStyleBackColor = true;
            this.btn_GenerateKey.Click += new System.EventHandler(this.btn_Key_Click);
            // 
            // rt_Key
            // 
            this.rt_Key.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rt_Key.Location = new System.Drawing.Point(6, 32);
            this.rt_Key.Name = "rt_Key";
            this.rt_Key.Size = new System.Drawing.Size(288, 96);
            this.rt_Key.TabIndex = 2;
            this.rt_Key.Text = "";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Password:";
            // 
            // txt_Password
            // 
            this.txt_Password.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Password.Location = new System.Drawing.Point(65, 6);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Size = new System.Drawing.Size(229, 20);
            this.txt_Password.TabIndex = 0;
            // 
            // details
            // 
            this.details.Controls.Add(this.label_Guid);
            this.details.Controls.Add(this.txt_Guid);
            this.details.Controls.Add(this.btn_createLicense);
            this.details.Controls.Add(this.label6);
            this.details.Controls.Add(this.label5);
            this.details.Controls.Add(this.label4);
            this.details.Controls.Add(this.cb_User);
            this.details.Controls.Add(this.cb_Type);
            this.details.Controls.Add(this.dateTimePicker1);
            this.details.Controls.Add(this.txt_Email);
            this.details.Controls.Add(this.txt_Name);
            this.details.Controls.Add(this.label3);
            this.details.Controls.Add(this.label2);
            this.details.Location = new System.Drawing.Point(4, 22);
            this.details.Name = "details";
            this.details.Size = new System.Drawing.Size(297, 275);
            this.details.TabIndex = 1;
            this.details.Text = "details";
            this.details.UseVisualStyleBackColor = true;
            // 
            // label_Guid
            // 
            this.label_Guid.AutoSize = true;
            this.label_Guid.Location = new System.Drawing.Point(7, 85);
            this.label_Guid.Name = "label_Guid";
            this.label_Guid.Size = new System.Drawing.Size(35, 13);
            this.label_Guid.TabIndex = 12;
            this.label_Guid.Text = "Guid: ";
            // 
            // txt_Guid
            // 
            this.txt_Guid.Location = new System.Drawing.Point(47, 82);
            this.txt_Guid.Name = "txt_Guid";
            this.txt_Guid.Size = new System.Drawing.Size(247, 20);
            this.txt_Guid.TabIndex = 11;
            // 
            // btn_createLicense
            // 
            this.btn_createLicense.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_createLicense.Enabled = false;
            this.btn_createLicense.Location = new System.Drawing.Point(8, 162);
            this.btn_createLicense.Name = "btn_createLicense";
            this.btn_createLicense.Size = new System.Drawing.Size(286, 110);
            this.btn_createLicense.TabIndex = 10;
            this.btn_createLicense.Text = "create License";
            this.btn_createLicense.UseVisualStyleBackColor = true;
            this.btn_createLicense.Click += new System.EventHandler(this.btn_createLicense_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "User:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Type:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Expires:";
            // 
            // cb_User
            // 
            this.cb_User.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_User.FormattingEnabled = true;
            this.cb_User.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "4",
            "5"});
            this.cb_User.Location = new System.Drawing.Point(47, 135);
            this.cb_User.Name = "cb_User";
            this.cb_User.Size = new System.Drawing.Size(247, 21);
            this.cb_User.TabIndex = 6;
            this.cb_User.Text = "1";
            // 
            // cb_Type
            // 
            this.cb_Type.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_Type.FormattingEnabled = true;
            this.cb_Type.Items.AddRange(new object[] {
            "Trial",
            "Normal"});
            this.cb_Type.Location = new System.Drawing.Point(47, 108);
            this.cb_Type.Name = "cb_Type";
            this.cb_Type.Size = new System.Drawing.Size(247, 21);
            this.cb_Type.TabIndex = 5;
            this.cb_Type.Text = "Trial";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.Location = new System.Drawing.Point(47, 55);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(247, 20);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // txt_Email
            // 
            this.txt_Email.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Email.Location = new System.Drawing.Point(47, 29);
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Size = new System.Drawing.Size(247, 20);
            this.txt_Email.TabIndex = 3;
            this.txt_Email.Text = "Nico@DerHomo.com";
            // 
            // txt_Name
            // 
            this.txt_Name.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Name.Location = new System.Drawing.Point(47, 4);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(247, 20);
            this.txt_Name.TabIndex = 2;
            this.txt_Name.Text = "Max Mustermann";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "E-Mail:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Name:";
            // 
            // log
            // 
            this.log.Controls.Add(this.rt_Log);
            this.log.Location = new System.Drawing.Point(4, 22);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(297, 275);
            this.log.TabIndex = 2;
            this.log.Text = "log";
            this.log.UseVisualStyleBackColor = true;
            // 
            // rt_Log
            // 
            this.rt_Log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rt_Log.Location = new System.Drawing.Point(3, 3);
            this.rt_Log.Name = "rt_Log";
            this.rt_Log.Size = new System.Drawing.Size(291, 269);
            this.rt_Log.TabIndex = 0;
            this.rt_Log.Text = "";
            // 
            // archive
            // 
            this.archive.Controls.Add(this.richTextBox1);
            this.archive.Controls.Add(this.tv_Archive);
            this.archive.Location = new System.Drawing.Point(4, 22);
            this.archive.Name = "archive";
            this.archive.Size = new System.Drawing.Size(297, 275);
            this.archive.TabIndex = 3;
            this.archive.Text = "archive";
            this.archive.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(86, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(208, 269);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // tv_Archive
            // 
            this.tv_Archive.Location = new System.Drawing.Point(3, 3);
            this.tv_Archive.Name = "tv_Archive";
            this.tv_Archive.Size = new System.Drawing.Size(83, 269);
            this.tv_Archive.TabIndex = 0;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(19, 312);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(76, 13);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "build Treeview";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 325);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.general.ResumeLayout(false);
            this.general.PerformLayout();
            this.details.ResumeLayout(false);
            this.details.PerformLayout();
            this.log.ResumeLayout(false);
            this.archive.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage general;
        private System.Windows.Forms.TabPage details;
        private System.Windows.Forms.TabPage log;
        private System.Windows.Forms.RichTextBox rt_Log;
        private System.Windows.Forms.Button btn_GenerateKey;
        private System.Windows.Forms.RichTextBox rt_Key;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.Button btn_createLicense;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_User;
        private System.Windows.Forms.ComboBox cb_Type;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_Guid;
        private System.Windows.Forms.TextBox txt_Guid;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TabPage archive;
        private System.Windows.Forms.TreeView tv_Archive;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

