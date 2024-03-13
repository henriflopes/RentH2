using Newtonsoft.Json;
using RentH2.Services.RentAPI.Models.Dto;
using RentH2.Services.RentAPI.Services.IService;
using System.Text;

namespace RentH2.Services.RentAPI.Services
{
	public class PlanService : IPlanService
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public PlanService(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<List<PlanDto>> GetAllByStatusAsync(List<string> rentStatus)
		{
			var json = JsonConvert.SerializeObject(rentStatus);
			var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

			var client = _httpClientFactory.CreateClient("Plan");
			var response = await client.PostAsync($"/api/plan/GetAllByStatusAsync", stringContent);
			var apiContent = await response.Content.ReadAsStringAsync();
			var resp = JsonConvert.DeserializeObject<ResponseDto>(apiContent);

			if (resp != null && resp.IsSuccess)
			{
				return JsonConvert.DeserializeObject<List<PlanDto>>(Convert.ToString(resp.Result));
			}

			return new List<PlanDto>();
		}

	}
}
