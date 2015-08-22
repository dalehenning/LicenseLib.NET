using System;
using System.Collections.Generic;
using System.Text;
using LicenseUtilityLib;

namespace LicenseLib
{
    public class LicenseKey
    {
        public static KeyObject GetInstalledKey(string companyName, string productName, string productVersion)
        {
            return KeyUtil.GetInstalledKey(companyName, productName, productVersion);
        }

        public static bool IsKeyInstalled(KeyObject key)
        {
            return KeyUtil.IsKeyInstalled(key);
        }

        public static bool InstallKey(KeyObject key)
        {
            SimpleHash.VerifyHash(key.Name, SimpleHash.HashEnum.SHA1, key.Key);
            string daysToExpire = SimpleHash._salt;
            int num;
            bool isNumeric = int.TryParse(daysToExpire, out num);
            if (isNumeric)
            {
                int days = -1;
                days = Convert.ToInt32(num);
                DateTime expireDate = DateTime.Now.AddDays(days);
                key.ExpireDate = expireDate.ToShortDateString();
            }
            else
            {
                // value is not a number
            }

            return KeyUtil.InstallKey(key);
        }

        public static bool UninstallKey(KeyObject key)
        {
            return KeyUtil.UninstallKey(key);
        }

        public static bool IsKeyCodeValid(string keyName, string keyCode)
        {
            return SimpleHash.VerifyHash(keyName, SimpleHash.HashEnum.SHA1, keyCode);
        }

        public static bool IsKeyExpired(KeyObject key)
        {
            bool isKeyExpired = true;

            if (IsKeyInstalled(key))
            {
                DateTime expireDate = KeyUtil.GetExpireDate(key);
                if (expireDate > DateTime.Now)
                {
                    isKeyExpired = false;
                }
            }

            return isKeyExpired; //The default is that the key is expired.  Prove it is not.
        }

        /// <summary>
        /// Get the days remaining of a key already installed.
        /// </summary>
        public static int GetDaysRemaining(KeyObject key)
        {
            //Check hashed install date, todays date to get days remaining
            int daysRemaining = KeyUtil.GetExpireDate(key).Subtract(DateTime.Now).Days;

            return daysRemaining;
        }

        #region Private Methods

        #endregion

        #region Properties

        private string _salt = "";
        public string Salt
        {
            get { return _salt; }
        }

        private bool _isErrored = false;
        public bool IsErrored
        {
            get { return _isErrored; }
        }

        private string _lastErrorMessage = "";
        public string LastErrorMessage
        {
            get { return _lastErrorMessage; }
        }

        #endregion
    }
}


//You could probably hash the licence holder's name (e.g. with MD5 /
//SHA1) and use, say, every fourth digit of the hash as the basis of the
//licence code (first 8 digits, or whatever); you could then encode the
//expiration date as a 16-bit number and perhaps perform some symmetric
//transform on it for security, and use the hex representation of the
//result as the last four digits. Then, you can check the licencee name
//by hashing the entered name and comparing the relevant digits; the
//expiration date can then be decoded if it matches.
