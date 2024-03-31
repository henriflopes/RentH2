using RentH2.Common.Models;

namespace RentH2.Web.Services.IServices
{
    public interface IRidersRentsService
	{
		Task<RidersRentsModel> GetOneByMotorcycleIdAsync(string motorcycleId);
	}
}
