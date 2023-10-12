using Newtonsoft.Json.Linq;
using System.Net.Http.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Framework.Helpers
{
    public class FrameworkJsonHelper
    {
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
