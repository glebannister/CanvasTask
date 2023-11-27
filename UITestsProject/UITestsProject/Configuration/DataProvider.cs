using Framework.Configurations;
using Framework.Constants;
using Framework.Helpers;
using Framework.Utils;
using Newtonsoft.Json.Linq;
using System.Net.Http.Json;
using System.Text.Json;

namespace UITestsProject.Configuration
{
    public class DataProvider : IJsonReader
    {
        private const string ResourcesFolder = "Resources";
        private const string AppSettingsJson = "appsetings.json";
        private const string TimeoutsJson = "timeouts.json";
        private const string ReportingJson = "reporting.json";

        public void SetFrameworkSettingsData() 
        {
            DriverConfigurations.BrowserName = GetConfigurationValueWithEnvVariables("Browser",ResourcesFolder, AppSettingsJson);
            DriverConfigurations.PageLoadTimeOut = GetValueFromJsonFile<int>("PageLoadTimeOut", ResourcesFolder, AppSettingsJson);
            DriverConfigurations.ChromeOptions = GetValueFromJsonFile<IEnumerable<string>>("ChromeOptions", ResourcesFolder, AppSettingsJson);
            DriverConfigurations.WindowWidth = GetValueFromJsonFile<int>("WindowWidth", ResourcesFolder, AppSettingsJson);
            DriverConfigurations.WindowHeight = GetValueFromJsonFile<int>("WindowHeight", ResourcesFolder, AppSettingsJson);
            TimeOutConfigurations.DefaultRetryForTimeout = GetValueFromJsonFile<double>("DefaultConditionWaitTime", ResourcesFolder, TimeoutsJson);
            TimeOutConfigurations.DefaultIntervalTimeout = GetValueFromJsonFile<double>("DefaultInterval", ResourcesFolder, TimeoutsJson);
            TimeOutConfigurations.SearchForElementTimeout = GetValueFromJsonFile<double>("DefaultTimeoutForFindingElement", ResourcesFolder, TimeoutsJson);
            ReportingConfiguration.RunAllureReport = GetValueFromJsonFile<bool>("RunAllureReport", ResourcesFolder, ReportingJson);
        }

        public string GetConfigurationValueWithEnvVariables(string key, string resourceFolder, string fileName)
        {
            return EnvironmentVariablesUtil.GetEnvironmentVariableFromAllTargets(key)
                ?? GetValueFromJsonFile<string>(key, resourceFolder, fileName);
        }

        public T GetValueFromJsonFile<T>(string key, string resourceFolder, string fileName)
        {
            var pathToAppsetingsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, resourceFolder, fileName);
            var json = File.ReadAllText(pathToAppsetingsFile);
            var token = JObject.Parse(json)[key];
            return token != null ? token.ToObject<T>() : default;
        }

        public JsonContent SerializeToJsonContent<T>(T data)
        {
            var jsonString = JsonSerializer.Serialize(data);
            return JsonContent.Create(jsonString);
        }
    }
}
