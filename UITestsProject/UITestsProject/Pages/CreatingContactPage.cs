using Framework.Application;
using Framework.Constants;
using Framework.Elements;
using Framework.Page;
using Framework.Waits;
using OpenQA.Selenium;
using UITestsProject.Extensions;

namespace UITestsProject.Pages
{
    internal class CreatingContactPage : BaseWebPage
    {
        private WebTextField FirstNameTextField => new WebTextField(By.XPath("//input[@name='first_name']"), "First name text field");
        private WebTextField LastNameTextField => new WebTextField(By.XPath("//input[@name='last_name']"), "Last name text field");
        private WebTextField BusinessRoleTextField => new WebTextField(By.Id("DetailFormbusiness_role-input"), "Business role text field");
        private WebButton CustomersCategoryButton => new WebButton(By.Id("DetailFormcategories-input"), "Customers category button");
        private WebTextField CustomersCategoryTextBox => new WebTextField(By.XPath("//div[contains(@class, 'popup-search') and contains(@class, 'tools-row')]//input"), "Customers category text box");
        private WebButton SaveNewContactButton => new WebButton(By.Id("DetailForm_save2"), "Save new contact button");
        private WebButton SpesificBusinessRoleButton(string spesificRole) => new WebButton(By.XPath($"//div[text()='{spesificRole}']"), $"{spesificRole} button");
        private WebButton SpesificCategoryButton(string spesificCategory) => new WebButton(By.XPath($"//div[text()='{spesificCategory}']"), $"{spesificCategory} button");

        public CreatingContactPage() 
            : base(new WebLabel(By.Id("DetailFormphoto-input"), "Photo label"), "Creating contact page")
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
            var isSettingContactsRoleSuccessful = ExplicitWait.WaitForCondition(() =>
            {
                try
                {
                    BusinessRoleTextField.Focus();
                    BusinessRoleTextField.SetText(role);
                    SpesificBusinessRoleButton(role).Click();
                    return true;
                }
                catch (NullReferenceException)
                {
                    return false;
                }
            }, TimeSpan.FromSeconds(TimeOutConfigurations.DefaultRetryForTimeout));
            if (!isSettingContactsRoleSuccessful) throw new Exception("Setting contacts role action was not successful");
        }

        private void SetContactsCustomersCategories(string[] customersCategorys) 
        {
            customersCategorys.ToList().ForEach(category =>
            {
                CustomersCategoryButton.Focus();
                ExplicitWait.WaitForCondition(() => CustomersCategoryButton.IsElementEnabled(),
                    TimeSpan.FromSeconds(TimeOutConfigurations.DefaultRetryForTimeout));
                CustomersCategoryButton.Click();
                CustomersCategoryTextBox.SetText(category.RemoveAllSpaces());
                SpesificCategoryButton(category.RemoveAllSpaces()).Click();
            });
        }
    }
}
