using System;
using System.IO;
using System.Reflection;
using AutomationResources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SampleApp2
{
    [TestClass]
    [TestCategory("SearchingFeature")]
    public class SearchFunctionality : BaseTest
    {
        [TestMethod]
        [Description("Checks to make sure that if we search for an item, that item comes back")]
        [TestProperty("Author","NikhilKrishna")]
        public void TCID1()
        {
            Homepage homePage = new Homepage(Driver);
            homePage.GoTo();
            SearchPage searchPage = homePage.Search("blouse");
            Assert.IsTrue(searchPage.Contains(Item.BLOUSE));

        }
    }
}
