using Framework.Application;
using Framework.Elements;
using Framework.Page;
using Framework.Utils;
using Framework.Waits;
using OpenQA.Selenium;
using UITestsProject.Constants;
using UITestsProject.Extensions;

namespace UITestsProject.Pages
{
    public class NewContactPage : BaseWebPage
    {
        private const string KeyForDefaultFindElementTimeout = "DefaulTimeoutForFindingElement";
        private WebTextField FirstNameTextField => new WebTextField(By.XPath("//input[@name='first_name']"), "First name text field");
        private WebTextField LastNameTextField => new WebTextField(By.XPath("//input[@name='last_name']"), "Last name text field");
        private WebTextField BusinessRoleTextField => new WebTextField(By.Id("DetailFormbusiness_role-input"), "Business role text field");
        private WebButton CustomersCategoryButton => new WebButton(By.Id("DetailFormcategories-input"), "Customers category button");
        private WebTextField CustomersCategoryTextBox => new WebTextField(By.XPath("//div[contains(@class, 'popup-search') and contains(@class, 'tools-row')]//input"), "Customers category text box");
        private WebButton SaveNewContactButton => new WebButton(By.Id("DetailForm_save2"), "Save new contact button");
        private WebButton SpesificBusinessRoleButton(string spesificRole) => new WebButton(By.XPath($"//div[text()='{spesificRole}']"), $"{spesificRole} button");
        private WebButton SpesificCategoryButton(string spesificCategory) => new WebButton(By.XPath($"//div[text()='{spesificCategory}']"), $"{spesificCategory} button");

        public NewContactPage() 
            : base(new WebLabel(By.Id("DetailFormphoto-input"), "Photo label"), "New contact page")
        {
        }

        public void CreateNewContact(string firstName, string lastName, string role, string[] customersCategories)
        {
            FirstNameTextField.SetText(firstName);
            LastNameTextField.SetText(lastName);
            SetContactsRole(role);
            SetContactsCustomersCategories(customersCategories);
        }

        public void SaveNewContact() 
        {
            SaveNewContactButton.Click();
        }

        private void SetContactsRole(string role) 
        {
            BusinessRoleTextField.Focus();
            BusinessRoleTextField.SetText(role);
            SpesificBusinessRoleButton(role).Click();
        }

        private void SetContactsCustomersCategories(string[] customersCategorys) 
        {
            BrowserManager.ExecuteJsScript(JSScripts.ScrollToElementScript, CustomersCategoryButton.WebElement);
            var timeOut = FrameworkJsonUtil.GetValueFromAppettingsFile<double>(KeyForDefaultFindElementTimeout);
            customersCategorys.ToList().ForEach(category =>
            {
                ExplicitWait.WaitForCondition(() => CustomersCategoryButton.IsElementEnabled(), TimeSpan.FromSeconds(timeOut));
                CustomersCategoryButton.Click();
                CustomersCategoryTextBox.SetText(category.RemoveAllSpaces());
                SpesificCategoryButton(category.RemoveAllSpaces()).Click();
            });
        }
    }
}
