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
    public class ActivityLogBrowseAllSteps
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
            _activityLogBrowseAllPage.DeleteFirstItemsFormTheTable();
        }

        [Then("Activity log browser all page is opened")]
        public void IsActivityLogBrowserAllPageOpened() 
        {
            Assert.IsTrue(_activityLogBrowseAllPage.IsPageOpened(), $"{_activityLogBrowseAllPage.PageName} is not opened");
        }
    }
}
