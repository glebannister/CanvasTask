using BoDi;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
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

        [Then("Contacts page is opened")]
        public void ContactsPageIsOpened() 
        {
            Assert.IsTrue(_contactsPage.IsPageOpened(), $"{_contactsPage.PageName} is not opened!");
        }

        [When("I click on Create button")]
        public void ClickOnCreateButton() 
        {
            _contactsPage.ClickCreateButton();
        }
    }
}
