using Framework.Elements;
using Framework.Page;
using OpenQA.Selenium;

namespace UITestsProject.Pages
{
    public class LoginPage : BaseWebPage
    {
        public LoginPage() 
            : base(new WebButton(By.Id("login_button"), "Login button"), "Login Page") 
        { }
    }
}
