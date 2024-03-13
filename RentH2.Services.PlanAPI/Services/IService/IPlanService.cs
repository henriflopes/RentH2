using MongoDB.Driver;
using RentH2.Services.PlanAPI.Models;

namespace RentH2.Services.PlanAPI.Services.IService
{
	public interface IPlanService
	{
		Task<List<Plan>> GetAsync();
		Task<Plan> GetAsync(string id);
		Task CreateAsync(Plan plan);
		Task<ReplaceOneResult> UpdateAsync(Plan plan);
		Task<DeleteResult> RemoveAsync(string id);
		Task<List<Plan>> GetAllByStatusAsync(List<string> rentStatus);
	}
}
