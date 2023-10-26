namespace UITestsProject.Configuration.Constants.TestProjectConstants
{
    public static class ApplicationConfiguration
    {
        public static string CrmUrl => _dataProvider.GetValueFromJsonFile<string>("CrmUrl", Resources, UrlsJson);
        private const string Resources = "Resources";
        private const string UrlsJson = "urls.json";
        private static DataProvider _dataProvider = new DataProvider();
    }
}
