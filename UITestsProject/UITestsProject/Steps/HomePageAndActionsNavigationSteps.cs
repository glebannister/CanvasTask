using BoDi;
using TechTalk.SpecFlow;
using UITestsProject.Pages;

namespace UITestsProject.Steps
{
    [Binding]
    public class HomePageAndActionsNavigationSteps
    {
        private HomeAndActionsPage _homeAndActionsPage;

        public HomePageAndActionsNavigationSteps(IObjectContainer objectContainer)
        {
            _homeAndActionsPage = objectContainer.Resolve<HomeAndActionsPage>();
        }

        [When(@"I go to Sales & Marketing '(.*)'")]
        public void GoToSalesAndMarketingSpesificPage(string pageName)
        {
            _homeAndActionsPage.ClickOnItemInSalesAndMarketingContainer(pageName);
        }
    }
}
