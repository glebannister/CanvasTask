using Framework.Constants;
using Framework.Enums;
using Framework.Logging;
using Framework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System.ComponentModel;

namespace Framework.Factories
{
    internal class GridDriverFactory
    {
        public IWebDriver CreateGridDriver() 
        {
            switch (FrameworkEnumUtil.ConvertStringToEnum<DriversEnum>(DriverConfigurations.BrowserName))
            {
                case DriversEnum.Chrome:
                    return InitialiseRemoteWebDriver();
                case DriversEnum.Firefox:
                    throw new NotImplementedException($"Driver for {DriversEnum.Firefox} hasn't been implemented yet");
                case DriversEnum.Edge:
                    throw new NotImplementedException($"Driver for {DriversEnum.Edge} hasn't been implemented yet");
                default: throw new InvalidEnumArgumentException("Wrong driver name");
            }
        }

        private RemoteWebDriver InitialiseRemoteWebDriver() 
        {
            ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.SuppressInitialDiagnosticInformation = true;
            chromeDriverService.EnableVerboseLogging = false;
            return new RemoteWebDriver(new Uri("http://locallhost:4444"), DefineChromeCapabilities());
        }

        private ICapabilities DefineChromeCapabilities()
        {
            FrameworkLogger.Info("Define Chrome oprions");
            ChromeOptions options = new ChromeOptions();
            options.AddArguments(DriverConfigurations.ChromeOptions);
            options.AddAdditionalOption("remoteAddress", "localhost");
            options.AddAdditionalOption("remotePort", 4444);
            DriverConfigurations.ChromeOptions
                .ToList()
                .ForEach(option => FrameworkLogger.Info($"Chrome {option} has been added"));
            return options.ToCapabilities();
        }
    }
}
