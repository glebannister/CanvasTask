using Framework.Application;
using Framework.Enums;
using Framework.Utils;
using Framework.Waits;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Framework.Elements
{
    public abstract class BaseWebUiElement
    {
        public string ElementName { get; set; }

        public IWebElement WebElement { get; private set; }

        public List<IWebElement> WebElements { get; private set; }

        protected By locator;
        protected Actions Actions { get; private set; }
        private const string KeyForDefaultFindElementTimeout = "DefaulTimeoutForFindingElement";

        protected BaseWebUiElement(By locator, string elementName, SearchTypeEnum searchType) 
        {
            this.locator = locator;
            ElementName = elementName;
            InitializeWebElementBySearchType(searchType);
            Actions = new Actions(Browser.GetInstance().GetDriver());
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

        public bool IsElementEnabled()
        {
            IsWebElementIsNotNull();
            return WebElement.Enabled;
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

        public void Focus() 
        {
            Actions.MoveToElement(WebElement).Build().Perform();
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
            var timeOut = FrameworkJsonUtil.GetValueFromAppettingsFile<double>(KeyForDefaultFindElementTimeout);
            var isElementFound = ExplicitWait.WaitForCondition(() =>
            {
                try
                {
                    WebElement = BrowserManager.FindElement(locator);
                    return true;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }, TimeSpan.FromSeconds(timeOut));
            if (!isElementFound) throw new NoSuchElementException($"Web element with locator [{locator}] and name [{ElementName}]  was not found]");
        }

        private void GetWebElements()
        {
            var timeOut = FrameworkJsonUtil.GetValueFromAppettingsFile<double>(KeyForDefaultFindElementTimeout);
            ExplicitWait.WaitForCondition(() => 
            {
                WebElements = BrowserManager.FindElements(locator);
                return WebElements.Any();
            }, TimeSpan.FromSeconds(timeOut));
        }

        private void IsWebElementIsNotNull()
        {
            if (WebElement == null)
                throw new NullReferenceException($"Web element with locator [{locator}] and name [{ElementName}] is null");
        }
    }
}
