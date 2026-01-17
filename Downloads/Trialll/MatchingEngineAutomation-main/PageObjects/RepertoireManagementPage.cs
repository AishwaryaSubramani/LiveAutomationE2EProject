using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using NUnit.Framework;
using MatchingEngineAutomation.Utilities;


namespace MatchingEngineAutomation.PageObjects
{

    public class RepertoireManagementPage
    {
        internal readonly IWebDriver driver;
        internal readonly WebDriverWait wait;

        public RepertoireManagementPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        internal string Url => "https://www.matchingengine.com/";

        // Elements (accessed only through waits in actions)
        internal By ModulesMenu => By.XPath("//a[contains(text(), 'Modules')]");
        internal By RepertoireModule => By.LinkText("Repertoire Management Module");
        internal By AdditionalFeatures => By.XPath("//h2[contains(text(), 'Additional Features')]");
        internal By ProductsSupported => By.XPath("//span[contains(text(), 'Products Supported')]/parent::a");
        internal By ProductHeading => By.XPath("//h3[contains(text(), 'There are several types of Product Supported')]");
        internal By ProductItem(string productName) => By.XPath($"//*[contains(text(), '{productName}')]");

        public class Actions
        {
            private readonly RepertoireManagementPage page;

            public Actions(RepertoireManagementPage page)
            {
                this.page = page;
            }

            public void GoToRepertoireManagementPage()
            {
                page.driver.Navigate().GoToUrl(page.Url);
                page.wait.Until(driver => driver.Url.Contains("matchingengine.com"));
            }

            public void NavigateToRepertoireModule()
            {
                var modules = page.wait.Until(driver => driver.FindElement(page.ModulesMenu));
                var action = new OpenQA.Selenium.Interactions.Actions(page.driver);
                action.MoveToElement(modules).Perform();

                var repModule = page.wait.Until(driver => driver.FindElement(page.RepertoireModule));
                repModule.Click();
            }

            public void ScrollToAdditionalFeatures()
            {
                var element = page.wait.Until(driver => driver.FindElement(page.AdditionalFeatures));
                ((IJavaScriptExecutor)page.driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            }

            public void ClickProductsSupported()
            {
                var productsTab = page.wait.Until(driver => driver.FindElement(page.ProductsSupported));
                productsTab.Click();
            }

            
            public void AssertProductHeadingVisible()
{
    WebDriverWait wait = new WebDriverWait(page.driver, TimeSpan.FromSeconds(10));
    var heading = wait.Until(d =>
    {
        var el = d.FindElement(By.XPath("//h3[contains(text(), 'There are several types of Product Supported:')]"));
        return el.Displayed ? el : null;
    });

    heading.ShouldBeVisible("Heading for supported products not visible.");
}


            public void AssertProductVisible(string productName)
            {
                var item = page.wait.Until(driver => driver.FindElement(page.ProductItem(productName)));
                Assert.IsTrue(item.Displayed, $"Product '{productName}' is not visible.");
            }
        }
    }
}
