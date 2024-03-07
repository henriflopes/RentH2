﻿
using RentH2.Services.MotorcycleAPI.Utility;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using RentH2.Services.MotorcycleAPI.Models;
using System;
using RentH2.Services.MotorcycleAPI.Services.IService;

namespace RentH2.Services.MotorcycleAPI.Services
{
	public class MotorcycleService : IMotorcycleService
	{
		private readonly IMongoCollection<Motorcycle> _motorcycleCollection;

		public MotorcycleService(IOptions<DatabaseSettings> databaseSettings)
		{
			var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
			var mongoDb = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
			_motorcycleCollection = mongoDb.GetCollection<Motorcycle>(databaseSettings.Value.CollectionName);
		}

		public async Task<List<Motorcycle>> GetAsync() =>
			await _motorcycleCollection.Find(_ => true).ToListAsync();

		public async Task<Motorcycle> GetAsync(string id) =>
			await _motorcycleCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

		public async Task CreateAsync(Motorcycle motorcycle) =>
			await _motorcycleCollection.InsertOneAsync(motorcycle);

		public async Task<ReplaceOneResult> UpdateAsync(Motorcycle motorcycle) =>
			await _motorcycleCollection.ReplaceOneAsync(x => x.Id == motorcycle.Id, motorcycle, new ReplaceOptions { IsUpsert = true });

		public async Task<DeleteResult> RemoveAsync(string id) => await _motorcycleCollection.DeleteOneAsync(x => x.Id == id);

		public async Task<bool> ExistsNumberPlate(Motorcycle motorcycle)
		{

			var result = await _motorcycleCollection.Find(x => x.NumberPlate == motorcycle.NumberPlate && x.Id != motorcycle.Id).FirstOrDefaultAsync();

			return result != null;
		}
	}
}