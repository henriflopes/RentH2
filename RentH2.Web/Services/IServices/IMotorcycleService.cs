using RentH2.Web.Models;

namespace RentH2.Web.Services.IServices
{
	public interface IMotorcycleService
	{
		Task<ResponseDto?> GetAllMotorcyclesAsync();
		Task<ResponseDto?> GetMotorcycleByIdAsync(string id);
		Task<ResponseDto?> CreateMotorcycleAsync(MotorcycleDto motorcycleDto);
		Task<ResponseDto?> DeleteMotorcycleAsync(string id);
		Task<ResponseDto?> UpdateMotorcycleAsync(MotorcycleDto motorcycleDto);
	}
}
