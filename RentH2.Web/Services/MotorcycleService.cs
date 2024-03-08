using RentH2.Web.Models;
using RentH2.Web.Services.IServices;
using RentH2.Web.Utility;

namespace RentH2.Web.Services
{
    public class MotorcycleService : IMotorcycleService
    {
		private readonly IBaseService _baseService;

		public MotorcycleService(IBaseService baseService)
        {
            _baseService = baseService;
		}

		public async Task<ResponseDto?> CreateMotorcycleAsync(MotorcycleDto motorcycleDto)
        {
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.POST,
				Data = motorcycleDto,
				Url = SD.MotorcycleAPIBase
			});
		}

		public async Task<ResponseDto?> DeleteMotorcycleAsync(string id)
        {
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.DELETE,
				Url = SD.MotorcycleAPIBase + id
			});
		}

        public async Task<ResponseDto?> GetAllMotorcyclesAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.MotorcycleAPIBase
			});
        }

        public async Task<ResponseDto?> GetMotorcycleByIdAsync(string id)
        {
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.GET,
                Url = SD.MotorcycleAPIBase + id
            });
		}

		public async Task<ResponseDto?> UpdateMotorcycleAsync(MotorcycleDto motorcycleDto)
        {
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.PUT,
				Data = motorcycleDto,
				Url = SD.MotorcycleAPIBase
			});
		}
    }
}
