using Framework.Elements;
using Framework.Utils;
using Framework.Waits;

namespace Framework.Page
{
    public abstract class BaseWebPage
    {
        public string PageName { get; private set; }
        protected BaseWebUiElement uniqePageElement;
        protected const string DefaultConditionWaitIntervalKey = "DefaulConditionWaitTime";

        public BaseWebPage(BaseWebUiElement uniqePageElement, string pageName) 
        {
            this.uniqePageElement = uniqePageElement;
            PageName = pageName;
        }

        public bool IsPageOpened() 
        {
            var defaulConditionWaitTime = FrameworkJsonUtil.GetValueFromAppettingsFile<double>(DefaultConditionWaitIntervalKey);
            return ExplicitWait.WaitForCondition(() => 
                uniqePageElement.IsElementDisplayed(),
                TimeSpan.FromSeconds(defaulConditionWaitTime));
        }
    }
}
