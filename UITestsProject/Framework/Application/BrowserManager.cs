namespace Framework.Application
{
    public static class BrowserManager
    {
        public static void NavigateToUrl(string url) 
        {
            Browser.GetInstance().GetDriver().Navigate().GoToUrl(url);
        }
    }
}