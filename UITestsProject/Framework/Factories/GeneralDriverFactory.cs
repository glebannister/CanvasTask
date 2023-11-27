using Framework.Constants;
using Framework.Enums;
using Framework.Utils;
using OpenQA.Selenium;
using System.ComponentModel;

namespace Framework.Factories
{
    internal class GeneralDriverFactory
    {
        public IWebDriver CreateDriver() 
        {
            switch (FrameworkEnumUtil.ConvertStringToEnum<ExecutionPlatform>(DriverConfigurations.ExecutionPlatform)) 
            {
                case ExecutionPlatform.Local:
                    return new LocalDriverFactory().CreateLocalDriver();
                case ExecutionPlatform.Grid:
                    return new GridDriverFactory().CreateGridDriver();
                case ExecutionPlatform.Mobile:
                    throw new NotImplementedException($"{ExecutionPlatform.Mobile} driver hasn't been implemented yet");
                default:
                    throw new InvalidEnumArgumentException("Wrong driver name");
            }
        }
    }
}
