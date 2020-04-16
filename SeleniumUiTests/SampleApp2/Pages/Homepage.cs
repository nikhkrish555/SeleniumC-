using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using AutomationResources;

namespace SampleApp2
{
    internal class Homepage : BasePage
    {
        private By searchFieldLocator = By.Id("search_query_top");
        private By submitButtonLocator = By.Name("submit_search");

        public Homepage(IWebDriver driver) : base(driver) { }

        public bool IsLogoVisible
        {
            get
            {
                try
                {
                    return Driver.FindElement(By.Id("header_logo")).Displayed;
                }
                catch (NoSuchElementException)
                {

                    return false;
                }
            }
            set { }
         }

        internal void GoTo()
        {
            Driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            Assert.IsTrue(IsLogoVisible, "Expected Result: Logo displayed status to be True\n" +
                $"Actual Result: Logo displayed status is {IsLogoVisible}");
        }

        internal SearchPage Search(string item)
        {
            DriverHelper driverHelper = new DriverHelper(Driver);
            driverHelper.ClearFieldAndEnterText(searchFieldLocator, item, 10);
            Driver.FindElement(submitButtonLocator).Click();
            return new SearchPage(Driver);
        }
    }
}
