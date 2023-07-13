using BoDi;
using TechTalk.SpecFlow;
using UITestsProject.Enums;
using UITestsProject.Pages;

namespace UITestsProject.Steps
{
    [Binding]
    internal class HomePageAndActionsNavigationSteps
    {
        private HomeAndActionsPage _homeAndActionsPage;

        public HomePageAndActionsNavigationSteps(IObjectContainer objectContainer)
        {
            _homeAndActionsPage = objectContainer.Resolve<HomeAndActionsPage>();
        }

        [When(@"I go to '(SalesMarketing|ReportsSettings)' and '(.*)' page")]
        public void GoToSalesAndMarketingSpesificPage(NavigationEnum containerSection, NavigationEnum spesificPage)
        {
            switch (containerSection)
            {
                case NavigationEnum.SalesMarketing:
                    _homeAndActionsPage.ClickOnItemInSalesAndMarketingContainer(spesificPage.ToString());
                    break;
                case NavigationEnum.ReportsSettings:
                    _homeAndActionsPage.ClickOnItemInReportsSettingsContainer(spesificPage.ToString());
                    break;
                default: throw new NotImplementedException($"{containerSection} hasn't any implementation");
            }
        }
    }
}
