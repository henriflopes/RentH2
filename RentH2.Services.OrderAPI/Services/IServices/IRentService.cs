using RentH2.Services.OrderAPI.Models.Dto;

namespace RentH2.Services.OrderAPI.Services.IServices
{
	public interface IRentService
	{
        Task<List<RentDto>> GetAllUserWithRentedMotorcycleAsync();
	}
}
