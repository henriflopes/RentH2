using Refit;
using RentH2.Domain.Models;

namespace RentH2.Domain.Interface.Services
{
	public interface IRentService
    {
		[Get("/api/rent/GetAllRentedByExpectedDateAsync")]
		Task<ResponseModel> GetAllRentedByExpectedDateAsync(DateTime startDate, DateTime endDate);
    }
}
