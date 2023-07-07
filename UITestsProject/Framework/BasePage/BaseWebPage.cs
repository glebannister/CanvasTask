using Framework.Elements;
using Framework.Utils;
using Framework.Waits;

namespace Framework.Page
{
    public abstract class BaseWebPage
    {
        public string PageName { get; private set; }
        protected BaseWebUiElement _uniqePageElement;
        private const string DefaultConditionWaitIntervalKey = "DefaulConditionWaitTime";

        public BaseWebPage(BaseWebUiElement uniqePageElement, string pageName) 
        {
            _uniqePageElement = uniqePageElement;
            PageName = pageName;
        }

        public bool IsPageDisplayed() 
        {
            var defaulConditionWaitTime = JsonUtil.GetValueFromAppettingsFile<double>(DefaultConditionWaitIntervalKey);
            //Double.TryParse(defaulConditionWaitTime, out double defaultIntervalDouble);
            return ExplicitWait.WaitForCondition(() => _uniqePageElement.IsElementDisplayed(), TimeSpan.FromSeconds(defaulConditionWaitTime));
        }
    }
}
