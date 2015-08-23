using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using LicenseLib;
using LicenseUtilityLib;
using CodeGenLib;


namespace NUnitTestLicense
{
    [TestFixture]
    public class TestLicenseKey
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
            CodeGen gen = new CodeGen();
            string name = "Test User";
            string keyCode = gen.CreateKey(name, 30);//30-day expiration key
            KeyObject key = new KeyObject(name, keyCode, "Test Company", "Test Product", "1.0.0");
            LicenseKey.UninstallKey(key);
            //Execute        
            Assert.IsFalse(LicenseKey.IsKeyInstalled(null));
            Assert.IsFalse(LicenseKey.IsKeyInstalled(key)); //A key, but has not been installed
            Assert.IsTrue(LicenseKey.InstallKey(key));            
            //Verify
            Assert.IsTrue(LicenseKey.IsKeyInstalled(key));
            //Undo
            Assert.IsTrue(LicenseKey.UninstallKey(key));
        }

        [Test]
        public void TestInstallKey()
        {
            //Setup
            CodeGen gen = new CodeGen();
            string name = "Test User";
            string keyCode = gen.CreateKey(name, 30);//30-day expiration key
            KeyObject key = new KeyObject(name, keyCode, "Test Company", "Test Product", "1.0.0");
            LicenseKey.UninstallKey(key);
            Assert.IsFalse(LicenseKey.IsKeyInstalled(key)); //Make sure key is not installed.
            //Execute       
            Assert.IsTrue(LicenseKey.InstallKey(key));
            //Verify
            Assert.IsTrue(LicenseKey.IsKeyInstalled(key));
            //Undo
            Assert.IsTrue(LicenseKey.UninstallKey(key));
        }

        [Test]
        public void TestUninstallKey()
        {
            //Setup
            CodeGen gen = new CodeGen();
            string name = "Test User";
            string keyCode = gen.CreateKey(name, 30);//30-day expiration key
            KeyObject key = new KeyObject(name, keyCode, "Test Company", "Test Product", "1.0.0");
            LicenseKey.InstallKey(key);
            Assert.IsTrue(LicenseKey.IsKeyInstalled(key)); //Make sure key is installed.
            //Execute       
            Assert.IsTrue(LicenseKey.UninstallKey(key));
            //Verify
            Assert.IsFalse(LicenseKey.IsKeyInstalled(key));
            //Undo
        }

        [Test]
        public void TestIsKeyCodeValid()
        {
            //Setup
            CodeGen gen = new CodeGen();
            string name = "Test User";
            string keyCode = gen.CreateKey(name, 30);//30-day expiration key
            KeyObject key = new KeyObject(name, keyCode, "Test Company", "Test Product", "1.0.0");
            LicenseKey.InstallKey(key);
            Assert.IsTrue(LicenseKey.IsKeyInstalled(key)); //Make sure key is installed.
            //Execute       
            Assert.IsTrue(LicenseKey.IsKeyCodeValid(key.Name, key.Key));
            //Verify
            //Undo
            Assert.IsTrue(LicenseKey.UninstallKey(key));
        }

        [Test]
        public void TestIsKeyExpired()
        {
            //Setup
            CodeGen gen = new CodeGen();
            string name = "Test User";
            string keyCode = gen.CreateKey(name, 30);//30-day expiration key
            KeyObject key = new KeyObject(name, keyCode, "Test Company", "Test Product", "1.0.0");
            LicenseKey.InstallKey(key);
            Assert.IsTrue(LicenseKey.IsKeyInstalled(key)); //Make sure key is installed.
            //Execute       
            Assert.IsFalse(LicenseKey.IsKeyExpired(key));
            //Verify
            //Undo
            Assert.IsTrue(LicenseKey.UninstallKey(key));
        }

        [Test]
        public void TestGetDaysRemaining()
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
            Assert.IsTrue(LicenseKey.GetDaysRemaining(key) == 29);//Is 29 instead of 30 since time remaining is less than exactly 30 days.
            //Undo
            Assert.IsTrue(LicenseKey.UninstallKey(key));
        }

        [Test]
        public void TestGetInstalledKey()
        {
            //Setup
            CodeGen gen = new CodeGen();
            string name = "Test User";
            string keyCode = gen.CreateKey(name, 30);//30-day expiration key
            KeyObject key = new KeyObject(name, keyCode, "Test Company", "Test Product", "1.0.0");
            LicenseKey.UninstallKey(key);
            Assert.IsTrue(LicenseKey.InstallKey(key));
            Assert.IsTrue(LicenseKey.IsKeyInstalled(key)); //Make sure key is not installed.
            //Execute       
            KeyObject installedKey = LicenseKey.GetInstalledKey("Test Company", "Test Product", "1.0.0");
            //Verify
            Assert.IsTrue(installedKey.Name == name);
            Assert.IsTrue(installedKey.Key == keyCode);
            //Undo
            Assert.IsTrue(LicenseKey.UninstallKey(key));
        }

    }
}
