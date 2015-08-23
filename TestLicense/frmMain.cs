using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;
using LicenseLib;

namespace TestLicense
{
    public partial class frmMain : Form
    {
        private string REG_KEY_BASE = "";
        private string REG_KEY_SUB = "";
        public frmMain()
        {
            REG_KEY_BASE = @"SOFTWARE\";
            REG_KEY_SUB = "license";

            InitializeComponent();

            CheckLicense();
        }

        private void CheckLicense()
        {


            //RegistryKey regKeyBase = Registry.CurrentUser.OpenSubKey(REG_KEY_BASE, true);

            //RegistryKey regKeyCompany = regKeyBase.OpenSubKey(Application.CompanyName);
            //if (regKeyCompany == null)
            //{
            //    regKeyCompany = regKeyBase.CreateSubKey(Application.CompanyName);
            //}

            //RegistryKey regKeyProduct = regKeyCompany.OpenSubKey(Application.ProductName);
            //if (regKeyProduct == null)
            //{
            //    regKeyProduct = regKeyCompany.CreateSubKey(Application.ProductName);
            //}

            //RegistryKey regKeyLicense = regKeyProduct.OpenSubKey(REG_KEY_SUB);
            //if (regKeyLicense == null)
            //{
            //    regKeyLicense = regKeyProduct.CreateSubKey(REG_KEY_SUB);
            //}





            // + Application.CompanyName + @"\" + Application.ProductName
            //RegistryKey baseRegKey = new RegistryKey()


            //RegistryEdit regEdit = new RegistryEdit()
        }
    }
}
