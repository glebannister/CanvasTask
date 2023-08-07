﻿using Framework.Application;
using Framework.Constants;
using Framework.Elements;
using Framework.Page;
using OpenQA.Selenium;

namespace UITestsProject.Pages
{
    internal class NewContactPage : BaseWebPage
    {
        private WebLabel FirstLastNameLabel => new WebLabel(By.Id("_form_header"), "FirstLast name label");
        private WebLabel BusinessRoleLabel => new WebLabel(
            By.XPath("//p[text()='Business Role']//ancestor::div[contains(@class,'form-entry') and contains(@class, 'label-left')]//div"),
            "Business role label");
        private WebLabel CategoriesLabel => new WebLabel(By.XPath("//ul[@class='summary-list']//li"), "Categories label");

        public NewContactPage() 
            : base(new WebLabel(By.XPath("//div[@class='buttons-inline']"), "Inline buttons"), "New contact contact page")
        {
        }

        public string GetFirstLastNameOfNewContact() 
        {
            BrowserManager
                .ExplicitWaits()
                .SleepWait(BaseConfigurations.DefaultIntervalTimeout);
            BrowserManager
                .ExplicitWaits()
                .WaitForCondition(() => 
                    FirstLastNameLabel.IsElementDisplayed() && FirstLastNameLabel.IsElementEnabled(),
                    TimeSpan.FromSeconds(BaseConfigurations.DefaultRetryForTimeout));
            return FirstLastNameLabel.GetText();
        }

        public string GetBusinessRoleOfNewContact() 
        {
            return BusinessRoleLabel.GetText();
        }

        public string GetCategoriesOfNewContact() 
        {
            return CategoriesLabel.GetText();
        }
    }
}
