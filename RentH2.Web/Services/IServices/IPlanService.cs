using RentH2.Web.Models;

namespace RentH2.Web.Services.IServices
{
    public interface IPlanService
	{
		Task<ResponseDto?> GetAllPlansAsync();
		Task<ResponseDto?> GetPlanByIdAsync(string id);
		Task<ResponseDto?> CreatePlanAsync(PlanDto planDto);
		Task<ResponseDto?> DeletePlanAsync(string id);
		Task<ResponseDto?> UpdatePlanAsync(PlanDto planDto);
	}
}
