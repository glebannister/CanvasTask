using BoDi;
using Framework.Elements;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Reflection.Emit;
using TechTalk.SpecFlow;
using UITestsProject.Pages;

namespace UITestsProject.Steps
{
    [Binding]
    public class CreatedContactPageSteps
    {
        private ScenarioContext _scenarioContext;
        private CreatedContactPage _createdContactPage;

        public CreatedContactPageSteps(ScenarioContext scenarioContext, IObjectContainer objectContainer) 
        {
            _scenarioContext = scenarioContext;
            _createdContactPage = objectContainer.Resolve<CreatedContactPage>();
        }

        [Then("Created contact page is opened")]
        public void CreatedContactPageIsOpened() 
        {
            Assert.IsTrue(_createdContactPage.IsPageOpened(), $"{_createdContactPage.PageName} is not opened!");
        }
    }
}
