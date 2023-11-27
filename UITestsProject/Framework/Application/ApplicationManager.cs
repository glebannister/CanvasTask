using Framework.Logging;
using OpenQA.Selenium;

namespace Framework.Application
{
    public class ApplicationManager
    {
        public static IWebDriver GetWebDriver()
        {
            return Browser.GetInstance().GetDriver();
        }

        public static void NavigateToUrl(string url) 
        {
            FrameworkLogger.Info($"Navigate to URL:{url}");
            GetWebDriver().Navigate().GoToUrl(url);
        }

        public static void AcceptAlert() 
        {
            FrameworkLogger.Info("Accepting allert");
            GetWebDriver().SwitchTo().Alert().Accept();
        }

        public static void SwitchToTab(string windowName) 
        {
            GetWebDriver().SwitchTo().Window(windowName);
        }

        public static void Quit() 
        {
            FrameworkLogger.Info("Quit WebDriver");
            GetWebDriver().Quit();
        }
    }
}