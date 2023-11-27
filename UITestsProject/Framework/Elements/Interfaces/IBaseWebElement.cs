using Framework.Enums;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace Framework.Elements.Interfaces
{
    public interface IBaseWebElement
    {
        public bool IsElementExists();

        public bool IsElementDisplayed();

        public bool IsElementEnabled();

        public void Click();

        public string GetText();

        public List<string> GetTexts();

        public int GetNumberOfFoundElements();

        public void Focus();

        public IWebElement GetWebElement();

        public ReadOnlyCollection<IWebElement> GetWebElements();

        ReadOnlyCollection<IWebElement> ReFindWebElements(ElementState state, bool setNewState);
    }
}
