using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Portable.Licensing;
using Portable.Licensing.Validation;
using System.IO;
using System.Xml.Linq;

namespace LicenseGenerator
{
    public partial class Form1 : Form
    {
        private Portable.Licensing.License pLicense;
        private Portable.Licensing.License nLicense;
        private SettingsManager manager = new SettingsManager();
        private string PrivateKey, PublicKey;
        private bool archiveCurrent = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Key_Click(object sender, EventArgs e)
        {
            if (!(String.IsNullOrEmpty(txt_Password.Text)))
            {
                var keyGenerator = Portable.Licensing.Security.Cryptography.KeyGenerator.Create();
                var keyPair = keyGenerator.GenerateKeyPair();

                PrivateKey = keyPair.ToEncryptedPrivateKeyString(txt_Password.Text.Trim());
                PublicKey = keyPair.ToPublicKeyString();

                btn_createLicense.Enabled = true;
                var data = new XElement((new XElement("KeyGenerator", new XElement("Privatekey", PrivateKey), new XElement("Publickey", PublicKey), new XElement("Password", txt_Password.Text))));
                rt_Key.AppendText("PrivateKey: " + PrivateKey + "\nPublicKey: " + PublicKey);
                Clipboard.SetText(PublicKey);
                Append("[KeyGenerator] generated Private and Public Key!\n[KeyGenerator]Please note the Publickey: " + PublicKey + "\n");
                if (archiveCurrent)
                {
                    _ = manager.addData(data);
                }
            }
            else
            {
                Append("[KeyGenerator] could not generate a key without password!\n");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // XElement date = new XElement("date", DateTime.Now);
           // manager.addData(date);

            dateTimePicker1.MinDate = DateTime.Now.AddDays(1);
        }
        private void btn_createLicense_Click(object sender, EventArgs e)
        {
            if(!(String.IsNullOrEmpty(txt_Name.Text)) && !(String.IsNullOrEmpty(label_Guid.Text))  && !(String.IsNullOrEmpty(txt_Email.Text)) && !(String.IsNullOrEmpty(cb_Type.Text)) && !(String.IsNullOrEmpty(cb_User.Text)))
            {
                Guid myId;
                Guid.TryParse(txt_Guid.Text, out myId);
                DateTime date;
                date = DateTime.Parse(dateTimePicker1.Text);
                int quantity = Convert.ToInt32(cb_User.Text);
                LicenseType type = LicenseType.Trial;
                switch(cb_Type.Text)
                {
                    case "Trial":
                        type = LicenseType.Trial;
                        break;
                    case "Normal":
                        type = LicenseType.Standard;
                        break;
                }
                nLicense = Portable.Licensing.License.New().WithUniqueIdentifier(myId).As(type).WithMaximumUtilization(quantity).LicensedTo(txt_Name.Text, txt_Email.Text).ExpiresAt(date).CreateAndSignWithPrivateKey(PrivateKey, txt_Password.Text);

                var sf_Dialog = new SaveFileDialog();
                sf_Dialog.Filter = "License (*.lic)|*.lic";
                sf_Dialog.FilterIndex = 1;
                sf_Dialog.RestoreDirectory = true;
                if (sf_Dialog.ShowDialog() == DialogResult.OK)
                    File.WriteAllText(sf_Dialog.FileName, nLicense.ToString(), Encoding.UTF8);

                if (archiveCurrent)
                    MessageBox.Show("Archive me");
                Append("[LicenseGenerator] generated license and saved it to " + sf_Dialog.FileName + "!\n");
            }
            else
            {
                Append("[LicenseGenerator] could not generate a license without data!\n");
            }
        }

        void Append(string text)
        {
            rt_Log.AppendText(text);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            archiveCurrent = checkBox1.Checked;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //LoadTree(data, tv_Archive.TopNode);
            manager.printAll();
        }

        void LoadTree(XElement root, TreeNode rootNode)
        {
            foreach (var e in root.Elements().Where(e => e.Attribute("NAME") != null))
            {
                var node = new TreeNode(e.Attribute("NAME").Value);
                rootNode.Nodes.Add(node);
                LoadTree(e, node);
            }
        }
    }
}
