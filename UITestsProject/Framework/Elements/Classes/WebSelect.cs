using Framework.Elements.Interfaces;
using Framework.Enums;
using OpenQA.Selenium;

namespace Framework.Elements.Classes
{
    public class WebSelect : BaseWebUiElement, IWebSelect
    {
        public WebSelect(By locator, string elementName, ElementState elementState = ElementState.Displayed)
            : base(locator, elementName, elementState)
        {
        }
    }
}
