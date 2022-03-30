using AutomationFramework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationFramework.PageObjects
{
    internal class PageBase
    {

        protected IWebDriver Browser;
        public static int LoadTimeout = 3000;

        public PageBase(IWebDriver webDriver)
        {
            Browser = webDriver;
        }

        public PageBase()
        {
            Browser = BrowserFactory.Instance;
        }

        public void SwitchToFrame(IWebElement framWebElement)
        {
            Wait.For(() => framWebElement.Displayed, LoadTimeout);
            Browser.SwitchTo().Frame(framWebElement);
        }

    }
}
