using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace MatchingEngineAutomation.Utilities
{
    public static class WaitHelpers
    {
        public static IWebElement WaitForElementVisible(IWebDriver driver, By locator, int seconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }
    }
}
