using RentH2.Domain.Models;

namespace RentH2.Web.Services.IServices
{
    public interface IMotorcycleService
	{
		Task<ResponseModel?> GetAllMotorcyclesAsync();
		Task<ResponseModel?> GetMotorcycleByIdAsync(string id);
		Task<ResponseModel?> CreateMotorcycleAsync(MotorcycleModel motorcycleModel);
		Task<ResponseModel?> DeleteMotorcycleAsync(string id);
		Task<ResponseModel?> UpdateMotorcycleAsync(MotorcycleModel motorcycleModel);
	}
}
