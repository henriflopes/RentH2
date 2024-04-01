using Microsoft.AspNetCore.Mvc;
using RentH2.Common.Models;
using RentH2.Services.RentAPI.Models.Dto;

namespace RentH2.Services.RentAPI.Services.IService
{
	public interface IPlanService
	{
		Task<List<PlanModel>> GetAllByStatusAsync([FromBody] List<string> rentStatus);
	}
}
