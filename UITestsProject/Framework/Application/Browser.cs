using Framework.Enums;
using Framework.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using WebDriverManager;
using OpenQA.Selenium.Chrome;

namespace Framework.Application
{
    public class Browser
    {
        public int PageLoadTimeOut { get; set; } = 60;

        private IWebDriver _driver;
        private const string BrowserKey = "Browser";
        private static Browser? _browserInstance;
        private static readonly object _syncRoot = new();

        public IWebDriver GetDriver() 
        {
            if (_driver != null) return _driver;
            var driverName = JsonUtil.GetValueFromAppettingsFile(BrowserKey);
            switch (EnumUtil.ConvertStringToEnum<DriversEnum>(driverName)) 
            {
                case DriversEnum.Chrome:
                    new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
                    _driver = new ChromeDriver(ChromeDriverService.CreateDefaultService());
                    ManageDriverDefaultSettings(_driver);
                    break;
                case DriversEnum.Firefox:
                    throw new NotImplementedException($"Driver for {DriversEnum.Firefox} hasn't any implementation yet");
                case DriversEnum.Edge:
                    throw new NotImplementedException($"Driver for {DriversEnum.Edge} hasn't any implementation yet");
                default: throw new NotImplementedException("Wrong driver name");
            }
            return _driver;
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
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().PageLoad.Add(TimeSpan.FromSeconds(PageLoadTimeOut));
        }
    }
}
