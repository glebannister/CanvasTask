using Framework.Elements.Interfaces;
using Framework.Enums;
using OpenQA.Selenium;

namespace Framework.Elements.Classes
{
    public class WebButton : BaseWebUiElement, IWebButton
    {
        public WebButton(By locator, string elementName, ElementState elementState = ElementState.Displayed)
            : base(locator, elementName, elementState)
        {
        }
    }
}
