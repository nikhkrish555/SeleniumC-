using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SampleFrameWork1
{
    internal class UltimateQaHomePage : BaseSampleApplicationPage
    {
        public UltimateQaHomePage(IWebDriver driver) : base(driver) { }

        public bool IsVisible
        {
            get
            {
                try
                {
                    WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
                    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1[text()='Master Test Automation Today']")));
                    return StartHereButton.Displayed;
                }
                catch (NoSuchElementException)
                {

                    return false;
                }

            }
            internal set { }
        }

        public IWebElement StartHereButton => Driver.FindElement(By.XPath("//a[text()='Master Automation With Selenium']"));
           
    }
}