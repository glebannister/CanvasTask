using BoDi;
using NUnit.Framework;
using TechTalk.SpecFlow;
using UITestsProject.Constants.TestProjectConstants;
using UITestsProject.Pages;

namespace UITestsProject.Steps
{
    [Binding]
    internal class ActivityLogBrowseAllSteps
    {
        private ScenarioContext _scenarioContext;
        private ActivityLogBrowseAllPage _activityLogBrowseAllPage;

        public ActivityLogBrowseAllSteps(ScenarioContext scenarioContext, IObjectContainer objectContainer) 
        {
            _scenarioContext = scenarioContext;
            _activityLogBrowseAllPage = objectContainer.Resolve<ActivityLogBrowseAllPage>();
        }

        [When(@"I delete first '(.*)' items in the table")]
        public void DeleteFirstItemsInTheTable(int amountOfItemsToDetele) 
        {
            _scenarioContext.Add(ScenarioContextConstants.ActivitiesToDeleteNames, _activityLogBrowseAllPage.GetItemsToDeleteNames(amountOfItemsToDetele));
            _activityLogBrowseAllPage.DeleteFirstItemsFormTheTable(amountOfItemsToDetele);
        }

        [Then("Activity log browser all page is opened")]
        public void IsActivityLogBrowserAllPageOpened() 
        {
            Assert.IsTrue(_activityLogBrowseAllPage.IsPageOpened(), $"{_activityLogBrowseAllPage.PageName} is not opened");
        }

        [Then("The items has been deleted")]
        public void ItemsHasBeenDeleted() 
        {
            Assert.Multiple(() =>
            {
                CheckIfActivitiesHasBeenDeleted();
            });
        }

        private void CheckIfActivitiesHasBeenDeleted() 
        {
            var listOfDeletedItems = _scenarioContext.Get<List<string>>(ScenarioContextConstants.ActivitiesToDeleteNames);
            listOfDeletedItems.ForEach(itemName =>
            {
                Assert.IsTrue(_activityLogBrowseAllPage.IsSpesificActivityNotExist(itemName), $"Activity {itemName} is still exists!");
            });
        }
    }
}
