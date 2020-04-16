using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32;
using OpenQA.Selenium;
using System;

namespace SampleFrameWork1
{
    internal class SampleApplicationPage : BaseSampleApplicationPage
    {
        public SampleApplicationPage(IWebDriver driver) : base(driver) { }
        private string PageTitle => "Sample Application Lifecycle";
        public IWebElement MaleGenderRadioButton => Driver.FindElement(By.XPath("//input[@value='male']"));
        public IWebElement FemaleGenderRadioButton => Driver.FindElement(By.XPath("//input[@value='female']"));
        public IWebElement OtherGenderRadioButton => Driver.FindElement(By.XPath("//input[@value='other']"));
        public IWebElement FirstNameField => Driver.FindElement(By.Name("firstname"));
        public IWebElement SubmitFormButton => Driver.FindElement(By.CssSelector("form > input[type='submit']"));
        public IWebElement LastNameField => Driver.FindElement(By.Name("lastname"));
        public bool IsVisible => Driver.Title.Contains(PageTitle);

        internal void GoTo()
        {
            Driver.Navigate().GoToUrl("https://ultimateqa.com/sample-application-lifecycle-sprint-3");
            Assert.IsTrue(IsVisible, 
                $"Sample Application page was not visible. Expected=> {PageTitle} " +
                $"Actual=>{Driver.Title}");

        }
        internal UltimateQaHomePage FillOutFormAndubmit(User user)
        {
            SetGender(user);
            FirstNameField.Clear();
            FirstNameField.SendKeys(user.FirstName);
            LastNameField.Clear();
            LastNameField.SendKeys(user.LastName);
            SubmitFormButton.Submit();
            return new UltimateQaHomePage(Driver);
        }

        private void SetGender(User user)
        {
            switch (user.Gender)
            {
                case Gender.Male:
                    MaleGenderRadioButton.Click();
                    break;
                case Gender.Female:
                    FemaleGenderRadioButton.Click();
                    break;
                case Gender.Other:
                    OtherGenderRadioButton.Click(); 
                    break;
                default:
                    break;
            }
        }
    }
}