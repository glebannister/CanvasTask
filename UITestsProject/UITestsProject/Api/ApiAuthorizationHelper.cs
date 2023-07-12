using UITestsProject.Interfaces;
using UITestsProject.Utils;

namespace UITestsProject.Api
{
    internal class ApiAuthorizationHelper : ApiRequestBase, IPassAuthorization
    {
        private string authorizationContentPattern = "/username={0}&password={1}";

        public ApiAuthorizationHelper(string baseUrl) : base(baseUrl)
        {
        }

        public void PassAuthorization(string userName, string password)
        {
            var authorizationContent = string.Format(authorizationContentPattern, userName, password);
            var responce = base.PostRequest(authorizationContent).Result;
            if (!responce.IsSuccessStatusCode) 
            {
                throw new Exception($"Authorization for {BaseUrl} has failed");
            }
        }
    }
}
