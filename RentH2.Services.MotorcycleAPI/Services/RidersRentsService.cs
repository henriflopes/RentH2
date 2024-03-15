using RentH2.Services.MotorcycleAPI.Models.Dto;
using RentH2.Services.RentAPI.Models.Dto;
using RentH2.Web.Services.IServices;
using Newtonsoft.Json;

namespace RentH2.Services.MotorcycleAPI.Services
{
	public class RidersRentsService : IRidersRentsService
    {

		private readonly IHttpClientFactory _httpClientFactory;

		public RidersRentsService(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<RidersRentsDto> GetOneByMotorcycleIdAsync(string motorcycleId)
        {
			var client = _httpClientFactory.CreateClient("RidersRents");
			var response = await client.GetAsync($"/api/ridersrents/GetOneByMotorcycleIdAsync?motorcycleId={motorcycleId}");
			var apiContent = await response.Content.ReadAsStringAsync();

			var resp = JsonConvert.DeserializeObject<ResponseDto>(apiContent);

			if (resp != null && resp.IsSuccess)
			{
				return JsonConvert.DeserializeObject<RidersRentsDto>(Convert.ToString(resp.Result));
			}

			return new RidersRentsDto();
		}
    }
}
