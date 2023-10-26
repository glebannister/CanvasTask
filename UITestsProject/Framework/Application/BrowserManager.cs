using Framework.Logging;

namespace Framework.Application
{
    public static class BrowserManager
    {
        public static void NavigateToUrl(string url) 
        {
            FrameworkLogger.Info($"Navigate to URL:{url}");
            Browser.GetInstance().GetDriver().Navigate().GoToUrl(url);
        }

        public static void AcceptAlert() 
        {
            FrameworkLogger.Info("Accepting allert");
            Browser.GetInstance().GetDriver().SwitchTo().Alert().Accept();
        }

        public static void Quit() 
        {
            FrameworkLogger.Info("Quit WebDriver");
            Browser.GetInstance().GetDriver().Quit();
        }
    }
}