using Framework.Application;
using Framework.Utils;
using TechTalk.SpecFlow;

namespace UITestsProject.Steps
{
    [Binding]
    internal class BrowserSteps
    {
        private const string UrlKey = "CrmUrl";

        [Given("I navigate to CRM login page")]
        public void NavigateToCRMLoginPage() 
        {
            var crmUrl = new AppSettings().GetConfigurationOnlyFileValue<string>(UrlKey);
            BrowserManager.NavigateToUrl(crmUrl);
        }
    }
}
