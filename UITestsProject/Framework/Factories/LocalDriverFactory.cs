using Framework.Constants;
using Framework.Enums;
using Framework.Logging;
using Framework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.ComponentModel;

namespace Framework.Factories
{
    internal class LocalDriverFactory
    {
        public IWebDriver CreateLocalDriver() 
        {
            switch (FrameworkEnumUtil.ConvertStringToEnum<DriversEnum>(DriverConfigurations.BrowserName))
            {
                case DriversEnum.Chrome:
                    return InitialiseChromeDriver();
                case DriversEnum.Firefox:
                    throw new NotImplementedException($"Driver for {DriversEnum.Firefox} hasn't any implementation yet");
                case DriversEnum.Edge:
                    throw new NotImplementedException($"Driver for {DriversEnum.Edge} hasn't any implementation yet");
                default: throw new InvalidEnumArgumentException("Wrong driver name");
            }
        }

        private ChromeDriver InitialiseChromeDriver() 
        {
            ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.SuppressInitialDiagnosticInformation = true;
            chromeDriverService.EnableVerboseLogging = false;
            return new ChromeDriver(DefineChromeOptions());
        }

        private ChromeOptions DefineChromeOptions()
        {
            FrameworkLogger.Info("Define Chrome oprions");
            ChromeOptions options = new ChromeOptions();
            options.AddArguments(DriverConfigurations.ChromeOptions);
            DriverConfigurations.ChromeOptions
                .ToList()
                .ForEach(option => FrameworkLogger.Info($"Chrome {option} has been added"));
            return options;
        }
    }
}
