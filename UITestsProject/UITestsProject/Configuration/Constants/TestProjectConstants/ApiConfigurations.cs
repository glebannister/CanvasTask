namespace UITestsProject.Configuration.Constants.TestProjectConstants
{
    public static class ApiConfigurations
    {
        public static string LoginUrl => _dataProvider.GetValueFromJsonFile<string>("LoginUrl", Resources, UrlsJson);
        private const string Resources = "Resources";
        private const string UrlsJson = "urls.json";
        private static DataProvider _dataProvider = new DataProvider();
    }
}
