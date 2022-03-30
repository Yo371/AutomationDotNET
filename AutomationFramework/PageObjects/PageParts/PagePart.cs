using AutomationFramework.Utils;
using OpenQA.Selenium;

namespace AutomationFramework.PageObjects.PageParts
{
    internal class PagePart 
    {
        protected IWebDriver Browser;
        public static int LoadTimeout = 10000;

        public PagePart(IWebDriver webDriver)
        {
            Browser = webDriver;
        }
    }
}
