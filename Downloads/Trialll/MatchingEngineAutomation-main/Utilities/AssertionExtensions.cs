using NUnit.Framework;
using OpenQA.Selenium;

namespace MatchingEngineAutomation.Utilities
{
    public static class AssertionExtensions
    {

        public static void ShouldBeVisible(this IWebElement element, string message)
        {
            Assert.IsTrue(element.Displayed, message);
        }

        public static void ShouldBeEnabled(IWebElement element, string message)
        {
            Assert.IsTrue(element.Enabled, message);
        }

        public static void ShouldBeAtUrl(IWebDriver driver, string expectedUrl, string message)
        {
            Assert.That(driver.Url, Is.EqualTo(expectedUrl), message);
        }
    }
}
