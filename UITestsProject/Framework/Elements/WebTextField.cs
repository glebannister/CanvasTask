using Framework.Enums;
using Framework.Logging;
using OpenQA.Selenium;

namespace Framework.Elements
{
    public class WebTextField : BaseWebUiElement
    {
        public WebTextField(By locator, string elementName, SearchTypeEnum searchType = SearchTypeEnum.Single) 
            : base(locator, elementName, searchType)
        {
        }

        public void ClearText() 
        {
            FrameworkLogger.Info($"Getting text in label by Locator[{locator}] and Name{ElementName}");
            WebElement.Clear();
        }

        public void SetText(string text)
        {
            FrameworkLogger.Info($"Getting text to label by Locator[{locator}] and Name{ElementName}");
            WebElement.SendKeys(text);
        }
    }
}
