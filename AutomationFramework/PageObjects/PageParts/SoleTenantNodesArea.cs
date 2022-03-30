using OpenQA.Selenium;

namespace AutomationFramework.PageObjects.PageParts
{
    interface ISoleTenantNodesArea
    {
        IWebElement NumberOfNodes {get; }
        IWebElement AddGpuCheckbox { get; }
        IWebElement GpuType { get; }
        IWebElement GpuNumber { get; }
        IWebElement AddToEstimateButton { get; }
    }

    internal class SoleTenantNodesArea : PagePart, ISoleTenantNodesArea
    {
        private IWebElement _webElementContainer;

        public IWebElement NumberOfNodes => _webElementContainer.FindElement(By.XPath(".//*[@id='input_123']"));

        public IWebElement AddGpuCheckbox =>
            _webElementContainer.FindElement(By.XPath(".//md-checkbox[@ng-model='listingCtrl.soleTenant.addGPUs']"));

        public IWebElement GpuType =>
            _webElementContainer.FindElement(By.XPath(".//md-select[@ng-model='listingCtrl.soleTenant.gpuType']"));

        public IWebElement GpuNumber =>
            _webElementContainer.FindElement(By.XPath(".//md-select[@ng-model='listingCtrl.soleTenant.gpuCount']"));

        public IWebElement AddToEstimateButton =>
            _webElementContainer.FindElement(By.XPath(".//button[@aria-label='Add to Estimate']"));

        public SoleTenantNodesArea(string selector, IWebDriver webDriver) : base(webDriver)
        {
            _webElementContainer = Browser.FindElement(By.XPath(selector));
        }
    }
}
