using AutomationFramework.PageObjects;
using AutomationFramework.PageServices;
using AutomationFramework.Utils;

namespace AutomationFramework.Tests
{
    internal class BaseTest
    {
        public ICloudGoogleCalculatorPage CalculatorPage => ObjectFactory.Get<ICloudGoogleCalculatorPage>();

        public ICalculatorService CalculatorService => ObjectFactory.Get<ICalculatorService>();

        protected string N2Standard4 = "n2-standard-4";
        protected string SeriesN2 = "N2";
        protected string BelgiumLocation = "Belgium";
        protected string two = "2";
        protected string eight = "8";

        protected string NVIDIATeslaV100 = "NVIDIA Tesla V100";
    }
}
