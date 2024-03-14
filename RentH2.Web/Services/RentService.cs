using RentH2.Web.Models;
using RentH2.Web.Services.IServices;
using RentH2.Web.Utility;

namespace RentH2.Web.Services
{
	public class RentService : IRentService
	{

		private readonly IBaseService _baseService;

		public RentService(IBaseService baseService)
		{
			_baseService = baseService;
		}

		public async Task<ResponseDto?> GetAllRent()
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.GET,
				Url = SD.RentAPIBase
			});
		}

		public async Task<ResponseDto?> GetAvalaiblePlans(RentAgendaDto rentAgendaDto)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.POST,
				Data = rentAgendaDto,
				Url = SD.RentAPIBase + "GetAvalaiblePlans"
			});
		}

		public async Task<ResponseDto?> RentAsync(RentDto rentDto)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.POST,
				Data = rentDto,
				Url = SD.RentAPIBase
			});
		}
	}
}
