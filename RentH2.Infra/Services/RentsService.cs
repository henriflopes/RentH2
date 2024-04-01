using Newtonsoft.Json;
using RentH2.Common.Models;
using RentH2.Infrastructure.Services.Contracts;

namespace RentH2.Infrastructure.Services
{
    public class RentService : IRentService
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public RentService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<RentModel> GetOneByMotorcycleIdAsync(string motorcycleId)
        {
            var client = _httpClientFactory.CreateClient("Rent");
            var response = await client.GetAsync($"/api/rent/GetOneByMotorcycleIdAsync?motorcycleId={motorcycleId}");
            var apiContent = await response.Content.ReadAsStringAsync();

            var resp = JsonConvert.DeserializeObject<ResponseModel>(apiContent);

            if (resp != null && resp.IsSuccess)
            {
                return JsonConvert.DeserializeObject<RentModel>(Convert.ToString(resp.Result));
            }

            return new RentModel();
        }
    }
}
