using RentH2.Domain.Models;
using RentH2.Domain.Utility;
using RentH2.Web.Services.IServices;

namespace RentH2.Web.Services
{
    public class MotorcycleService : IMotorcycleService
    {
		private readonly IBaseService _baseService;

		public MotorcycleService(IBaseService baseService)
        {
            _baseService = baseService;
		}

		public async Task<ResponseModel?> CreateMotorcycleAsync(MotorcycleModel motorcycleModel)
        {
			return await _baseService.SendAsync(new RequestModel()
			{
				ApiType = SD.ApiType.POST,
				Data = motorcycleModel,
				Url = SD.MotorcycleAPIBase
			});
		}

		public async Task<ResponseModel?> DeleteMotorcycleAsync(string id)
        {
			return await _baseService.SendAsync(new RequestModel()
			{
				ApiType = SD.ApiType.DELETE,
				Url = SD.MotorcycleAPIBase + id
			});
		}

        public async Task<ResponseModel?> GetAllMotorcyclesAsync()
        {
            return await _baseService.SendAsync(new RequestModel()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.MotorcycleAPIBase
			});
        }

        public async Task<ResponseModel?> GetMotorcycleByIdAsync(string id)
        {
			return await _baseService.SendAsync(new RequestModel()
			{
				ApiType = SD.ApiType.GET,
                Url = SD.MotorcycleAPIBase + id
            });
		}

		public async Task<ResponseModel?> UpdateMotorcycleAsync(MotorcycleModel motorcycleModel)
        {
			return await _baseService.SendAsync(new RequestModel()
			{
				ApiType = SD.ApiType.PUT,
				Data = motorcycleModel,
				Url = SD.MotorcycleAPIBase
			});
		}
    }
}
