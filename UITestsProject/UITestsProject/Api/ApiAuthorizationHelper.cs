using UITestsProject.Configuration;
using UITestsProject.Interfaces;
using UITestsProject.Models;
using UITestsProject.Utils;

namespace UITestsProject.Api
{
    internal class ApiAuthorizationHelper : ApiRequestBase, IPassAuthorization
    {
        private DataProvider _dataProvider = new DataProvider();

        public ApiAuthorizationHelper(string baseUrl) : base(baseUrl)
        {
        }

        public void PassAuthorization(AuthUserModel authUserModel)
        {
            var requestContent = _dataProvider.SerializeToJsonContent(authUserModel);
            var responce = base.PostRequest(requestContent).Result;
            if (!responce.IsSuccessStatusCode) 
            {
                throw new Exception($"Authorization for {BaseUrl} has failed");
            }
        }
    }
}
