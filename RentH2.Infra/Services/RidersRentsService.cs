using Newtonsoft.Json;
using RentH2.Common.Models;
using RentH2.Infra.Services.Contracts;

namespace RentH2.Infra.Services
{
    public class RidersRentsService : IRidersRentsService
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public RidersRentsService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<RidersRentsModel> GetOneByMotorcycleIdAsync(string motorcycleId)
        {
            var client = _httpClientFactory.CreateClient("RidersRents");
            var response = await client.GetAsync($"/api/ridersrents/GetOneByMotorcycleIdAsync?motorcycleId={motorcycleId}");
            var apiContent = await response.Content.ReadAsStringAsync();

            var resp = JsonConvert.DeserializeObject<ResponseModel>(apiContent);

            if (resp != null && resp.IsSuccess)
            {
                return JsonConvert.DeserializeObject<RidersRentsModel>(Convert.ToString(resp.Result));
            }

            return new RidersRentsModel();
        }
    }
}
