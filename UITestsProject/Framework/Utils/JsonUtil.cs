using Newtonsoft.Json.Linq;

namespace Framework.Utils
{
    internal static class JsonUtil
    {
        private const string ResourcesFolder = "Resources";
        private const string AppSettingsJson = "appsetings.json";

        public static string GetValueFromAppettingsFile(string key) 
        {
            var pathToAppsetingsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ResourcesFolder, AppSettingsJson);
            var json = File.ReadAllText(pathToAppsetingsFile);
            if ((string)JObject.Parse(json)[key] == null) 
            {
                throw new NullReferenceException($"There aren't any values with {key} key in {AppSettingsJson} file");
            }
            return (string)JObject.Parse(json)[key];
        }
    }
}
