using Framework.Helpers;

namespace Framework.Constants
{
    public static class DriverConfigurations
    {
        internal static string BrowserName => _appSettingsHelper.GetConfigurationValueWithEnvVariables("Browser");
        internal static int PageLoadTimeOut => _appSettingsHelper.GetConfigurationOnlyFileValue<int>("PageLoadTimeOut");
        internal static IEnumerable<string> ChromeOptions => _appSettingsHelper.GetConfigurationOnlyFileValue<IEnumerable<string>>("ChromeOptions");
        private static AppSettingsHelper _appSettingsHelper = new AppSettingsHelper();
    }
}
