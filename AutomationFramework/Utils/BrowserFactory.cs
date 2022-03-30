using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace AutomationFramework.Utils
{
    class BrowserFactory
    {
        private static readonly ThreadLocal<IWebDriver> WebDriver = new();

        public static IWebDriver Instance => WebDriver.Value ?? SetUpBrowser();

        private static IWebDriver SetUpBrowser()
        {
            IWebDriver driver;
            switch (PropertiesReader.GetProperty("BrowserType", "Properties.xml"))
            {
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
                case "FireFox":
                    driver = new FirefoxDriver();
                    break;
                case "IE":
                    driver = new EdgeDriver();
                    break;
                default: throw new ArgumentException();
            }

            var pageLoadTimeout = int.Parse(PropertiesReader.GetProperty("PageLoadTimeOutMs", "Properties.xml"));

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromMilliseconds(pageLoadTimeout);
            WebDriver.Value = driver;
            return driver;
        }

        public static void CloseBrowser()
        {
            WebDriver.Value?.Quit();
            WebDriver.Value = null;
        }
    }
}