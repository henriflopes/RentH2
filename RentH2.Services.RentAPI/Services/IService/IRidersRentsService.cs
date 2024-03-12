﻿using MongoDB.Driver;
using RentH2.Services.RentAPI.Models;

namespace RentH2.Services.RentAPI.Services.IService
{
	public interface IRidersRentsService
	{
		Task<List<RidersRents>> GetAsync();
		Task<RidersRents> GetAsync(string id);
		Task CreateAsync(RidersRents ridersRents);
		Task<ReplaceOneResult> UpdateAsync(RidersRents ridersRents);
		Task<DeleteResult> RemoveAsync(string id);
	}
}
