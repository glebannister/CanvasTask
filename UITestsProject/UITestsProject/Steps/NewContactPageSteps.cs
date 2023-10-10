using BoDi;
using NUnit.Framework;
using TechTalk.SpecFlow;
using UITestsProject.Constants.TestProjectConstants;
using UITestsProject.Extensions;
using UITestsProject.Models;
using UITestsProject.Pages;

namespace UITestsProject.Steps
{
    [Binding]
    internal class NewContactPageSteps
    {
        private ScenarioContext _scenarioContext;
        private NewContactPage _createdContactPage;

        public NewContactPageSteps(ScenarioContext scenarioContext, IObjectContainer objectContainer) 
        {
            _scenarioContext = scenarioContext;
            _createdContactPage = objectContainer.Resolve<NewContactPage>();
        }

        [Then("Created contact page is opened")]
        public void CreatedContactPageIsOpened() 
        {
            Assert.IsTrue(_createdContactPage.IsPageOpened(), $"{_createdContactPage.PageName} is not opened!");
        }

        [Then("I check that the contact has proper values")]
        public void CheckThatContactHasProperValues()
        {
            var expectedContactValues = _scenarioContext.Get<ContractUserModel>(ScenarioContextConstants.ContactUserModel);
            var firstLastNameActual = _createdContactPage.GetFirstLastNameOfNewContact().RemoveAllSpaces();
            var businessRoleActual = _createdContactPage.GetBusinessRoleOfNewContact();
            var categoriesActual = _createdContactPage.GetCategoriesOfNewContact().NormoizeCategoriesValue();
            Assert.Multiple(() => 
            {
                Assert.AreEqual($"{expectedContactValues.FirstName}{expectedContactValues.LastName}", firstLastNameActual, "Actual contact's first and last name don't match the expected ones");
                Assert.AreEqual(expectedContactValues.Role.ToString(), businessRoleActual, "Actual contact's role doesn't match the expected one");
                Assert.AreEqual(expectedContactValues.CustomersCategory.RemoveAllSpaces(), categoriesActual, "Actual categories don't match the expected ones");
            });
        }
    }
}
