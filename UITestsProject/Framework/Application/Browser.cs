using Framework.Enums;
using Framework.Utils;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using WebDriverManager;
using OpenQA.Selenium.Chrome;
using Framework.Logging;
using System.ComponentModel;
using Framework.Waits;

namespace Framework.Application
{
    public class Browser
    {
        public int PageLoadTimeOut { get; set; } = 60;
        public ExplicitWait ExplicitWait { get; private set; }

        private IWebDriver ?_driver;
        private const string BrowserKey = "Browser";
        private const string ChromeOptionsKey = "ChromeOptions";
        private static Browser? _browserInstance;
        private static readonly object _syncRoot = new();

        private Browser() 
        {
        }

        public IWebDriver GetDriver() 
        {
            FrameworkLogger.Info("Getting instance of IWebDriver...");
            if (_driver != null) return _driver;
            var driverName = FrameworkJsonUtil.GetValueFromAppettingsFile<string>(BrowserKey);
            switch (FrameworkEnumUtil.ConvertStringToEnum<DriversEnum>(driverName)) 
            {
                case DriversEnum.Chrome:
                    ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
                    //chromeDriverService.SuppressInitialDiagnosticInformation = true;
                    //chromeDriverService.EnableVerboseLogging = false;
                    //new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
                    _driver = new ChromeDriver(chromeDriverService, DefineChromeOptions());
                    ManageDriverDefaultSettings(_driver);
                    break;
                case DriversEnum.Firefox:
                    throw new NotImplementedException($"Driver for {DriversEnum.Firefox} hasn't any implementation yet");
                case DriversEnum.Edge:
                    throw new NotImplementedException($"Driver for {DriversEnum.Edge} hasn't any implementation yet");
                default: throw new InvalidEnumArgumentException("Wrong driver name");
            }
            ExplicitWait = new ExplicitWait(_driver);
            return _driver;
        }

        public void NullDriver() 
        {
            _driver = null;
        }

        public static Browser GetInstance() 
        {
            if (_browserInstance != null) return _browserInstance;
            lock (_syncRoot)
            {
                if (_browserInstance == null)
                {
                    _browserInstance = new Browser();
                }
            }
            return _browserInstance;
        }

        private void ManageDriverDefaultSettings(IWebDriver Driver)
        {
            FrameworkLogger.Info("Manage default IwebDriver settings");
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().PageLoad.Add(TimeSpan.FromSeconds(PageLoadTimeOut));
        }

        private ChromeOptions DefineChromeOptions() 
        {
            FrameworkLogger.Info("Define Chrome oprions");
            ChromeOptions options = new ChromeOptions();
            var chromeOptionsList = FrameworkJsonUtil.GetValueFromAppettingsFile<IEnumerable<string>>(ChromeOptionsKey);
            options.AddArguments(chromeOptionsList);
            chromeOptionsList.ToList().ForEach(option => FrameworkLogger.Info($"{option} has been added"));
            return options;
        }
    }
}
