using Newtonsoft.Json;
using RentH2.Common.Models.Base;
using RestSharp;

namespace RentH2.Infra.Repositories.Base
{
    public class BaseHttp<HttpParam, HttpResult> where HttpParam : IHttpParam
                                                  where HttpResult : HttpBaseResult, new()
    {
        public async Task<HttpResult> GetBasic(HttpParam param)
        {
            var client = new RestClient(param.GetApiUrl());

            RestRequest request = new RestRequest("", Method.Get);
            request.AddHeader("Accept", "application/json");

            var resquestResponse = await client.ExecuteAsync(request);

            if (!resquestResponse.IsSuccessful)
            {

            }

            var result = JsonConvert.DeserializeObject<HttpResult>(resquestResponse.Content);

            return result;
        }

        public async Task<HttpResult> GetWithAuthorization(HttpParam param)
        {
            var client = new RestClient(param.GetApiUrl());

            RestRequest request = new RestRequest("", Method.Get);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("authorization", param.GetToken());

            var resquestResponse = await client.ExecuteAsync(request);

            if (!resquestResponse.IsSuccessful)
            {

            }

            var result = JsonConvert.DeserializeObject<HttpResult>(resquestResponse.Content);

            return result;
        }
    }
}
