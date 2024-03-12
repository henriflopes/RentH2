﻿using MongoDB.Driver;
using RentH2.Services.RentAPI.Models;

namespace RentH2.Services.RentAPI.Services.IService
{
	public interface IRentService
	{
		Task<List<Rent>> GetAsync();
		Task<Rent> GetAsync(string id);
		Task CreateAsync(Rent rent);
		Task<ReplaceOneResult> UpdateAsync(Rent rent);
		Task<DeleteResult> RemoveAsync(string id);

	}
}
