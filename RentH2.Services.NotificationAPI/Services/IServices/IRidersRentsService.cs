using RentH2.Services.NotificationAPI.Models.Dto;

namespace RentH2.Services.NotificationAPI.Services.IServices
{
	public interface IRidersRentsService
	{
		Task<List<RidersRentsDto>> GetAllUserWithRentedMotorcycleAsync();
	}
}
