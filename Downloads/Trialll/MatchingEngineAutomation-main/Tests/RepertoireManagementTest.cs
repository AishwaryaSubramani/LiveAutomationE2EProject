using NUnit.Framework;
using OpenQA.Selenium;
using MatchingEngineAutomation.Drivers;
using MatchingEngineAutomation.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace MatchingEngineAutomation.Tests
{
    public class RepertoireManagementTest
    {
        private IWebDriver driver;
        private RepertoireManagementPage.Actions pageActions;
        private WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            driver = WebDriverFactory.CreateDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var page = new RepertoireManagementPage(driver, wait);
            pageActions = new RepertoireManagementPage.Actions(page);
        }

        [Test]
        public void ValidateSupportedProducts()
        {
            pageActions.GoToRepertoireManagementPage();
            pageActions.NavigateToRepertoireModule();
            pageActions.ScrollToAdditionalFeatures();
            pageActions.ClickProductsSupported();
            pageActions.AssertProductHeadingVisible();

            string[] expectedProducts = { "Cue Sheet", "Recording", "Bundle", "Advertisement" };
            foreach (var product in expectedProducts)
            {
                pageActions.AssertProductVisible(product);
            }
        }

        [TearDown]
        public void Teardown()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
                driver = null!;
            }
        }
    }
}
