using Framework.Utils;

namespace UITestsProject.Constants.TestDataConstants
{
    public static class ApiConfigurations
    {
        public static string LoginUrl => new AppSettings().GetConfigurationOnlyFileValue<string>("LoginUrl");
    }
}
