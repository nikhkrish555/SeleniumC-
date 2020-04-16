using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SampleFrameWork1
{
    [TestClass]
    [TestCategory("Sample Application One")]
    public class SampleApplicationOneTest
    {
        private IWebDriver Driver { get; set; }
        internal User TheTestUser { get; private set; }
        internal SampleApplicationPage sampleApplicationPage { get; private set; }

        [TestInitialize]
        public void SetUp()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Driver = new ChromeDriver(path);
            TheTestUser = new User
            {
                FirstName = "Nikhil",
                LastName = "Krishna",
            };
            sampleApplicationPage = new SampleApplicationPage(Driver);
        }

        [TestMethod]
        public void TestMethod1()
        {
            TheTestUser.Gender = Gender.Male;
            sampleApplicationPage.GoTo();
            var ultimateQaHomePage = sampleApplicationPage.FillOutFormAndubmit(TheTestUser);
            Assert.IsTrue(ultimateQaHomePage.IsVisible,
                  $"Ultimate QA Home page was not visible.");
        }

        [TestMethod]
        public void TestMethod2()
        {
            TheTestUser.Gender = Gender.Other;
            sampleApplicationPage.GoTo();
            var ultimateQaHomePage = sampleApplicationPage.FillOutFormAndubmit(TheTestUser);
            Assert.IsFalse(!ultimateQaHomePage.IsVisible,
                $"Ultimate QA Home page was not visible.");
        }

        [TestCleanup]
        public void TearDown()
        {
            Driver.Close();
            Driver.Quit();
        }
    }
}
