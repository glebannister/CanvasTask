using Framework.Application;
using Framework.Enums;
using OpenQA.Selenium;
using System;

namespace Framework.Elements
{
    public class WebFrame : BaseWebUiElement
    {
        public WebFrame(By Locator, string elementName, ElementState state = ElementState.Displayed)
            : base(Locator, elementName, state)
        { }

        public void DoInFrame(Action action)
        {
            try
            {
                BrowserManager.GetDriver().SwitchTo().Frame(GetWebElement());
                action.Invoke();
            }
            finally
            {
                BrowserManager.GetDriver().SwitchTo().DefaultContent();
            }
        }

        public T DoInFrame<T>(Func<T> func) 
        {
            try
            {
                BrowserManager.GetDriver().SwitchTo().Frame(GetWebElement());
                return func();
            }
            catch 
            {
                return default(T);
            }
            finally
            {
                BrowserManager.GetDriver().SwitchTo().DefaultContent();
            }
        }

        public void DoInFrameIfPresent(Action action) 
        {
            try
            {
                if (IsElementDisplayed())
                {
                    BrowserManager.GetDriver().SwitchTo().Frame(GetWebElement());
                    action.Invoke();
                }
            }
            finally 
            {
                BrowserManager.GetDriver().SwitchTo().DefaultContent();
            }
        }

        public T DoInFrameIfPresent<T>(Func<T> func)
        {
            try
            {
                if (IsElementDisplayed())
                {
                    BrowserManager.GetDriver().SwitchTo().Frame(GetWebElement());
                    return func();
                }
                else return default(T);
            }
            catch
            {
                return default(T);
            }
            finally
            {
                BrowserManager.GetDriver().SwitchTo().DefaultContent();
            }
        }
    }
}
