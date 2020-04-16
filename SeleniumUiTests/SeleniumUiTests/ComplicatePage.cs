using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using System;

namespace SeleniumUiTests
{
    internal class ComplicatePage
    {
        By skillImprovedTextLocator = By.CssSelector("span[id=Skills_Improved]");
        By searchFieldLocator = By.XPath("(//label[@class='screen-reader-text']/following-sibling::input)[1]");
        By searchButtonLocator = By.XPath("(//label[@class='screen-reader-text']/following-sibling::input[@type='submit'])[1]");
        
        public ComplicatePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        internal void Open()
        {
            Driver.Navigate().GoToUrl("https://www.ultimateqa.com/complicated-page/");
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(skillImprovedTextLocator));
        }

        internal string getTitle()
        {
            return Driver.Title;

        }

        internal void Search(string searchText)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(searchFieldLocator));
            Driver.FindElement(searchFieldLocator).SendKeys(searchText);
            Driver.FindElement(searchButtonLocator).Click();
        }
    }
}