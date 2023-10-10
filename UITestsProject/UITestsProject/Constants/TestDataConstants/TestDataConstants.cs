using Framework.Utils;

namespace UITestsProject.Constants.TestDataConstants
{
    internal static class TestDataConstants
    {
        public const string CategoryValue = "Category";
        public const string DefaultFirstLastNameWebText = "FirstName\r\n(none)\r\nLastName";
        public static string TestUserName => FrameworkJsonUtil.GetValueFromAppettingsFile<string>("User");
        public static string TestUserPassword => FrameworkJsonUtil.GetValueFromAppettingsFile<string>("Password");
    }
}
