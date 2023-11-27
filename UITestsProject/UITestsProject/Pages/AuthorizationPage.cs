using Framework.Elements.Classes;
using Framework.Page;
using OpenQA.Selenium;
using UITestsProject.Interfaces;
using UITestsProject.Models;

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

        public void PassAuthorization(AuthUserModel authUserModel)
        {
            if (!IsPageOpened()) throw new Exception("AuthorizationPage is not displayed");
            UserNameTextField.ClearText();
            UserNameTextField.SetText(authUserModel.UserName);
            PasswordTextField.ClearText();
            PasswordTextField.SetText(authUserModel.Password);
            uniqePageElement.Click();
        }
    }
}
