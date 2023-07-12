using Framework.Constants;
using Framework.Enums;
using Framework.Logging;
using Framework.Utils;
using Framework.Waits;
using OpenQA.Selenium;

namespace Framework.Elements
{
    public class WebLabel : BaseWebUiElement
    {
        public WebLabel(By locator, string elementName, SearchTypeEnum searchType = SearchTypeEnum.Single) : base(locator, elementName, searchType)
        {
        }

        public List<string> GetTextsFromLabels() 
        {
            FrameworkLogger.Info($"Getting texts from label by Locator[{locator}] and Name{ElementName}");
            var listOfTexts = new List<string>();
            ExplicitWait.WaitForCondition(() =>
            {
                try
                {
                    listOfTexts = WebElements
                        .Select(label => label.Text)
                        .ToList();
                    return true;
                }
                catch (StaleElementReferenceException)
                {
                    ReFindWebElements();
                    return false;
                }
            }, TimeSpan.FromSeconds(FrameworkJsonUtil.GetValueFromAppettingsFile<double>(FrameworkConstants.DefaultConditionWaitIntervalKey)));
            return listOfTexts;
        }
    }
}
