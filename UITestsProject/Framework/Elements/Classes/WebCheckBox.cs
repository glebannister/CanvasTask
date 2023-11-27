using Framework.Application;
using Framework.Constants;
using Framework.Elements.Interfaces;
using Framework.Enums;
using Framework.Logging;
using Framework.Waits;
using OpenQA.Selenium;

namespace Framework.Elements.Classes
{
    public class WebCheckBox : BaseWebUiElement, IWebCheckBox
    {
        public WebCheckBox(By locator, string elementName, ElementState elementState = ElementState.Displayed)
            : base(locator, elementName, elementState)
        {
        }

        public void SetCheckBoxesValues(int amountOfItems, bool value)
        {
            FrameworkLogger.Info($"Set check boxes values to check box by Locator[{Locator}] and Name{ElementName}");
            GetWebElements()
                .Take(amountOfItems)
                .ToList()
                .ForEach(item => SetCheckBoxValue(item, value));
        }

        private void SetCheckBoxValue(IWebElement checkBox, bool value)
        {
            ExplicitWait.WaitForCondition(() =>
            {
                checkBox.Click();
                return checkBox.Selected == value;
            }, TimeSpan.FromSeconds(TimeOutConfigurations.DefaultRetryForTimeout));
        }
    }
}
