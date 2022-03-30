using AutomationFramework.Utils;
using OpenQA.Selenium;

namespace AutomationFramework.PageObjects.PageParts
{
    interface ICalculatorPart
    { 
        IInstancesArea InstancesArea { get; }
        
        ISoleTenantNodesArea SoleTenantNodesArea { get; }

        void SelectItem(IWebElement webElement, string option);
    }

    internal class CalculatorPart : PagePart, ICalculatorPart
    {
        private IWebElement _webElementContainer;

        public IInstancesArea InstancesArea => ObjectFactory.Get<IInstancesArea>(".//form[@name='ComputeEngineForm']");

        public ISoleTenantNodesArea SoleTenantNodesArea => ObjectFactory.Get<ISoleTenantNodesArea>(".//form[@name='SoleTenantForm']");

        public CalculatorPart(string selector, IWebDriver webDriver) : base(webDriver)
        {
            _webElementContainer = Browser.FindElement(By.XPath(selector));
        }
        
        public void SelectItem(IWebElement webElement, string option)
        {
            webElement.Click();
            var id = webElement.GetAttribute("aria-owns");

            Wait.ABit();

            Browser.FindElement(
                By.XPath($"//*[@id = '{id}']//md-select-menu//md-option//div[contains(text(), '{option}')]")).Click();
        }
    }
}
