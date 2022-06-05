using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CopyGuid
{
    public partial class Form1 : Form
    {
        private Guid myGuid;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myGuid = Guid.NewGuid();
            txt_Guid.Text = myGuid.ToString();
            Clipboard.SetText(myGuid.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(myGuid.ToString());
        }
    }
}
