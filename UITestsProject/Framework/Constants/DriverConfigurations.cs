using Framework.Utils;

namespace Framework.Constants
{
    public static class DriverConfigurations
    {
        internal static string BrowserName => new AppSettings().GetConfigurationValueWithEnvVariables("Browser");
        internal static int PageLoadTimeOut => new AppSettings().GetConfigurationOnlyFileValue<int>("PageLoadTimeOut");
        internal static IEnumerable<string> ChromeOptions => new AppSettings().GetConfigurationOnlyFileValue<IEnumerable<string>>("ChromeOptions");
    }
}
