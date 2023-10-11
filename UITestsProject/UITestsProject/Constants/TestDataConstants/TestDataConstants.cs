using Framework.Utils;

namespace UITestsProject.Constants.TestDataConstants
{
    internal static class TestDataConstants
    {
        public const string CategoryValue = "Category";
        public const string DefaultFirstLastNameWebText = "FirstName\r\n(none)\r\nLastName";
        public static string TestUserName => new AppSettings().GetConfigurationOnlyFileValue<string>("User");
        public static string TestUserPassword => new AppSettings().GetConfigurationOnlyFileValue<string>("Password");
    }
}
