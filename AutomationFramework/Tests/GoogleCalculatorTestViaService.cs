using AutomationFramework.Utils;
using NUnit.Framework;

namespace AutomationFramework.Tests
{
    internal class GoogleCalculatorTestViaService : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            CalculatorPage.OpenPage();
            CalculatorService.SwitchToCalculatorFrame();
        }

        [Test]
        public void VerifyEnablingButtons()
        {
            CalculatorService.FillInstanceArea(2, SeriesN2, N2Standard4, BelgiumLocation);

            Assert.IsTrue(CalculatorPage.CalculatorPart.InstancesArea.AddToEstimateButton.Enabled, "Add to Estimate button isn't enabled");

            CalculatorService.FillSoleTenantArea(2, GpuFactory.GetNVIDIAV100Gpu());

            Assert.IsTrue(CalculatorPage.CalculatorPart.SoleTenantNodesArea.AddToEstimateButton.Enabled, "Add to Estimate button isn't enabled");
        }

        [TearDown]
        public void CloseBrowser()
        {
            BrowserFactory.CloseBrowser();
        }
    }
}
