using RentH2.Services.OrderAPI.Models.Dto;
using Newtonsoft.Json;
using RentH2.Services.OrderAPI.Services.IServices;

namespace RentH2.Services.OrderAPI.Services
{
	public class RidersRentsService : IRidersRentsService
    {

		private readonly IHttpClientFactory _httpClientFactory;

		public RidersRentsService(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<List<RidersRentsDto>> GetAllUserWithRentedMotorcycleAsync()
        {
			var client = _httpClientFactory.CreateClient("RidersRents");
			var response = await client.GetAsync($"/api/ridersrents/GetAllUserWithRentedMotorcycleAsync");
			var apiContent = await response.Content.ReadAsStringAsync();

			var resp = JsonConvert.DeserializeObject<ResponseDto>(apiContent);

			if (resp != null && resp.IsSuccess)
			{
				return JsonConvert.DeserializeObject<List<RidersRentsDto>>(Convert.ToString(resp.Result));
			}

			return [];
		}
    }
}
