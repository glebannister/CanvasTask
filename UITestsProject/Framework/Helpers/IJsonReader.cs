using System.Net.Http.Json;

namespace Framework.Helpers
{
    public interface IJsonReader
    {
        public string GetConfigurationValueWithEnvVariables(string key, string resourceFolder, string fileName);

        public T GetValueFromJsonFile<T>(string key, string resourceFolder, string fileName);

        public JsonContent SerializeToJsonContent<T>(T data);
    }
}
