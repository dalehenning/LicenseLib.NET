using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace LicenseUtilityLib
{
    public class KeyUtil
    {
        #region Members

        private const string REG_KEY_BASE = @"SOFTWARE";

        #endregion

        public static KeyObject GetInstalledKey(string companyName, string productName, string productVersion)
        {
            KeyObject key = new KeyObject("", "", companyName, productName, productVersion);
            string regPath = BuildRegPath(key);
            RegistryEdit reg = new RegistryEdit();
            RegistryKey regKey = reg.Read(regPath);
            if (regKey == null) return null;

            object keyName = regKey.GetValue("KeyName");
            object keyCode = regKey.GetValue("KeyCode");
            if (keyName != null)
                key.Name = keyName.ToString();

            if (keyCode != null)
                key.Key = keyCode.ToString();
            return key;
        }

        public static bool IsKeyInstalled(KeyObject key)
        {            
            RegistryKey regKey = null;

            if (key != null)
            {
                string regPath = BuildRegPath(key);
                RegistryEdit reg = new RegistryEdit();
                regKey = reg.Read(regPath);
                if ((regKey != null) &&
                    ((regKey.GetValue("KeyName").ToString() == key.Name) & (regKey.GetValue("KeyCode").ToString() == key.Key)))
                {
                    return true;
                }
            }

            return false; //If we make it this far, the key was not installed.
        }

        public static bool InstallKey(KeyObject key)
        {
            RegistryEdit reg = new RegistryEdit();
            string keyPath = BuildRegPath(key);
            RegistryKey regKey = reg.WriteKey(keyPath);
            if (regKey != null)
            {
                bool isKeyNameWritten = reg.WriteValue(keyPath, "KeyName", key.Name);
                bool isKeyCodeWritten = reg.WriteValue(keyPath, "KeyCode", key.Key);
                bool isExpireDateWritten = reg.WriteValue(keyPath, "ExpireDate", key.ExpireDate);
                return isKeyNameWritten & isKeyCodeWritten & isExpireDateWritten;
            }
            else
            {
                return false;
            }
        }
        public static bool UninstallKey(KeyObject key)
        {
            RegistryEdit reg = new RegistryEdit();
            string keyPath = BuildRegPath(key);
            return reg.DeleteKey(keyPath, key.CompanyName);
        }

        public static DateTime GetExpireDate(KeyObject key)
        {
            RegistryEdit reg = new RegistryEdit();
            RegistryKey regKey = reg.Read(BuildRegPath(key));
            object regValue = regKey.GetValue("ExpireDate");
            try
            {
                return DateTime.Parse(regValue.ToString());
            }
            catch 
            {
                return DateTime.MinValue;//Invalid date
            }
        }

        public static string BuildRegPath(KeyObject key)
        {
            StringBuilder regPath = new StringBuilder();
            regPath.Append(string.Format(@"{0}\{1}\{2}\{3}\license", REG_KEY_BASE, key.CompanyName, key.ProductName, key.Version));
            return regPath.ToString();
        }

        #region Private Methods


        #endregion
    }
}
