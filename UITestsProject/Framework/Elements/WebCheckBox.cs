﻿using Framework.Constants;
using Framework.Enums;
using Framework.Logging;
using Framework.Utils;
using Framework.Waits;
using OpenQA.Selenium;

namespace Framework.Elements
{
    public class WebCheckBox : BaseWebUiElement
    {
        public WebCheckBox(By locator, string elementName, SearchTypeEnum searchType = SearchTypeEnum.Single) 
            : base(locator, elementName, searchType)
        {
        }

        public void SetCheckBoxesValues(int amountOfItems, bool value) 
        {
            FrameworkLogger.Info($"Set check boxes values to check box by Locator[{locator}] and Name{ElementName}");
            WebElements
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
            }, TimeSpan.FromSeconds(FrameworkJsonUtil.GetValueFromAppettingsFile<double>(FrameworkConstants.DefaultConditionWaitIntervalKey)));
        }
    }
}
