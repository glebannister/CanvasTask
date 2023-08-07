using Framework.Enums;
using OpenQA.Selenium;

namespace Framework.Elements
{
    public class WebTable : BaseWebUiElement
    {
        public WebTable(By locator, string elementName, ElementState elementState = ElementState.Displayed) 
            : base(locator, elementName, elementState)
        {
        }
    }
}
