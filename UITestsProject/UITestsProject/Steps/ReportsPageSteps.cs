using BoDi;
using NUnit.Framework;
using TechTalk.SpecFlow;
using UITestsProject.Pages;

namespace UITestsProject.Steps
{
    [Binding]
    internal class ReportsPageSteps
    {
        private ScenarioContext _scenarioContext;
        private AllReportsPage _reportsPage;

        public ReportsPageSteps(ScenarioContext scenarioContext, IObjectContainer objectContainer)
        {
            _scenarioContext = scenarioContext;
            _reportsPage = objectContainer.Resolve<AllReportsPage>();
        }

        [Then("Reports page is opened")]
        public void ReportsPageIsOpened()
        {
            Assert.IsTrue(_reportsPage.IsPageOpened(), $"{_reportsPage.PageName} is not opened!");
        }

        [Then(@"I find '(.*)' report")]
        public void IFindReportByName(string reportName)
        {
            _reportsPage.IsReportExistsInTheTable(reportName);
        }

        [When(@"I go to report '(.*)' page")]
        public void GoToReportPage(string reportName) 
        {
            _reportsPage.ClickOnSpesificProject(reportName);
        }
    }
}
