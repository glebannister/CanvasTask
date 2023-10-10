using BoDi;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UITestsProject.Models;
using UITestsProject.Pages;

namespace UITestsProject.Steps
{
    [Binding]
    internal class ContactsPageSteps
    {
        private ContactsPage _contactsPage;

        public ContactsPageSteps(IObjectContainer objectContainer) 
        {
            _contactsPage = objectContainer.Resolve<ContactsPage>();
        }

        [When("I click on Create button")]
        public void ClickOnCreateButton()
        {
            _contactsPage.ClickCreateButton();
        }

        [Then("Contacts page is opened")]
        public void ContactsPageIsOpened() 
        {
            Assert.IsTrue(_contactsPage.IsPageOpened(), $"{_contactsPage.PageName} is not opened!");
        }

        [Then("I verify contacts in contacts table")]
        public void IVerifyContactInContactsTable(IEnumerable<ContactUserModel> contactUsers) 
        {
            foreach (var contact in contactUsers) 
            {
                var value = _contactsPage.GetTableCellValue(contact.RowIndex, nameof(contact.Name));
            }
        }
    }
}
