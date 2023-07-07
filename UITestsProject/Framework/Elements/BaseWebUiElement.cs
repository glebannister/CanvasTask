using Framework.Application;
using Framework.Enums;
using OpenQA.Selenium;

namespace Framework.Elements
{
    public abstract class BaseWebUiElement
    {
        public string ElementName { get; set; }

        public IWebElement WebElement { get; private set; }

        public List<IWebElement> WebElements { get; private set; }

        protected By locator;

        protected BaseWebUiElement(By locator, string elementName, SearchTypeEnum searchType) 
        {
            this.locator = locator;
            ElementName = elementName;
            InitializeWebElementBySearchType(searchType);
        }

        public bool IsElementExist() 
        {
            if (WebElements == null) GetWebElements();
            return WebElements.Count > 0 
                ? true 
                : false;
        }

        public bool IsElementDisplayed()
        {
            IsWebElementIsNotNull();
            return WebElement.Displayed;
        }

        public void Click() 
        {
            IsWebElementIsNotNull();
            WebElement.Click();
        }

        public string GetText() 
        {
            IsWebElementIsNotNull();
            return WebElement.Text;
        }

        private void InitializeWebElementBySearchType(SearchTypeEnum searchType)
        {
            switch (searchType)
            {
                case SearchTypeEnum.Single:
                    GetWebElement();
                    break;
                case SearchTypeEnum.Multiply:
                    GetWebElements();
                    break;
                default:
                    throw new NotImplementedException($"{searchType} hasn't any implementation");
            }
        }

        private void GetWebElement() 
        {
            WebElement = BrowserManager.FindElement(locator);
        }

        private void GetWebElements()
        {
            WebElements = BrowserManager.FindElements(locator);
        }

        private void IsWebElementIsNotNull() 
        {
            if (WebElement == null) 
                throw new NullReferenceException($"Web element with locator [{locator}] and name [{ElementName}] is null");
        }
    }
}
