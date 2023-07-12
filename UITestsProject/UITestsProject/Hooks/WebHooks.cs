﻿using Framework.Application;
using Framework.Utils;
using TechTalk.SpecFlow;

namespace UITestsProject.Hooks
{
    [Binding]
    public class WebHooks
    {
        private const string QuiteWebDriverTag = "QuiteWebDriver";
        private const string UrlKey = "CrmUrl";
        private const string CrmUiTestTag = "CrmUiTest";
        private ScenarioContext _scenarioContext;

        public WebHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario(Order = 0)]
        public void NavigateToTheResource() 
        {
            var scenarionTags = _scenarioContext.ScenarioInfo.Tags;
            switch (scenarionTags)
            {
                case var _ when scenarionTags.Contains(CrmUiTestTag):
                    var crmUrl = FrameworkJsonUtil.GetValueFromAppettingsFile<string>(UrlKey);
                    BrowserManager.NavigateToUrl(crmUrl);
                    break;
                default: throw new NotImplementedException("The type of test has not been defined");
            }
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
