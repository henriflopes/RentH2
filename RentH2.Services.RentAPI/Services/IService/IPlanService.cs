using Microsoft.AspNetCore.Mvc;
using RentH2.Services.RentAPI.Models.Dto;

namespace RentH2.Services.RentAPI.Services.IService
{
	public interface IPlanService
	{
		Task<List<PlanDto>> GetAllByStatusAsync([FromBody] List<string> rentStatus);
	}
}
