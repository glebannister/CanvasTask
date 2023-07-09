using Framework.Application;
using TechTalk.SpecFlow;

namespace UITestsProject.Hooks
{
    [Binding]
    public class WebHooks
    {
        private const string QuiteWebDriverTag = "QuiteWebDriver";
        private ScenarioContext _scenarioContext;

        public WebHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [AfterScenario(Order = 0)]
        public void QuiteWebDriver() 
        {
            if (_scenarioContext.ScenarioInfo.Tags.Contains(QuiteWebDriverTag)) 
            {
                BrowserManager.Quit();
            }
        }
    }
}
