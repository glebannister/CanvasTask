using Framework.Constants;
using Framework.Elements;
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
            var defaulConditionWaitTime = FrameworkJsonUtil.GetValueFromAppettingsFile<double>(FrameworkConstants.DefaultConditionWaitIntervalKey);
            return ExplicitWait.WaitForCondition(() => 
                uniqePageElement.IsElementDisplayed(),
                TimeSpan.FromSeconds(defaulConditionWaitTime));
        }
    }
}
