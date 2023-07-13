using BoDi;
using NUnit.Framework;
using TechTalk.SpecFlow;
using UITestsProject.Pages;

namespace UITestsProject.Steps
{
    [Binding]
    internal class HomeAndActionsPageSteps
    {
        private HomeAndActionsPage _homeAndActionsPage;

        public HomeAndActionsPageSteps(IObjectContainer objectContainer) 
        {
            _homeAndActionsPage = objectContainer.Resolve<HomeAndActionsPage>();
        }

        [Given("Home and Actions page is opened")]
        public void HomeAndActionsPageIsOpened() 
        {
            Assert.True(_homeAndActionsPage.IsPageOpened(), $"{_homeAndActionsPage.PageName} is not opened!");
        }
    }
}
