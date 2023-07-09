using Framework.Elements;
using Framework.Page;
using OpenQA.Selenium;
using UITestsProject.Interfaces;

namespace UITestsProject.Pages
{
    public class AuthorizationPage : BaseWebPage, IPassAuthorization
    {
        private WebTextField UserNameTextField => new WebTextField(By.Id("login_user"), "UserName text field");
        private WebTextField PasswordTextField => new WebTextField(By.Id("login_pass"), "Password text field");


        public AuthorizationPage() 
            : base(new WebButton(By.Id("login_button"), "Login button"), "Login Page") 
        {
        }

        public void PassAuthorization(string userName, string password)
        {
            if (!IsPageOpened()) throw new Exception("AuthorizationPage is not displayed");
            UserNameTextField.ClearText();
            UserNameTextField.SetText(userName);
            PasswordTextField.ClearText();
            PasswordTextField.SetText(password);
            uniqePageElement.Click();
        }
    }
}
