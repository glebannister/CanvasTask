using Framework.Application;
using Framework.Enums;
using Framework.Utils;
using Framework.Waits;
using OpenQA.Selenium;

namespace Framework.Elements
{
    public class WebContainer : BaseWebUiElement
    {
        private const string KeyForDefaultFindElementTimeout = "DefaulTimeoutForFindingElement";

        public WebContainer(By locator, string elementName, SearchTypeEnum searchType = SearchTypeEnum.Multiply) 
            : base(locator, elementName, searchType)
        {
        }

        public void ClickElementByHrefContains(string text) 
        {
            var itemElement = WebElements.First(element => element.GetAttribute("href").Contains(text));
            Actions.MoveToElement(itemElement);
            Actions.Click();
            Actions.Build().Perform();
        }
    }
}
