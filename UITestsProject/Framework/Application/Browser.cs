using OpenQA.Selenium;
using Framework.Logging;
using Framework.Waits;
using Framework.Constants;
using Framework.Factories;

namespace Framework.Application
{
    public class Browser
    { 
        public ExplicitWait ExplicitWait { get; private set; }

        private IWebDriver ? _driver;
        [ThreadStatic] private static Browser? _browserInstance;

        private Browser() 
        {
        }

        public IWebDriver GetDriver() 
        {
            FrameworkLogger.Info("Getting instance of IWebDriver...");
            if (_driver != null) return _driver;
            _driver = new GeneralDriverFactory().CreateDriver();
            ManageDriverDefaultSettings(_driver);
            ExplicitWait = new ExplicitWait(_driver);
            return _driver;
        }

        public static Browser GetInstance() 
        {
            if (_browserInstance != null) return _browserInstance;
            if (_browserInstance == null)
            {
                _browserInstance = new Browser();
            }
            return _browserInstance;
        }

        private void ManageDriverDefaultSettings(IWebDriver driver)
        {
            FrameworkLogger.Info("Manage default WebDriver settings");
            if (DriverConfigurations.WindowWidth != 0 && DriverConfigurations.WindowHeight != 0) 
            {
                driver.Manage().Window.Size = new System.Drawing.Size(DriverConfigurations.WindowWidth, DriverConfigurations.WindowHeight);
            } else driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad.Add(TimeSpan.FromSeconds(DriverConfigurations.PageLoadTimeOut));
        }
    }
}
