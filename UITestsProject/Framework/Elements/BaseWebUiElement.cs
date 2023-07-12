using Framework.Application;
using Framework.Constants;
using Framework.Enums;
using Framework.Logging;
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

        protected BaseWebUiElement(By locator, string elementName, SearchTypeEnum searchType) 
        {
            this.locator = locator;
            ElementName = elementName;
            InitializeWebElementBySearchType(searchType);
            Actions = new Actions(Browser.GetInstance().GetDriver());
        }

        public bool IsElementExist() 
        {
            FrameworkLogger.Info($"Checking if web element by Locator[{locator}] and Name{ElementName} is Exist");
            if (WebElements == null) GetWebElements();
            return WebElements.Any();
        }

        public bool IsElementDisplayed()
        {
            FrameworkLogger.Info($"Checking if web element by Locator[{locator}] and Name{ElementName} is Displayed");
            IsWebElementIsNotNull();
            return WebElement.Displayed;
        }

        public bool IsElementEnabled()
        {
            FrameworkLogger.Info($"Checking if web element by Locator[{locator}] and Name{ElementName} is Enabled");
            IsWebElementIsNotNull();
            return WebElement.Enabled;
        }

        public void Click() 
        {
            FrameworkLogger.Info($"Clicking on web element by Locator[{locator}] and Name{ElementName}");
            IsWebElementIsNotNull();
            WebElement.Click();
        }

        public string GetText() 
        {
            FrameworkLogger.Info($"Getting text from web element by Locator[{locator}] and Name{ElementName}");
            IsWebElementIsNotNull();
            return WebElement.Text;
        }

        public void Focus() 
        {
            FrameworkLogger.Info($"Focusing on web element by Locator[{locator}] and Name{ElementName}");
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

        public void ReFindWebElement()
        {
            FrameworkLogger.Info($"Refinding web element by Locator[{locator}] and Name{ElementName}");
            WebElement = BrowserManager.FindElement(locator);
        }

        public void ReFindWebElements() 
        {
            FrameworkLogger.Info($"Refinding web elements by Locator[{locator}] and Name{ElementName}");
            WebElements = BrowserManager.FindElements(locator);
        }

        private void GetWebElement() 
        {
            FrameworkLogger.Info($"Getting web element by Locator[{locator}] and Name{ElementName}");
            var timeOut = FrameworkJsonUtil.GetValueFromAppettingsFile<double>(FrameworkConstants.KeyForDefaultFindElementTimeout);
            ExplicitWait.WaitForCondition(() =>
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
        }

        private void GetWebElements()
        {
            FrameworkLogger.Info($"Getting web elements by Locator[{locator}] and Name{ElementName}");
            var timeOut = FrameworkJsonUtil.GetValueFromAppettingsFile<double>(FrameworkConstants.KeyForDefaultFindElementTimeout);
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
