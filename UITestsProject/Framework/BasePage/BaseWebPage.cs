using Framework.Application;
using Framework.Constants;
using Framework.Elements;
using Framework.Logging;
using Framework.Utils;
using Framework.Waits;

namespace Framework.Page
{
    public abstract class BaseWebPage
    {
        public string PageName { get; private set; }
        protected BaseWebUiElement uniqePageElement;

        public BaseWebPage(BaseWebUiElement uniqePageElement, string pageName) 
        {
            this.uniqePageElement = uniqePageElement;
            PageName = pageName;
        }

        public bool IsPageOpened() 
        {
            FrameworkLogger.Info($"Validate if page {PageName} is opened");
            return  BrowserManager
                .ExplicitWaits()
                .WaitForCondition(() => uniqePageElement.IsElementDisplayed(), TimeSpan.FromSeconds(BaseConfigurations.DefaultRetryForTimeout));
        }
    }
}
