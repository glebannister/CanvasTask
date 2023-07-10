using OpenQA.Selenium;

namespace Framework.Application
{
    public static class BrowserManager
    {
        public static void NavigateToUrl(string url) 
        {
            Browser.GetInstance().GetDriver().Navigate().GoToUrl(url);
        }

        public static void AcceptAlert() 
        {
            Browser.GetInstance().GetDriver().SwitchTo().Alert().Accept();
        }

        public static void ExecuteJsScript(string script, IWebElement webElement) 
        {
            ((IJavaScriptExecutor)Browser.GetInstance().GetDriver()).ExecuteScript(script, webElement);
        }

        public static void Quit() 
        {
            Browser.GetInstance().GetDriver().Quit();
            Browser.GetInstance().NullDriver();
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