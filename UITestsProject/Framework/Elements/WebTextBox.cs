using Framework.Enums;
using OpenQA.Selenium;

namespace Framework.Elements
{
    public class WebTextBox : BaseWebUiElement
    {
        public WebTextBox(By locator, string elementName, SearchTypeEnum searchType) : base(locator, elementName, searchType)
        {
        }
    }
}
