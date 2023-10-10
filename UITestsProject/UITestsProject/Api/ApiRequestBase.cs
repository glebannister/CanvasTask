using System.Net.Http.Json;

namespace UITestsProject.Utils
{
    internal abstract class ApiRequestBase
    {
        private const string ApplicationJsonValue = "application/json";
        protected string BaseUrl { get; set; }

        public ApiRequestBase(string baseUrl)
        {
            BaseUrl = baseUrl;
        }

        public virtual async Task<HttpResponseMessage> PostRequest(JsonContent content)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("HttpContent", ApplicationJsonValue);
                return await httpClient.PostAsync(BaseUrl, content).ConfigureAwait(false);
            }
        }
    }
}
