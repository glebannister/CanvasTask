using Framework.Application;
using Framework.Constants;
using Framework.Enums;
using Framework.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.ObjectModel;

namespace Framework.Elements
{
    public abstract class BaseWebUiElement
    {
        public string ElementName { get; set; }

        protected ElementState State { get; set; }

        protected By Locator { get; set; }

        public Actions Actions { get; private set; }

        protected BaseWebUiElement(By Locator, string elementName, ElementState state) 
        {
            this.Locator = Locator;
            ElementName = elementName;
            State = state;
            Actions = new Actions(Browser.GetInstance().GetDriver());
        }

        public bool IsElementExists()
        {
            FrameworkLogger.Info($"Checking if web element by Locator[{Locator}] and Name {ElementName} is Exists");
            try 
            {
                WaitForElements(Locator, ElementState.ExistsInAnyState);
                return true;
            } catch (NoSuchElementException) 
            {
                return false;
            }
        }

        public bool IsElementDisplayed()
        {
            FrameworkLogger.Info($"Checking if web element by Locator[{Locator}] and Name {ElementName} is Displayed");
            return GetWebElement().Displayed;
        }

        public bool IsElementEnabled()
        {
            FrameworkLogger.Info($"Checking if web element by Locator[{Locator}] and Name{ElementName} is Enabled");
            return GetWebElement().Enabled;
        }

        public void Click() 
        {
            FrameworkLogger.Info($"Clicking on web element by Locator[{Locator}] and Name{ElementName}");
            GetWebElement().Click();
        }

        public string GetText() 
        {
            FrameworkLogger.Info($"Getting text from web element by Locator[{Locator}] and Name{ElementName}");
            return GetWebElement().Text;
        }

        public void Focus() 
        {
            FrameworkLogger.Info($"Focusing on web element by Locator[{Locator}] and Name{ElementName}");
            Actions.MoveToElement(GetWebElement()).Build().Perform();
        }

        public IWebElement GetWebElement()
        {
            FrameworkLogger.Info($"Getting web element by Locator[{Locator}] and Name {ElementName}");
            return GetWebElements().First();
        }

        public ReadOnlyCollection<IWebElement> GetWebElements()
        {
            FrameworkLogger.Info($"Getting web element by Locator[{Locator}] and Name {ElementName}");
            return WaitForElements(Locator, State);
        }

        public ReadOnlyCollection<IWebElement> ReFindWebElements(ElementState state) 
        {
            FrameworkLogger.Info($"Refinding web elements by Locator[{Locator}] and Name {ElementName}");
            return WaitForElements(Locator, state);
        }

        private ReadOnlyCollection<IWebElement> WaitForElements(By Locator, ElementState state)
        {
            var elementStateCondition = ResolveState(state);
            var foundElements = new List<IWebElement>();
            var resultElements = new List<IWebElement>();
            try
            {
                BrowserManager
                    .ExplicitWaits()
                    .WaitFor(driver =>
                    {
                        foundElements = driver.FindElements(Locator).ToList();
                        resultElements = foundElements.Where(elementStateCondition).ToList();
                        return resultElements.Any();
                    }, TimeSpan.FromSeconds(TimeOutConfigurations.SearchForElementTimeout));
            }
            catch (WebDriverTimeoutException)
            {
                HandleWebdriverTimeoutException(Locator, state, foundElements);
            }
            return resultElements.AsReadOnly();
        }

        private Func<IWebElement, bool> ResolveState(ElementState state)
        {
            Func<IWebElement, bool> elementStateCondition;
            switch (state)
            {
                case ElementState.Displayed:
                    elementStateCondition = element => element.Displayed;
                    break;
                case ElementState.ExistsInAnyState:
                    elementStateCondition = element => true;
                    break;
                case ElementState.Clickable:
                    elementStateCondition = element => element.Displayed && element.Enabled;
                    break;
                default:
                    throw new InvalidOperationException($"{state} state is not recognized");
            }
            return elementStateCondition;
        }

        private void HandleWebdriverTimeoutException(By Locator, ElementState state, List<IWebElement> foundElements)
        {  
            var message = foundElements.Any()
                ? $"Elements were found by Locator '{Locator}'. But not in state '{state}'"
                : $"No elements with Locator '{Locator}' found in {state} state";
            throw new NoSuchElementException(message);
        }
    }
}
