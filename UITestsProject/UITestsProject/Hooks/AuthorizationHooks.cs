using Framework.Utils;
using TechTalk.SpecFlow;
using UITestsProject.Api;
using UITestsProject.Interfaces;
using UITestsProject.Pages;

namespace UITestsProject.Hooks
{
    [Binding]
    public class AuthorizationHooks
    {
        private const string UrlKey = "CrmUrl";
        private const string UIAuthorizationTag = "UIAuthorization";
        private const string ApiAuthorizationTag = "ApiAuthorization";
        private const string UserNameKey = "User";
        private const string PasswordKey = "Password";
        private IPassAuthorization _passAuthorization;
        private ScenarioContext _scenarioContext;

        public AuthorizationHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario(Order = 1)]
        public void PassTheAuthorization() 
        {
            var scenarionTags = _scenarioContext.ScenarioInfo.Tags;
            switch (scenarionTags)
            {
                case var _ when scenarionTags.Contains(UIAuthorizationTag):
                    _passAuthorization = new AuthorizationPage();
                    break;
                case var _ when scenarionTags.Contains(ApiAuthorizationTag):
                    _passAuthorization = new ApiAuthorizationHelper(FrameworkJsonUtil.GetValueFromAppettingsFile<string>(UrlKey));
                    break;
                default: throw new NotImplementedException("The FF has any authorization steps");
            }
            var userName = FrameworkJsonUtil.GetValueFromAppettingsFile<string>(UserNameKey);
            var password = FrameworkJsonUtil.GetValueFromAppettingsFile<string>(PasswordKey);
            _passAuthorization.PassAuthorization(userName, password);
        }
    }
}
