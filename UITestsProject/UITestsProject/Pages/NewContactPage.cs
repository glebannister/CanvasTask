using Framework.Constants;
using Framework.Elements.Classes;
using Framework.Page;
using Framework.Waits;
using OpenQA.Selenium;

namespace UITestsProject.Pages
{
    public class NewContactPage : BaseWebPage
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
            ExplicitWait.SleepWait(TimeOutConfigurations.DefaultIntervalTimeout);
            ExplicitWait.WaitForCondition(() => FirstLastNameLabel.IsElementDisplayed() && FirstLastNameLabel.IsElementEnabled(),
                TimeSpan.FromSeconds(TimeOutConfigurations.DefaultRetryForTimeout));
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
