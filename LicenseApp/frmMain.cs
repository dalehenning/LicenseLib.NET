using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CodeGenLib;

namespace LicenseApp
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void makeAKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnCreateKey_Click(object sender, EventArgs e)
        {
            CodeGen cg = new CodeGen();
            string name = txtName.Text.Trim();
            if (name.Length > 0)
            {
                if (txtDays.Text.Trim().Length > 0)
                {
                    txtKey.Text = cg.CreateKey(name, Convert.ToInt32(txtDays.Text));
                }
                else
                {
                    txtKey.Text = cg.CreateKey(name);
                }
            }
            else
            {
                MessageBox.Show("Enter a valid name.");
            }
        }

        private void btnVerify_Click_1(object sender, EventArgs e)
        {

            string result = "";

            CodeGen gen = new CodeGen();
            bool isValid = gen.VerifyKey(txtVerifyName.Text, txtVerifyKey.Text);

            if (isValid)
            {
                result = "Registration name and key are valid.";
            }
            else
            {
                result = "Registration name and / or key is not valid";
            }
            

            MessageBox.Show(result);
        }
    }
}
