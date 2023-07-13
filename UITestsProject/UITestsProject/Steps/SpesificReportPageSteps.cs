using BoDi;
using NUnit.Framework;
using TechTalk.SpecFlow;
using UITestsProject.Pages;

namespace UITestsProject.Steps
{
    [Binding]
    internal class SpesificReportPageSteps
    {
        private SpesificReportPage _spesificReportPage;

        public SpesificReportPageSteps(IObjectContainer objectContainer) 
        {
            _spesificReportPage = objectContainer.Resolve<SpesificReportPage>();    
        }

        [When("I run report")]
        public void RunReport() 
        {
            _spesificReportPage.ClickRunReportButton();
        }

        [Then("Spesific report page is opened")]
        public void SpesificReportPageIsOpened() 
        {
            Assert.IsTrue(_spesificReportPage.IsPageOpened(), $"{_spesificReportPage.PageName} page is not opened!");
        }

        [Then("Report has returned values")]
        public void ReportReturnedValues() 
        {
            Assert.IsTrue(_spesificReportPage.IsReportReturnedValues(), "Report didn't return any values");
        }
    }
}
