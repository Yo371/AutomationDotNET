using AutomationFramework.Utils;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationFramework.Tests
{
    class GoogleCalculatorBadExampleTest : BaseTest
    {
        private IWebDriver _browser = BrowserFactory.Instance;

        [OneTimeSetUp]
        public void OpenBrowser()
        {
            _browser.Navigate().GoToUrl("https://cloud.google.com/products/calculator");

            Wait.For(() => _browser.FindElement(By.XPath("//*[@id='cloud-site']/devsite-iframe/iframe")).Displayed);

            _browser.SwitchTo().Frame(_browser.FindElement(By.XPath("//*[@id='cloud-site']/devsite-iframe/iframe")));
            _browser.SwitchTo().Frame(_browser.FindElement(By.XPath("//*[@id='myFrame']")));
        }

        [Test]
        public void VerifyEnablingButtonOnInstancesArea()
        {
            _browser.FindElement(By.XPath(".//*[@id='input_81']")).SendKeys("2");

            _browser.FindElement(By.XPath(".//*[@id = 'select_106']")).Click();

            Thread.Sleep(2000);

            _browser.FindElement(
                By.XPath("//*[@id = 'select_option_222']//div[contains(text(), 'N2')]")).Click();

            Assert.IsTrue(_browser.FindElement(By.XPath(".//button[@aria-label='Add to Estimate']")).Enabled);

            Thread.Sleep(2000);
        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            _browser.Close();
        }
    }
}
