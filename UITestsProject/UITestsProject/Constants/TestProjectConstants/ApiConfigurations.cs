using Framework.Helpers;

namespace UITestsProject.Constants.TestProjectConstants
{
    public static class ApiConfigurations
    {
        public static string LoginUrl => _appSettingsHelper.GetConfigurationOnlyFileValue<string>("LoginUrl");
        private static AppSettingsHelper _appSettingsHelper = new AppSettingsHelper();
    }
}
