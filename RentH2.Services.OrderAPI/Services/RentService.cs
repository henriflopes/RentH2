using RentH2.Services.OrderAPI.Models.Dto;
using Newtonsoft.Json;
using RentH2.Services.OrderAPI.Services.IServices;

namespace RentH2.Services.OrderAPI.Services
{
	public class RentService : IRentService
    {

		private readonly IHttpClientFactory _httpClientFactory;

		public RentService(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<List<RentDto>> GetAllUserWithRentedMotorcycleAsync()
        {
			var client = _httpClientFactory.CreateClient("Rent");
			var response = await client.GetAsync($"/api/rent/GetAllUsersWithRentedMotorcycleAsync");
			var apiContent = await response.Content.ReadAsStringAsync();

			var resp = JsonConvert.DeserializeObject<ResponseDto>(apiContent);

			if (resp != null && resp.IsSuccess)
			{
				return JsonConvert.DeserializeObject<List<RentDto>>(Convert.ToString(resp.Result));
			}

			return [];
		}
    }
}
