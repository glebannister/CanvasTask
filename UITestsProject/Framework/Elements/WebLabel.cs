using Framework.Enums;
using OpenQA.Selenium;

namespace Framework.Elements
{
    public class WebLabel : BaseWebUiElement
    {
        public WebLabel(By locator, string elementName, SearchTypeEnum searchType = SearchTypeEnum.Single) : base(locator, elementName, searchType)
        {
        }
    }
}
