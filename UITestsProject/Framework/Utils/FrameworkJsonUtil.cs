using Newtonsoft.Json.Linq;

namespace Framework.Utils
{
    public static class FrameworkJsonUtil
    {
        private const string ResourcesFolder = "Resources";
        private const string AppSettingsJson = "appsetings.json";

        public static T GetValueFromAppettingsFile<T>(string key)
        {
            var pathToAppsetingsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ResourcesFolder, AppSettingsJson);
            var json = File.ReadAllText(pathToAppsetingsFile);
            var token = JObject.Parse(json)[key];
            return token != null ? token.ToObject<T>() : default(T);
        }
    }
}
