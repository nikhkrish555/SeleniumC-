using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SeleniumUiTests
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver;
        [TestInitialize]
        public void Initialize()
        {
           driver = GetChromeDriver();
        }
        [TestMethod]
        [TestCategory("Navigation")]
        public void TestNavigationFeature()
        {
           
            driver.Navigate().GoToUrl("http://www.ultimateqa.com");
            driver.Navigate().Forward();
            driver.Navigate().Back();
            driver.Navigate().Refresh();
        }
        
        [TestMethod]
        [TestCategory("Driver Interrogation")]
        public void TestDriverInterrogation()
        {
            driver.Navigate().GoToUrl("https://www.ultimateqa.com/automation");
            string x = driver.CurrentWindowHandle;
            Console.WriteLine("Current Window Handle: ", x);
            var y = driver.WindowHandles;
            Console.WriteLine(y[0]);
            var z = driver.PageSource.Contains("div");
            var a = driver.Title;
            var b = driver.Url;
        }

        [TestMethod]
        [TestCategory("Element Interrogation")]
        
        public void TestElementInterrogation()
        {
            driver.Navigate().GoToUrl("https://www.ultimateqa.com/automation/");
            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //problems with implicit wait
            //1. Even if element is present on DOM if the element is hiddent, it will fail to find the element.
            //2. It applies to all the elements. It is a global setting.

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.IgnoreExceptionTypes(typeof(ElementClickInterceptedException));
            wait.Message = "Unable to find element after waiting for 15 seconds";
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a[href='../complicated-page']")));
            var webElement = driver.FindElement(By.CssSelector("a[href='../complicated-page']"));
            Console.WriteLine(webElement.Displayed);

        }
        private IWebDriver GetChromeDriver()
        {
            var outputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outputDirectory);
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
