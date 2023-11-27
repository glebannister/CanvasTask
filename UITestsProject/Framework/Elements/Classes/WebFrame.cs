using Framework.Application;
using Framework.Elements.Interfaces;
using Framework.Enums;
using OpenQA.Selenium;

namespace Framework.Elements.Classes
{
    public class WebFrame : BaseWebUiElement, IWebFrame
    {
        public WebFrame(By Locator, string elementName, ElementState state = ElementState.Displayed)
            : base(Locator, elementName, state)
        { }

        public void DoInFrame(Action action)
        {
            try
            {
                ApplicationManager.GetWebDriver().SwitchTo().Frame(GetWebElement());
                action.Invoke();
            }
            finally
            {
                ApplicationManager.GetWebDriver().SwitchTo().DefaultContent();
            }
        }

        public T DoInFrame<T>(Func<T> func)
        {
            try
            {
                ApplicationManager.GetWebDriver().SwitchTo().Frame(GetWebElement());
                return func();
            }
            catch
            {
                return default;
            }
            finally
            {
                ApplicationManager.GetWebDriver().SwitchTo().DefaultContent();
            }
        }

        public void DoInFrameIfPresent(Action action)
        {
            try
            {
                if (IsElementDisplayed())
                {
                    ApplicationManager.GetWebDriver().SwitchTo().Frame(GetWebElement());
                    action.Invoke();
                }
            }
            finally
            {
                ApplicationManager.GetWebDriver().SwitchTo().DefaultContent();
            }
        }

        public T DoInFrameIfPresent<T>(Func<T> func)
        {
            try
            {
                if (IsElementDisplayed())
                {
                    ApplicationManager.GetWebDriver().SwitchTo().Frame(GetWebElement());
                    return func();
                }
                else return default;
            }
            catch
            {
                return default;
            }
            finally
            {
                ApplicationManager.GetWebDriver().SwitchTo().DefaultContent();
            }
        }
    }
}
