using Framework.Enums;
using OpenQA.Selenium;

namespace Framework.Elements
{
    public class WebTable : BaseWebUiElement
    {
        public WebTable(By locator, string elementName, SearchTypeEnum searchType = SearchTypeEnum.Multiply) 
            : base(locator, elementName, searchType)
        {
        }
    }
}
