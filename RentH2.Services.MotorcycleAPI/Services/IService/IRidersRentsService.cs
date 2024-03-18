using RentH2.Services.MotorcycleAPI.Models.Dto;

namespace RentH2.Web.Services.IServices
{
	public interface IRidersRentsService
	{
		Task<RidersRentsDto> GetOneByMotorcycleIdAsync(string motorcycleId);
	}
}
