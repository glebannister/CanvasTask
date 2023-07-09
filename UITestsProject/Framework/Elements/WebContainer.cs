using Framework.Enums;
using OpenQA.Selenium;

namespace Framework.Elements
{
    public class WebContainer : BaseWebUiElement
    {
        public WebContainer(By locator, string elementName, SearchTypeEnum searchType = SearchTypeEnum.Multiply) 
            : base(locator, elementName, searchType)
        {
        }

        public void ClickElementByHrefContains(string text) 
        {
            WebElements.First(element => element.GetAttribute("href").Contains(text)).Click();
        }
    }
}
