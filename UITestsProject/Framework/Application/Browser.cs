using Framework.Enums;
using Framework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Framework.Logging;
using System.ComponentModel;
using Framework.Waits;
using Framework.Constants;

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
            //ICapabilities capabilities;
            switch (FrameworkEnumUtil.ConvertStringToEnum<DriversEnum>(DriverConfigurations.BrowserName)) 
            {
                case DriversEnum.Chrome:
                    ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
                    chromeDriverService.SuppressInitialDiagnosticInformation = true;
                    chromeDriverService.EnableVerboseLogging = false;
                    //new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
                    //capabilities = DefineChromeOptions();
                    _driver = new ChromeDriver(DefineChromeOptions());
                    break;
                case DriversEnum.Firefox:
                    throw new NotImplementedException($"Driver for {DriversEnum.Firefox} hasn't any implementation yet");
                case DriversEnum.Edge:
                    throw new NotImplementedException($"Driver for {DriversEnum.Edge} hasn't any implementation yet");
                default: throw new InvalidEnumArgumentException("Wrong driver name");
            }
            //_driver = new RemoteWebDriver(new Uri("http://locallhost:4444"), capabilities);
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

        private void ManageDriverDefaultSettings(IWebDriver Driver)
        {
            FrameworkLogger.Info("Manage default WebDriver settings");
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().PageLoad.Add(TimeSpan.FromSeconds(DriverConfigurations.PageLoadTimeOut));
        }

        private ChromeOptions DefineChromeOptions() 
        {
            FrameworkLogger.Info("Define Chrome oprions");
            ChromeOptions options = new ChromeOptions();
            options.AddArguments(DriverConfigurations.ChromeOptions);
            //options.AddAdditionalOption("remoteAddress", "localhost");
            //options.AddAdditionalOption("remotePort", 4444);
            DriverConfigurations.ChromeOptions
                .ToList()
                .ForEach(option => FrameworkLogger.Info($"Chrome {option} has been added"));
            return options;
            //return options.ToCapabilities();
        }
    }
}
