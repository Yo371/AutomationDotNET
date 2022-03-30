using AutomationFramework.PageObjects.PageParts;
using AutomationFramework.Utils;
using OpenQA.Selenium;

namespace AutomationFramework.PageObjects
{
    interface ICloudGoogleCalculatorPage
    {
        IWebElement FrameCalculator { get; }

        IWebElement FrameInsideFrameCalculator { get; }

        ICalculatorPart CalculatorPart { get; }

        void SwitchToFrame(IWebElement framWebElement);

        void OpenPage();
    }

    internal class CloudGoogleCalculatorPage : PageBase, ICloudGoogleCalculatorPage
    {
        protected static string url = "https://cloud.google.com/products/calculator";

        public IWebElement FrameCalculator =>
            Browser.FindElement(By.XPath("//*[@id='cloud-site']/devsite-iframe/iframe"));

        public IWebElement FrameInsideFrameCalculator =>
            Browser.FindElement(By.XPath("//*[@id='myFrame']"));

        public ICalculatorPart CalculatorPart =>
            ObjectFactory.Get<ICalculatorPart>("//*[@class='compute-engine-block']");

        public CloudGoogleCalculatorPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public void OpenPage()
        {
            Browser.Navigate().GoToUrl(url);
        }
    }
}