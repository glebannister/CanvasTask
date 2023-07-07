using OpenQA.Selenium;

namespace Framework.Application
{
    public static class BrowserManager
    {
        public static void NavigateToUrl(string url) 
        {
            Browser.GetInstance().GetDriver().Navigate().GoToUrl(url);
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