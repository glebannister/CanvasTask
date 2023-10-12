using Framework.Helpers;

namespace UITestsProject.Constants.TestProjectConstants
{
    public static class ApplicationConfiguration
    {
        public static string CrmUrl => _appSetingsHelper.GetConfigurationOnlyFileValue<string>("CrmUrl");
        private static AppSettingsHelper _appSetingsHelper = new AppSettingsHelper();
    }
}
