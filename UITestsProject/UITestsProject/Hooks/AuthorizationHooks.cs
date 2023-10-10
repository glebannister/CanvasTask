using TechTalk.SpecFlow;
using UITestsProject.Api;
using UITestsProject.Constants.TestDataConstants;
using UITestsProject.Interfaces;
using UITestsProject.Models;
using UITestsProject.Pages;

namespace UITestsProject.Hooks
{
    [Binding]
    internal class AuthorizationHooks
    {
        private const string UIAuthorizationTag = "UIAuthorization";
        private const string ApiAuthorizationTag = "ApiAuthorization";
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
                    _passAuthorization = new ApiAuthorizationHelper(ApiConfigurations.LoginUrl);
                    break;
                default: throw new NotImplementedException("The FF has any authorization steps");
            }
            _passAuthorization.PassAuthorization(InitializeAuthModel());
        }

        private AuthUserModel InitializeAuthModel() => new AuthUserModel()
        {
            UserName = TestDataConstants.TestUserName,
            Password = TestDataConstants.TestUserPassword
        };
    }
}
