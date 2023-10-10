using Newtonsoft.Json.Linq;
using System.Net.Http.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Framework.Utils
{
    public static class FrameworkJsonUtil
    {
        private const string ResourcesFolder = "Resources";
        private const string AppSettingsJson = "appsetings.json";

        public static T? GetValueFromAppettingsFile<T> (string key)
        {
            var pathToAppsetingsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ResourcesFolder, AppSettingsJson);
            var json = File.ReadAllText(pathToAppsetingsFile);
            var token = JObject.Parse(json)[key];
            return token != null ? token.ToObject<T>() : default(T);
        }

        public static JsonContent SerializeToJsonContent<T> (T data) 
        {
            var jsonString = JsonSerializer.Serialize(data);
            return JsonContent.Create(jsonString);
        }
    }
}
