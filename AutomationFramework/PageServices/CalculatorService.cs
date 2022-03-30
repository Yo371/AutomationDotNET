using AutomationFramework.BuisnessObjects;
using AutomationFramework.PageObjects;
using AutomationFramework.Utils;
using OpenQA.Selenium;

namespace AutomationFramework.PageServices
{
    interface ICalculatorService
    {
        void SwitchToCalculatorFrame();
        void FillInstanceArea(int amountOfInstances, string series, string machineType, string location);
        void FillSoleTenantArea(int amountOfNodes, GPU gpu);
        void AddGpu(GPU gpu);
    }
    internal class CalculatorService : ICalculatorService
    {
        protected IWebDriver Browser;

        private ICloudGoogleCalculatorPage _calculatorPage;

        public CalculatorService(IWebDriver browser, ICloudGoogleCalculatorPage calculatorPage)
        {
            Browser = browser;
            _calculatorPage = calculatorPage;
        }

        public void SwitchToCalculatorFrame()
        {
            _calculatorPage.SwitchToFrame(_calculatorPage.FrameCalculator);
            _calculatorPage.SwitchToFrame(_calculatorPage.FrameInsideFrameCalculator);
        }

        public void FillInstanceArea(int amountOfInstances, string series, string machineType, string location)
        {
            var instanceArea = _calculatorPage.CalculatorPart.InstancesArea;

            instanceArea.Instances.SendKeys(amountOfInstances.ToString());
            _calculatorPage.CalculatorPart.SelectItem(instanceArea.Series, series);
            _calculatorPage.CalculatorPart.SelectItem(instanceArea.MachineType, machineType);
            _calculatorPage.CalculatorPart.SelectItem(instanceArea.DataCenterLocation, location);
        }

        public void FillSoleTenantArea(int amountOfNodes, GPU gpu)
        {
            _calculatorPage.CalculatorPart.SoleTenantNodesArea.NumberOfNodes.SendKeys(amountOfNodes.ToString());
            _calculatorPage.CalculatorPart.SoleTenantNodesArea.AddGpuCheckbox.Click();
            AddGpu(gpu);
        }

        public void AddGpu(GPU gpu)
        {
            var soleTenantArea = _calculatorPage.CalculatorPart.SoleTenantNodesArea;
            Wait.For(() => soleTenantArea.GpuType.Displayed, 3000);
            _calculatorPage.CalculatorPart.SelectItem(soleTenantArea.GpuType, gpu.GpuType);
            _calculatorPage.CalculatorPart.SelectItem(soleTenantArea.GpuNumber, gpu.Amount.ToString());
        }
    }
}
