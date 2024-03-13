using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using RentH2.Services.RentAPI.Models;
using RentH2.Services.RentAPI.Models.Dto;

namespace RentH2.Services.RentAPI.Services.IService
{
	public interface IMotorcycleService
    {
		Task<List<MotorcycleDto>> GetAllByStatusAsync([FromBody] List<string> rentStatus);
		Task<List<MotorcycleDto>> GetAllAvailable(RentAgenda rentAgenda);
		Task<MotorcycleDto> GetOneAvailable(RentAgenda rentAgenda);
		Task UpdateAsync(Motorcycle motorcycle);
	}
}
