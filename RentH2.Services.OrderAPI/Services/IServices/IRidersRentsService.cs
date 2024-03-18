using RentH2.Services.OrderAPI.Models.Dto;

namespace RentH2.Services.OrderAPI.Services.IServices
{
	public interface IRidersRentsService
	{
		Task<List<RidersRentsDto>> GetAllUserWithRentedMotorcycleAsync();
	}
}
