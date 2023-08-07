using Framework.Enums;
using Framework.Logging;
using OpenQA.Selenium;

namespace Framework.Elements
{
    public class WebTextField : BaseWebUiElement
    {
        public WebTextField(By locator, string elementName, ElementState elementState = ElementState.Displayed) 
            : base(locator, elementName, elementState)
        {
        }

        public void ClearText() 
        {
            FrameworkLogger.Info($"Getting text in label by Locator[{Locator}] and Name{ElementName}");
            GetWebElement().Clear();
        }

        public void SetText(string text)
        {
            FrameworkLogger.Info($"Getting text to label by Locator[{Locator}] and Name{ElementName}");
            GetWebElement().SendKeys(text);
        }
    }
}
