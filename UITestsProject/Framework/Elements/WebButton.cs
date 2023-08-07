using Framework.Enums;
using OpenQA.Selenium;

namespace Framework.Elements
{
    public class WebButton : BaseWebUiElement
    {
        public WebButton(By locator, string elementName, ElementState elementState = ElementState.Displayed) 
            : base(locator, elementName, elementState)
        {
        }
    }
}
