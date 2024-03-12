using RentH2.Web.Models;
using RentH2.Web.Services.IServices;
using RentH2.Web.Utility;

namespace RentH2.Web.Services
{
    public class PlanService : IPlanService
	{
		private readonly IBaseService _baseService;

		public PlanService(IBaseService baseService)
        {
            _baseService = baseService;
		}

		public async Task<ResponseDto?> CreatePlanAsync(PlanDto planDto)
        {
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.POST,
				Data = planDto,
				Url = SD.PlanAPIBase
			});
		}

		public async Task<ResponseDto?> DeletePlanAsync(string id)
        {
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.DELETE,
				Url = SD.PlanAPIBase + id
			});
		}

        public async Task<ResponseDto?> GetAllPlansAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.PlanAPIBase
			});
        }

        public async Task<ResponseDto?> GetPlanByIdAsync(string id)
        {
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.GET,
                Url = SD.PlanAPIBase + id
            });
		}

		public async Task<ResponseDto?> UpdatePlanAsync(PlanDto planDto)
        {
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.PUT,
				Data = planDto,
				Url = SD.PlanAPIBase
			});
		}
    }
}
