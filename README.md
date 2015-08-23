# LicenseLib.NET
Simple and easy licensing framework for your .NET projects. 
Nothing clever, it just keeps honest people honest. 

If you need an easy way to license a .NET Windows Forms application, 
but don't want to pay the large fees expected from the .NET licensing 
companies, LicenseLib.NET might be for you.

How to use LicenseLib.NET
-------------------------

STEP 1: Download all files and create your Visual Studio solution.

Download each project folder.  Create a blank Visual Studio solution,
and add each project to this solution.  Look in LicenseApp --> files
for an xlsx spreadsheet containing diagrams of the project heirarchy.

Here is a brief explanation:

LicenseLib: Contains the core methods to create and verify a registry key 
is installed, verify if the key has expired, and remove a key.

LicenseUtilityLib: Does the actual registry editing.  

LicenseApp: Windows Forms application to create and verify a key can be used.

CodeGenLib: License code hashing and salting.

TestLicense: Small Windows Forms application to test method calls.  

NUnitTestLicense:  NUnit project to Unit Test core license method calls.

