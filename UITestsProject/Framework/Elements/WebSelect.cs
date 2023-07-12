using Framework.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Framework.Elements
{
    public class WebSelect : BaseWebUiElement
    {
        private SelectElement _selectElement;

        public WebSelect(By locator, string elementName, SearchTypeEnum searchType = SearchTypeEnum.Single) 
            : base(locator, elementName, searchType)
        {
            _selectElement = new SelectElement(WebElement);
        }
    }
}
