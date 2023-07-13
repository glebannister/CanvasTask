using BoDi;
using Framework.Utils;
using TechTalk.SpecFlow;
using UITestsProject.Interfaces;
using UITestsProject.Pages;

namespace UITestsProject.Steps
{
    [Binding]
    internal class AuthorizationSteps
    {
        private const string UserNameKey = "User";
        private const string PasswordKey = "Password";
        private ScenarioContext _scenarioContext;
        private IPassAuthorization _passAuthorization;

        public AuthorizationSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("I pass the authorization")]
        public void PassTheAuthorization() 
        {
            var scenarionTags = _scenarioContext.ScenarioInfo.Tags;
            switch (scenarionTags) 
            {
                case var _ when scenarionTags.Contains("UIAuthorization"):
                    _passAuthorization = new AuthorizationPage();
                    break;
                case var _ when scenarionTags.Contains("ApiAuthorization"):
                    throw new NotImplementedException();
                default: throw new NotImplementedException("The FF has any authorization steps");
            }
            var userName = FrameworkJsonUtil.GetValueFromAppettingsFile<string>(UserNameKey);
            var password = FrameworkJsonUtil.GetValueFromAppettingsFile<string>(PasswordKey);
            _passAuthorization.PassAuthorization(userName, password);
        }
    }
}
