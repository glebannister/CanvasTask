using Framework.Enums;
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
            WebElement.Clear();
        }

        public void SetText(string text)
        {
            WebElement.SendKeys(text);
        }
    }
}
