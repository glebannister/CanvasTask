using Framework.Utils;
using UITestsProject.Interfaces;
using UITestsProject.Models;
using UITestsProject.Utils;

namespace UITestsProject.Api
{
    internal class ApiAuthorizationHelper : ApiRequestBase, IPassAuthorization
    {
        public ApiAuthorizationHelper(string baseUrl) : base(baseUrl)
        {
        }

        public void PassAuthorization(AuthUserModel authUserModel)
        {
            var requestContent = FrameworkJsonUtil.SerializeToJsonContent(authUserModel);
            var responce = base.PostRequest(requestContent).Result;
            if (!responce.IsSuccessStatusCode) 
            {
                throw new Exception($"Authorization for {BaseUrl} has failed");
            }
        }
    }
}
