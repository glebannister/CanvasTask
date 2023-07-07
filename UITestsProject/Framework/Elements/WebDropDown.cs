using Framework.Enums;
using OpenQA.Selenium;

namespace Framework.Elements
{
    public class WebDropDown : BaseWebUiElement
    {
        public WebDropDown(By locator, string elementName, SearchTypeEnum searchType) : base(locator, elementName, searchType)
        {
        }
    }
}
