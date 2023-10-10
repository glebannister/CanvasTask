using Framework.Utils;

namespace Framework.Constants
{
    public static class DriverConfigurations
    {
        internal static string BrowserName => FrameworkJsonUtil.GetValueFromAppettingsFile<string>("Browser");
        internal static int PageLoadTimeOut => FrameworkJsonUtil.GetValueFromAppettingsFile<int>("PageLoadTimeOut");
        internal static IEnumerable<string> ChromeOptions => FrameworkJsonUtil.GetValueFromAppettingsFile<IEnumerable<string>>("ChromeOptions");
    }
}
