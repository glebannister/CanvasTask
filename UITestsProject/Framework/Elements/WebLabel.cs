using Framework.Enums;
using OpenQA.Selenium;

namespace Framework.Elements
{
    public class WebLabel : BaseWebUiElement
    {
        public WebLabel(By locator, string elementName, SearchTypeEnum searchType) : base(locator, elementName, searchType)
        {
        }
    }
}
