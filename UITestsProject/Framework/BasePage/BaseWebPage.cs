using Framework.Constants;
using Framework.Elements.Classes;
using Framework.Logging;
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
            return ExplicitWait.WaitForCondition(() => uniqePageElement.IsElementDisplayed(),
                TimeSpan.FromSeconds(TimeOutConfigurations.DefaultRetryForTimeout));
        }
    }
}
