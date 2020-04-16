using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;

namespace SeleniumUiTests
{

    [TestClass]
    [TestCategory("TDD Practice")]
    public class TDDPractice
    {
        IWebDriver driver;

        [TestInitialize]
        public void Before()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            driver = new ChromeDriver(path);
        }

        [TestMethod]
        public void TestComplicatedPage()
        {
            var complicatedPage = new ComplicatePage(driver);
            complicatedPage.Open();
            Assert.AreEqual("Complicated Page - Ultimate QA", complicatedPage.getTitle());
            complicatedPage.Search("Books");
        }

        [TestCleanup]
        public void After()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
