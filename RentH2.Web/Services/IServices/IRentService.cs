using RentH2.Web.Models;

namespace RentH2.Web.Services.IServices
{
	public interface IRentService
	{
		Task<ResponseDto?> GetAvalaiblePlans(RentAgendaDto rentAgendaDto);
		Task<ResponseDto?> RentAsync(RentDto rentDto);
		Task<ResponseDto?> GetAllRent();
	}
}
