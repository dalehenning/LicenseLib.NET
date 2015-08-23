using System;
using System.Collections.Generic;
using System.Text;

namespace CodeGenLib
{
    public class CodeGen
    {

        public string CreateKey(string name)
        {
            string key = "";

            key = SimpleHash.ComputeHash(name, SimpleHash.HashEnum.SHA1, null);            

            return key;
        }

        public string CreateKey(string name, int expireTime)
        {
            System.Text.UTF8Encoding  encoding=new System.Text.UTF8Encoding();
           byte[] bytes = encoding.GetBytes(expireTime.ToString());

            string key = "";

            key = SimpleHash.ComputeHash(name, SimpleHash.HashEnum.SHA1, bytes);

            return key;
        }

        public bool VerifyKey(string name, string key)
        {
            bool isKeyVerified = false;

            isKeyVerified = SimpleHash.VerifyHash(name, SimpleHash.HashEnum.SHA1, key);
            _salt = SimpleHash._salt;

            return isKeyVerified;
        }

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
