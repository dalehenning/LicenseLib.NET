using System;
using System.Collections.Generic;
using System.Text;

namespace LicenseUtilityLib
{
    public class KeyObject
    {
        public KeyObject(string name, string key, string companyName, string productName, string version) : 
            this(name, key, companyName, productName, version, "")
        {
        }

        public KeyObject(string name, string key, string companyName, string productName, string version, string expireDate)
        {
            if (name == null) throw new ArgumentException("Parameter cannot be null.", "name");
            if (key == null) throw new ArgumentException("Parameter cannot be null.", "key");
            if (companyName == null || companyName.Trim() == "") throw new ArgumentException("Parameter cannot be null or empty.", "companyName");
            if (productName == null || productName.Trim() == "") throw new ArgumentException("Parameter cannot be null or empty.", "productName");
            if (version == null || version.Trim() == "") throw new ArgumentException("Parameter cannot be null or empty.", "version");

            _name = name;
            _key = key;
            _companyName = companyName;
            _productName = productName;
            _version = version;
            _expireDate = expireDate;
        }

        #region Properties

        private string _name = "";
        private string _key = "";
        private string _companyName = "";
        private string _productName = "";
        private string _version = "";
        private string _expireDate = "";

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }

        public string CompanyName
        {
            get { return _companyName; }
        }

        public string ProductName
        {
            get { return _productName; }
        }

        public string Version
        {
            get { return _version; }
        }

        public string ExpireDate
        {
            get { return _expireDate; }
            set { _expireDate = value; }
        }

        #endregion
    }

}
