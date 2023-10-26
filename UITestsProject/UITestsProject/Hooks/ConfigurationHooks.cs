using TechTalk.SpecFlow;
using UITestsProject.Configuration;

namespace UITestsProject.Hooks
{
    [Binding]
    public class ConfigurationHooks
    {
        [BeforeTestRun(Order = 0)]
        public static void SetFrameworkConfiguration()
        {
            new DataProvider().SetFrameworkSettingsData();
        }
    }
}
