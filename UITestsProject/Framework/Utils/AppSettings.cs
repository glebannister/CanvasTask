namespace Framework.Utils
{
    public class AppSettings : FrameworkJsonHelper
    {
        private const string ResourcesFolder = "Resources";
        private const string AppSettingsJson = "appsetings.json";

        public string GetConfigurationValueWithEnvVariables(string key)
        {
            return EnvironmentVariablesUtil.GetEnviromentVariableFromAllTargets(key) 
                ?? GetValueFromJsonFile<string>(key, ResourcesFolder, AppSettingsJson);
        }

        public T GetConfigurationOnlyFileValue<T>(string key) 
        {
            return GetValueFromJsonFile<T>(key, ResourcesFolder, AppSettingsJson);
        }
    }
}
