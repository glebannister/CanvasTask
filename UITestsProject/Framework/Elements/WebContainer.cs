using Framework.Enums;
using Framework.Logging;
using OpenQA.Selenium;

namespace Framework.Elements
{
    public class WebContainer : BaseWebUiElement
    {
        private const string KeyForDefaultFindElementTimeout = "DefaulTimeoutForFindingElement";
        private const string HrefAttribute = "href";

        public WebContainer(By locator, string elementName, SearchTypeEnum searchType = SearchTypeEnum.Multiply) 
            : base(locator, elementName, searchType)
        {
        }

        public void ClickElementByHrefContains(string text) 
        {
            FrameworkLogger
                .Info($"Clicking on web element by{HrefAttribute} in container by Locator[{locator}] and Name{ElementName}");
            var itemElement = WebElements.First(element => element.GetAttribute(HrefAttribute).Contains(text));
            Actions.MoveToElement(itemElement);
            Actions.Click();
            Actions.Build().Perform();
        }
    }
}
