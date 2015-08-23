using System;
using System.Collections.Generic;
using System.Text;
using LicenseUtilityLib;
using NUnit.Framework;

namespace NUnitTestLicense
{
    [TestFixture]
    public class TestRegistryEdit
    {
        [SetUp]
        public void SetUp()
        {
            //Test000 - testing initialization.
            //Setup
            //Execute        
            //Verify
            //Undo
        }

        [Test]
        public void TestRead()
        {
            //Setup
            RegistryEdit reg = new RegistryEdit();
            KeyObject keyObject = new KeyObject("firstname", "lastname", "TestCompany", "TestProductName", "1.0.0");
            string regPath = KeyUtil.BuildRegPath(keyObject);
            reg.DeleteKey(regPath, "TestCompany");
            //Execute  
            //Verify
            try 
            {
                reg.Read(null);
            }
            catch (Exception ex) { Assert.IsTrue(true, ex.Message); }
            Assert.IsNull(reg.Read(regPath)); //Non-existant reg key
            //Undo
        }

        [Test]
        public void TestWriteKey()
        {
            //Setup
            RegistryEdit reg = new RegistryEdit();
            KeyObject keyObject = new KeyObject("firstname", "lastname", "TestCompany", "TestProductName", "1.0.0");
            string regPath = KeyUtil.BuildRegPath(keyObject);
            //Execute  
            //Verify
            try
            {
                reg.WriteKey(null);
            }
            catch (Exception ex) { Assert.IsTrue(true, ex.Message); }

            Assert.IsNotNull(reg.WriteKey(regPath)); 
            //Undo
            Assert.IsTrue(reg.DeleteKey(regPath, "TestCompany"));
        }

        [Test]
        public void TestDeleteKey()
        {
            //Setup
            RegistryEdit reg = new RegistryEdit();
            KeyObject keyObject = new KeyObject("firstname", "lastname", "TestCompany", "TestProductName", "1.0.0");
            string regPath = KeyUtil.BuildRegPath(keyObject);
            Assert.IsNotNull(reg.WriteKey(regPath)); 
            //Execute  
            Assert.IsTrue(reg.DeleteKey(regPath, "TestCompany"));
            //Verify
            Assert.IsNull(reg.Read(regPath)); 
            //Undo
        }

        [Test]
        public void TestWriteValue()
        {
            //Setup
            RegistryEdit reg = new RegistryEdit();
            KeyObject keyObject = new KeyObject("firstname", "lastname", "TestCompany", "TestProductName", "1.0.0");
            string regPath = KeyUtil.BuildRegPath(keyObject);
            Assert.IsNotNull(reg.WriteKey(regPath)); 
            //Execute    
            try
            {
                reg.WriteValue(null, null, null);
            }
            catch (Exception ex) { Assert.IsTrue(true, ex.Message); }

            try
            {
                reg.WriteValue(regPath, "testkey", null);
            }
            catch (Exception ex) { Assert.IsTrue(true, ex.Message); }

            Assert.IsTrue(reg.WriteValue(regPath, "testkey", "testvalue")); 
            //Verify
            //Undo
            Assert.IsTrue(reg.DeleteKey(regPath, "TestCompany"));
        }
    }
}
