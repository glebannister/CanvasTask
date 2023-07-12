using System.Text;

namespace UITestsProject.Utils
{
    internal abstract class ApiRequestBase
    {
        private const string EndpointValue = "endpoint";
        private const string ApplicationJsonValue = "application/json";
        protected string BaseUrl { get; set; }

        public ApiRequestBase(string baseUrl)
        {
            BaseUrl = baseUrl;
        }

        public virtual async Task<HttpResponseMessage> PostRequest(string stringContent)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(BaseUrl);
                var request = SetStringHttpContent(HttpMethod.Post, stringContent);
                return await httpClient.SendAsync(request).ConfigureAwait(false);
            }
        }

        private HttpRequestMessage SetStringHttpContent(HttpMethod httpMethod, string content) 
        {
            return new HttpRequestMessage(httpMethod, EndpointValue)
            {
                Content = new StringContent(content, Encoding.UTF8, ApplicationJsonValue)
            };
        }
    }
}
