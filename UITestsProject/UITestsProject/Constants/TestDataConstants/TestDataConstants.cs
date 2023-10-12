using Framework.Helpers;
using Framework.Utils;

namespace UITestsProject.Constants.TestDataConstants
{
    internal static class TestDataConstants
    {
        public const string CategoryValue = "Category";
        public const string DefaultFirstLastNameWebText = "FirstName\r\n(none)\r\nLastName";
        public static string TestUserName => _appSettingsHelper.GetConfigurationOnlyFileValue<string>("User");
        public static string TestUserPassword => _appSettingsHelper.GetConfigurationOnlyFileValue<string>("Password");
        private static AppSettingsHelper _appSettingsHelper = new AppSettingsHelper();
    }
}
