using Framework.Helpers;

namespace UITestsProject.Configuration.Constants.TestDataConstants
{
    internal static class TestDataConstants
    {
        public const string CategoryValue = "Category";
        public const string DefaultFirstLastNameWebText = "FirstName\r\n(none)\r\nLastName";

        public static string TestUserName => _dataProvider.GetValueFromJsonFile<string>("User", Resources, UsersJson);
        public static string TestUserPassword => _dataProvider.GetValueFromJsonFile<string>("Password", Resources, UsersJson);
        private static DataProvider _dataProvider = new DataProvider();
        private const string Resources = "Resources";
        private const string UsersJson = "users.json";
    }
}
