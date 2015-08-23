using System;
using System.Collections.Generic;
using System.Text;
using LicenseUtilityLib;
using LicenseLib;
using CodeGenLib;
using NUnit.Framework;

namespace NUnitTestLicense
{
    [TestFixture]
    public class TestKeyUtil
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
        public void TestIsKeyInstalled()
        {
            //Setup
            KeyObject key = new KeyObject("TestName", "SAMPLEKEYCODE", "TestCompany", "TestProductName", "1.0.0");
            KeyUtil.UninstallKey(key);//Make sure key is uninstalled.
            //Execute  
            Assert.IsFalse(KeyUtil.IsKeyInstalled(null));
            Assert.IsFalse(KeyUtil.IsKeyInstalled(key)); //A key, but it is not installed.
            Assert.IsTrue(KeyUtil.InstallKey(key));
            //Verify
            Assert.IsTrue(KeyUtil.IsKeyInstalled(key)); //Key should have already been installed.
            //Undo
            Assert.IsTrue(KeyUtil.UninstallKey(key)); 
        }

        [Test]
        public void TestInstallKey()
        {
            //Setup
            KeyObject key = new KeyObject("TestName", "SAMPLEKEYCODE", "TestCompany", "TestProductName", "1.0.0");
            KeyUtil.UninstallKey(key);//Make sure key is uninstalled.
            //Execute        
            Assert.IsTrue(KeyUtil.InstallKey(key));
            //Verify
            //Undo
            Assert.IsTrue(KeyUtil.UninstallKey(key)); 
        }

        [Test]
        public void TestUnInstallKey()
        {
            //Setup
            KeyObject key = new KeyObject("TestName", "SAMPLEKEYCODE", "TestCompany", "TestProductName", "1.0.0");
            KeyUtil.InstallKey(key);//Make sure key is installed.
            //Execute    
            Assert.IsTrue(KeyUtil.UninstallKey(key)); 
            //Verify
            //Undo
        }

        [Test]
        public void TestGetExpireDate()
        {
            //Setup
            CodeGen gen = new CodeGen();
            string name = "Test User";
            string keyCode = gen.CreateKey(name, 30);//30-day expiration key
            KeyObject key = new KeyObject(name, keyCode, "Test Company", "Test Product", "1.0.0");
            LicenseKey.InstallKey(key);
            Assert.IsTrue(LicenseKey.IsKeyInstalled(key)); //Make sure key is installed.
            //Execute      
            //Verify
            Assert.IsTrue(KeyUtil.GetExpireDate(key).ToShortDateString() == DateTime.Now.AddDays(30).ToShortDateString());
            //Undo
            Assert.IsTrue(KeyUtil.UninstallKey(key)); 
        }

        [Test]
        public void TestGetInstalledKey()
        {
            CodeGen gen = new CodeGen();
            string name = "Test User";
            string keyCode = gen.CreateKey(name, 30);//30-day expiration key
            KeyObject key = new KeyObject(name, keyCode, "Test Company", "Test Product", "1.0.0");
            LicenseKey.InstallKey(key);
            Assert.IsTrue(LicenseKey.IsKeyInstalled(key)); //Make sure key is installed.
            //Execute    
            KeyObject installedKey = KeyUtil.GetInstalledKey("Test Company", "Test Product", "1.0.0");
            //Verify
            Assert.IsTrue(installedKey.Name == name);
            Assert.IsTrue(installedKey.Key == keyCode);
            //Undo
            Assert.IsTrue(KeyUtil.UninstallKey(key)); 
        }
    }
}
