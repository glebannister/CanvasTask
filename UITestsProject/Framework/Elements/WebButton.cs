using Framework.Enums;
using OpenQA.Selenium;

namespace Framework.Elements
{
    public class WebButton : BaseWebUiElement
    {
        public WebButton(By locator, string elementName, SearchTypeEnum searchType = SearchTypeEnum.Single) 
            : base(locator, elementName, searchType)
        {
        }
    }
}
