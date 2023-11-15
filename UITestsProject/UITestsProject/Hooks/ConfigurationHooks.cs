using Framework.Utils;
using System.Diagnostics;
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

        [AfterTestRun]
        public static void GenerateReport() 
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = @"allure serve allure-results\",
                WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory,
            };
            ProcessUtil.RunProcess(startInfo);
        }
    }
}
