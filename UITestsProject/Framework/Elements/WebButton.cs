using Framework.Enums;
using OpenQA.Selenium;

namespace Framework.Elements
{
    public class WebButton : BaseWebUiElement
    {
        public WebButton(By locator, string elementName, SearchTypeEnum searchType) : base(locator, elementName, searchType)
        {
        }
    }
}
