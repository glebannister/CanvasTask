using Framework.Elements;
using Framework.Page;
using OpenQA.Selenium;

namespace UITestsProject.Pages
{
    public class ContactsPage : BaseWebPage
    {
        private WebButton CreateButton => new WebButton(By.XPath("//button[@name='SubPanel_create']"), "Create button");
        private WebTable ContactsTable => new WebTable(By.XPath("//table[@class='listView']"), "Contacts table");

        public ContactsPage() 
            : base(new WebLabel(By.XPath("//span[text()='Contacts']"), "Contacts label"), "Contacts Page")
        {
        }

        public void ClickCreateButton() 
        {
            CreateButton.Click();
        }

        public string GetTableCellValue(int cellIndex, string columName) => ContactsTable.GetColumnValue(cellIndex, columName);
    }
}
