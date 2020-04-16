using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace AutomationResources
{
    public class DriverHelper : BasePage
    {
        public DriverHelper(IWebDriver driver) : base(driver) { }

        public void ClearFieldAndEnterText(By locator, string item, int defaultTimeOutInSeconds = 15)
        {
            WaitForElementToBeVisible(locator, defaultTimeOutInSeconds);
            Driver.FindElement(locator).Clear();
            Driver.FindElement(locator).SendKeys(item);
        }

        public void WaitForElementToBeVisible(By locator, int defaultTimeOutInSeconds)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(defaultTimeOutInSeconds));
                wait.Until(ExpectedConditions.ElementIsVisible(locator));
            }
            catch (ElementNotVisibleException)
            {

                throw new Exception($"Locator is not visible on the DOM  after waiting for {defaultTimeOutInSeconds}");
            }
        }
    }
}