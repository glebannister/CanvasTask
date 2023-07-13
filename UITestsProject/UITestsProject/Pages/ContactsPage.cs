using Framework.Elements;
using Framework.Page;
using OpenQA.Selenium;

namespace UITestsProject.Pages
{
    internal class ContactsPage : BaseWebPage
    {
        private WebButton CreateButton => new WebButton(By.XPath("//button[@name='SubPanel_create']"), "Create button");

        public ContactsPage() 
            : base(new WebLabel(By.XPath("//span[text()='Contacts']"), "Contacts label"), "Contacts Page")
        {
        }

        public void ClickCreateButton() 
        {
            CreateButton.Click();
        }
    }
}
