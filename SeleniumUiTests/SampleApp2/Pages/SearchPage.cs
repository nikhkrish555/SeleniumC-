using OpenQA.Selenium;
using System;
using AutomationResources;

namespace SampleApp2
{
    internal class SearchPage : AutomationResources.BasePage
    {
        public SearchPage(IWebDriver driver) : base(driver) { }
        private readonly By SearchResultBlouseTextLocator = By.XPath("//*[@title='Blouse']");

        internal bool Contains(Item item)
        {
            DriverHelper driverHelper = new DriverHelper(Driver);
            driverHelper.WaitForElementToBeVisible(SearchResultBlouseTextLocator, 10);
            switch (item)
            {
                case Item.BLOUSE:
                    return Driver.FindElement(SearchResultBlouseTextLocator).Displayed;
                default:
                    throw new ArgumentOutOfRangeException("No such item exists in this collection");
            }
        }
    }
}