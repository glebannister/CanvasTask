﻿using BoDi;
using NUnit.Framework;
using TechTalk.SpecFlow;
using UITestsProject.Constants.TestProjectConstants;
using UITestsProject.Models;
using UITestsProject.Pages;

namespace UITestsProject.Steps
{
    [Binding]
    internal class CreatingContactPageSteps
    {
        private ScenarioContext _scenarioContext;
        private CreatingContactPage  _newContactPage;

        public CreatingContactPageSteps(ScenarioContext scenarioContext, IObjectContainer objectContainer) 
        {
            _scenarioContext = scenarioContext;
            _newContactPage = objectContainer.Resolve<CreatingContactPage>();
        }

        [When("I create a new contact")]
        public void CreateNewContact(ContractUserModel contractUserModel) 
        {
            _scenarioContext.Add(ScenarioContextConstants.ContactUserModel, contractUserModel);
            var customersCategoryArray = contractUserModel.CustomersCategory.Split(',');
            _newContactPage
                .CreateNewContact(contractUserModel.FirstName, contractUserModel.LastName, contractUserModel.Role.ToString(), customersCategoryArray);
        }

        [When("I save a new contact")]
        public void SaveNewContact() 
        {
            _newContactPage.SaveNewContact();
        }

        [Then("New contact page is opened")]
        public void NewContactPageIsOpened() 
        {
            Assert.IsTrue(_newContactPage.IsPageOpened(), $"{_newContactPage.PageName} is not opened!");
        }
    }
}
