using Framework.Elements;
using Framework.Page;
using Framework.Waits;
using OpenQA.Selenium;
using UITestsProject.Constants;

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
            ExplicitWait.WaitForCondition(() =>
            FirstLastNameLabel.GetText() != TestDataConstants.DefaultFirstLastNameWebText,
            TimeSpan.FromSeconds(Timeouts.DefaulConditionWaitTime));
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
