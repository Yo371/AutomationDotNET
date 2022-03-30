using OpenQA.Selenium;

namespace AutomationFramework.PageObjects.PageParts
{
    interface IInstancesArea
    {
         IWebElement Instances { get; }

         IWebElement MachineType { get; }
         IWebElement Series { get; }

         IWebElement DataCenterLocation { get; }

         IWebElement AddToEstimateButton { get; }
    }

    internal class InstancesArea : PagePart, IInstancesArea
    {
        private IWebElement _webElementContainer;

        public IWebElement Instances => _webElementContainer.FindElement(By.XPath(".//*[@id='input_77']"));

        public IWebElement MachineType => _webElementContainer.FindElement(By.XPath(".//*[@id = 'select_104']"));

        public IWebElement Series => _webElementContainer.FindElement(By.XPath(".//*[@id = 'select_102']"));

        public IWebElement DataCenterLocation => _webElementContainer.FindElement(By.XPath(".//*[@id = 'select_110']"));

        public IWebElement AddToEstimateButton =>
            _webElementContainer.FindElement(By.XPath(".//button[@aria-label='Add to Estimate']"));

        public InstancesArea(string selector, IWebDriver webDriver) : base(webDriver)
        {
            _webElementContainer = Browser.FindElement(By.XPath(selector));
        }
    }
}
