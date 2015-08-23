using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;     

namespace LicenseUtilityLib
{
    public class RegistryEdit
    {
        #region Members and Construction

        public RegistryEdit()
        {
        }

        #endregion

        #region Public Methods

        public RegistryKey Read(string regKeyPath)
        {
            if ((regKeyPath == null) || (regKeyPath.Trim().Length == 0)) throw new ArgumentException("Parameter cannot be null or empty.", "regKeyPath");
            
            bool isWritable = true; //Default to true.
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(regKeyPath, isWritable);
            return regKey;
        }

        public RegistryKey WriteKey(string regKeyPath)
        {
            if ((regKeyPath == null) || (regKeyPath.Trim().Length == 0)) throw new ArgumentException("Parameter cannot be null or empty.", "regKeyPath");

            RegistryKey regKey = null;
            string[] pathParts = GetPathParts(regKeyPath);

            foreach (string part in pathParts)
            {
                regKey = Write(regKey, part);
            }
            
            return regKey;
        }

        public bool DeleteKey(string regKeyPath, string parentKeyToDelete)
        {
            if ((regKeyPath == null) || (regKeyPath.Trim().Length == 0)) throw new ArgumentException("Parameter cannot be null or empty.", "regKeyPath");
            if ((parentKeyToDelete == null) || (parentKeyToDelete.Trim().Length == 0)) throw new ArgumentException("Parameter cannot be null or empty.", "parentKeyToDelete");

            bool isDeleted = false;

            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(regKeyPath, true);

            if (regKey != null)
            {

                string[] pathParts = GetPathParts(regKeyPath);
                int index = 0;
                int minNum = 2;//Make sure we never delete less than 2 levels deep (prevent regedit deletion);
                int maxDelete = 4; //Only delete 4 levels. any more than this requires manual deletion
                string blockVal = "software";

                //In this loop, we make sure we never delete: (1) past the max delete value (2) if the 
                //block value equals the current key (too close to the base level, or (3) if the subkey
                //count is abnormally large - indicating a base level key.  These three countermeasures
                //SHOULD ensure preventing accidental deletion of major portions of the registry.
                for (int i = (pathParts.Length-1); i > (pathParts.Length - 1 - maxDelete); i--)
                {
                    string currentPart = pathParts[i];
                    if (currentPart.Equals(blockVal, StringComparison.CurrentCultureIgnoreCase))
                    {
                        break;
                    }

                    regKey = Registry.CurrentUser.OpenSubKey(regKeyPath, true);
                    if (regKey.SubKeyCount > 20)
                    {
                        //Something is wrong - we should never have this many subkeys from something I created.
                        //Get out of here.
                        break;
                    }

                    regKeyPath = regKeyPath.Replace("\\" + currentPart, "");
                    regKey = Registry.CurrentUser.OpenSubKey(regKeyPath, true);                    
                    regKey.DeleteSubKeyTree(currentPart);

                    //TODO: Kludge
                    if (currentPart.Equals(parentKeyToDelete, StringComparison.CurrentCultureIgnoreCase))
                    {
                        isDeleted = true;
                        break;
                    }  
                }                
            }

            return isDeleted;
        }

        public bool WriteValue(string regKeyPath, string keyNameToWrite, object valueToWrite)
        {
            if ((regKeyPath == null) || (regKeyPath.Trim().Length == 0)) throw new ArgumentException("Parameter cannot be null or empty.", "regKeyPath");
            if ((keyNameToWrite == null) || (keyNameToWrite.Trim().Length == 0)) throw new ArgumentException("Parameter cannot be null or empty.", "keyNameToWrite");
            if (valueToWrite == null) throw new ArgumentException("Parameter cannot be null.", "valueToWrite");

            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(regKeyPath, true);
            regKey.SetValue(keyNameToWrite.ToUpper(), valueToWrite);
            object returnValue = null;
            returnValue = regKey.GetValue(keyNameToWrite.ToUpper(), returnValue);

            //If they are the same type AND the value within is the same (converted to string for ease of comparison)
            if ((returnValue.GetType() == valueToWrite.GetType()) && 
                (returnValue.ToString().Equals(valueToWrite.ToString(), StringComparison.CurrentCultureIgnoreCase)))
                return true;
            else 
                return false;           
        }

        #endregion


        #region Private Methods


        /// <summary>
        /// Recursive method to walk the target path, creating directories in the registry as it works its way down.
        /// </summary>
        /// <param name="key">Pass in valid object for an existing key, or null to assume starting at the beggining.</param>
        /// <param name="pathToWrite">Writes this path starting where the key variable ends.</param>
        /// <returns></returns>
        private RegistryKey Write(RegistryKey key, string pathToWrite)
        {
            if (key == null)
            {
                //First time in. Path to write will be the base path.
                key = Registry.CurrentUser.OpenSubKey(pathToWrite, true);
            }
            else
            {
                if (Registry.CurrentUser.OpenSubKey(pathToWrite) == null)
                {
                    key = key.CreateSubKey(pathToWrite);
                }
            }
            
            return key;
        }

        //private RegistryKey Delete(RegistryKey key, string pathToDelete, string stopValue)
        //{            
        //    if (key == null)
        //    {
        //        //First time in. Path to write will be the base path.
        //        key = Registry.CurrentUser.OpenSubKey(pathToDelete, true);
        //    }
        //    else
        //    {
        //        //if (key.Name.Equals(stopValue, StringComparison.CurrentCultureIgnoreCase))
        //        //{
        //        //    key = key.DeleteSubKey();
        //        //    key = null;
        //        //}
        //        //else
        //        //{
        //        //    if (pathToDelete.LastIndexOf("\\") > -1)
        //        //    {
        //        //        string parthPart = pathToDelete.Substring(pathToDelete.LastIndexOf("\\"), pathToDelete.Length-pathToDelete.LastIndexOf("\\")
        //        //        key = key.DeleteSubKey();
        //        //    }
        //        //    else
        //        //    {
        //        //        key = null;
        //        //    }
        //        //}
        //    }

        //    return key;
        //}

        private string[] GetPathParts(string regKeyPath)
        {
            string[] pathParts = regKeyPath.Split(new char[1]{'\\'});
            if (pathParts == null)
            {
                pathParts = new string[0];
            }

            return pathParts;
        }

        #endregion

        #region Old Methods

        protected RegistryEdit(RegistryKey baseRegistryKey, RegistryKey subKey)
        {
            _baseRegistryKey = baseRegistryKey;
            _subKey = subKey;
        }

        protected string ReadKey(string KeyName)
        {
            // Opening the registry key

            RegistryKey rk = _baseRegistryKey;
            // Open a subKey as read-only

            RegistryKey sk1 = rk.OpenSubKey(_subKey.Name);
            // If the RegistrySubKey doesn't exist -> (null)

            if (sk1 == null)
            {
                return null;
            }
            else
            {
                try
                {
                    // If the RegistryKey exists I get its value

                    // or null is returned.

                    return (string)sk1.GetValue(KeyName.ToUpper());
                }
                catch (Exception ex)
                {
                    _isErrored = true;
                    _lastErrorMessage = string.Format("{0} {1}", ex.Message, "Reading registry " + KeyName.ToUpper());
                    return null;
                }
            }
        }

        protected bool WriteKey(string KeyName, object Value)
        {
            try
            {
                // Setting

                RegistryKey rk = _baseRegistryKey;
                // I have to use CreateSubKey 

                // (create or open it if already exits), 

                // 'cause OpenSubKey open a subKey as read-only

                RegistryKey sk1 = rk.CreateSubKey(_subKey.Name);
                // Save the value

                sk1.SetValue(KeyName.ToUpper(), Value);

                return true;
            }
            catch (Exception ex)
            {
                _isErrored = true;
                _lastErrorMessage = string.Format("{0} {1}", ex.Message, "Writing registry " + KeyName.ToUpper());
                return false;
            }
        }

        protected bool DeleteKey(string KeyName)
        {
            try
            {
                // Setting

                RegistryKey rk = _baseRegistryKey;
                RegistryKey sk1 = rk.CreateSubKey(_subKey.Name);
                // If the RegistrySubKey doesn't exists -> (true)

                if (sk1 == null)
                    return true;
                else
                    sk1.DeleteValue(KeyName);

                return true;
            }
            catch (Exception ex)
            {
                _isErrored = true;
                _lastErrorMessage = string.Format("{0} {1}", ex.Message, "Deleting SubKey " + _subKey);
                return false;
            }
        }

        protected bool DeleteSubKeyTree()
        {
            try
            {
                // Setting

                RegistryKey rk = _baseRegistryKey;
                RegistryKey sk1 = rk.OpenSubKey(_subKey.Name);
                // If the RegistryKey exists, I delete it

                if (sk1 != null)
                    rk.DeleteSubKeyTree(_subKey.Name);

                return true;
            }
            catch (Exception ex)
            {
                _isErrored = true;
                _lastErrorMessage = string.Format("{0} {1}", ex.Message, "Deleting SubKey " + _subKey);
                return false;
            }
        }

        protected int SubKeyCount()
        {
            try
            {
                // Setting

                RegistryKey rk = _baseRegistryKey;
                RegistryKey sk1 = rk.OpenSubKey(_subKey.Name);
                // If the RegistryKey exists...

                if (sk1 != null)
                    return sk1.SubKeyCount;
                else
                    return 0;
            }
            catch (Exception ex)
            {
                _isErrored = true;
                _lastErrorMessage = string.Format("{0} {1}", ex.Message, "Retriving subkeys of " + _subKey);
                return 0;
            }
        }

        protected int ValueCount()
        {
            try
            {
                // Setting
                RegistryKey rk = _baseRegistryKey;
                RegistryKey sk1 = rk.OpenSubKey(_subKey.Name);
                // If the RegistryKey exists...

                if (sk1 != null)
                    return sk1.ValueCount;
                else
                    return 0;
            }
            catch (Exception ex)
            {
                _isErrored = true;
                _lastErrorMessage = string.Format("{0} {1}", ex.Message, "Retriving keys of " + _subKey);
                return 0;
            }
        }

        #endregion

        #region Properties


        private bool _isErrored = false;
        public bool IsErrored
        {
            get { return _isErrored; }
            set { _isErrored = value; }
        }

        private string _lastErrorMessage = "";
        public string LastError
        {
            get { return _lastErrorMessage; }
            set { _lastErrorMessage = value; }
        }

        private RegistryKey _baseRegistryKey = null;
        public RegistryKey BaseRegistryKey
        {
            get { return _baseRegistryKey; }
            set { _baseRegistryKey = value; }
        }

        private RegistryKey _subKey = null;
        public RegistryKey SubKey
        {
            get { return _subKey; }
            set { _subKey = value; }
        }

        #endregion
    }
}
