using Framework.Elements.Interfaces;
using Framework.Enums;
using Framework.Logging;
using OpenQA.Selenium;

namespace Framework.Elements.Classes
{
    public class WebContainer : BaseWebUiElement, IWebContainer
    {
        private const string HrefAttribute = "href";

        public WebContainer(By locator, string elementName, ElementState elementState = ElementState.Displayed)
            : base(locator, elementName, elementState)
        {
        }

        public void ClickElementByHrefContains(string text)
        {
            FrameworkLogger
                .Info($"Clicking on web element by{HrefAttribute} in container by Locator[{Locator}] and Name{ElementName}");
            var itemElement = GetWebElements()
                .First(element => element.GetAttribute(HrefAttribute)
                .Contains(text));
            Actions.MoveToElement(itemElement)
                .Click()
                .Build()
                .Perform();
        }
    }
}
