﻿using Framework.Application;
using Framework.Utils;
using TechTalk.SpecFlow;

namespace UITestsProject.Hooks
{
    [Binding]
    internal class WebHooks
    {
        private const string QuiteWebDriverTag = "QuitWebDriver";
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
                    var crmUrl = new AppSettings().GetConfigurationOnlyFileValue<string>(UrlKey);
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
