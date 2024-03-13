using RentH2.Services.RentAPI.Models.Dto;
using RentH2.Services.RentAPI.Services.IService;
using System.Text;
using Newtonsoft.Json;
using RentH2.Services.RentAPI.Utility;
using MongoDB.Driver.Linq;
using MongoDB.Driver;
using RentH2.Services.RentAPI.Models;

namespace RentH2.Services.RentAPI.Services
{
	public class MotorcycleService : IMotorcycleService
	{

		private readonly IHttpClientFactory _httpClientFactory;
		private readonly IRentService _rentService;

		public MotorcycleService(IHttpClientFactory httpClientFactory, IRentService rentService)
		{
			_httpClientFactory = httpClientFactory;
			_rentService = rentService;
		}

		public async Task<List<MotorcycleDto>> GetAllAvailable(RentAgenda rentAgenda)
		{
			var unavailableAgendas = await _rentService.GetAllRentedByExpectedDateAsync(rentAgenda);
			var availableMotorcycles = await GetAllByStatusAsync([RentStatus.Available]);

			var result = availableMotorcycles
			.GroupJoin(
				unavailableAgendas,
				A => A.Id,
				B => B.MotorcycleId,
				(A, B) => new
				{
					ColumnsA = A,
					ColumnsB = B.DefaultIfEmpty()
				})
			.SelectMany(joinResult => joinResult.ColumnsB.Where(B => B == null), (A, B) => A.ColumnsA)
			.ToList();

			return result;
		}

		public async Task<MotorcycleDto> GetOneAvailable(RentAgenda rentAgenda)
		{
			var unavailableAgendas = await _rentService.GetAllRentedByExpectedDateAsync(rentAgenda);
			var availableMotorcycles = await GetAllByStatusAsync([RentStatus.Available]);

			var result = availableMotorcycles
			.GroupJoin(
				unavailableAgendas,
				A => A.Id,
				B => B.MotorcycleId,
				(A, B) => new
				{
					ColumnsA = A,
					ColumnsB = B.DefaultIfEmpty()
				})
			.SelectMany(joinResult => joinResult.ColumnsB.Where(B => B == null), (A, B) => A.ColumnsA)
			.FirstOrDefault();

			return result;
		}

		public async Task<List<MotorcycleDto>> GetAllByStatusAsync(List<string> rentStatus)
		{
			var json = JsonConvert.SerializeObject(rentStatus);
			var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

			var client = _httpClientFactory.CreateClient("Motorcycle");
			var response = await client.PostAsync($"/api/motorcycle/GetAllByStatusAsync", stringContent);
			var apiContent = await response.Content.ReadAsStringAsync();
			var resp = JsonConvert.DeserializeObject<ResponseDto>(apiContent);

			if (resp != null && resp.IsSuccess)
			{
				return JsonConvert.DeserializeObject<List<MotorcycleDto>>(Convert.ToString(resp.Result));
			}

			return new List<MotorcycleDto>();
		}

		public async Task UpdateAsync(Motorcycle motorcycle)
		{
			var json = JsonConvert.SerializeObject(motorcycle);
			var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

			var client = _httpClientFactory.CreateClient("Motorcycle");
			var response = await client.PutAsync($"/api/motorcycle", stringContent);
			var apiContent = await response.Content.ReadAsStringAsync();
			var resp = JsonConvert.DeserializeObject<ResponseDto>(apiContent);

			if (resp != null && resp.IsSuccess)
			{
				
			}
		}
	}
}
