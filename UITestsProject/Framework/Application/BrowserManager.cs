using Framework.Logging;
using Framework.Waits;
using OpenQA.Selenium;

namespace Framework.Application
{
    public static class BrowserManager
    {
        public static void NavigateToUrl(string url) 
        {
            FrameworkLogger.Info($"Navigate to URL:{url}");
            Browser.GetInstance().GetDriver().Navigate().GoToUrl(url);
        }

        public static ExplicitWait ExplicitWaits() 
        {
            return Browser.GetInstance().ExplicitWait;
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

        public static IWebElement FindElement(By locator)
        {
           return Browser.GetInstance().GetDriver().FindElement(locator);
        }

        public static List<IWebElement> FindElements(By locator) 
        {
            return Browser.GetInstance().GetDriver().FindElements(locator).ToList();
        }
    }
}