﻿
//using RentH2.Services.MotorcycleAPI.Utility;
//using MongoDB.Driver;
//using Microsoft.Extensions.Options;
using RentH2.Services.MotorcycleAPI.Models;
//using System;
//using MongoDB.Bson;
//using System.Linq;
using RentH2.Services.MotorcycleAPI.Services.IService;
//using RentH2.Infra.Repositories.Base;

namespace RentH2.Services.MotorcycleAPI.Services
{
    public class MotorcycleService : IMotorcycleService
    {
        //		private readonly IMongoCollection<Motorcycle> _motorcycleCollection;

        //		public MotorcycleService(IOptions<DatabaseSettings> databaseSettings)
        //		{
        //			var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
        //			var mongoDb = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
        //			_motorcycleCollection = mongoDb.GetCollection<Motorcycle>(databaseSettings.Value.CollectionName);

        //			var indexKeysDefinition = Builders<Motorcycle>.IndexKeys.Ascending("NumberPlate");
        //			var indexOptions = new CreateIndexOptions { Unique = true, Name= "NumberPlate_Duplicate_1022" };
        //			var indexModel = new CreateIndexModel<Motorcycle>(indexKeysDefinition, indexOptions);
        //			_motorcycleCollection.Indexes.CreateOne(indexModel);
        //		}

        //public async Task<List<Motorcycle>> GetAsync() =>
        //    await _motorcycleCollection.Find(_ => true).ToListAsync();

        //public async Task<Motorcycle> GetAsync(string id) =>
        //    await _motorcycleCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        //public async Task CreateAsync(Motorcycle motorcycle) =>
        //    await _motorcycleCollection.InsertOneAsync(motorcycle);

        //public async Task UpdateAsync(Motorcycle motorcycle) =>
        //    await _motorcycleCollection.ReplaceOneAsync(x => x.Id == motorcycle.Id, motorcycle, new ReplaceOptions { IsUpsert = true });

        //public async Task RemoveAsync(string id) => await _motorcycleCollection.DeleteOneAsync(x => x.Id == id);

        //public async Task<List<Motorcycle>> GetAllByStatusAsync(List<string> rentStatus)
        //{
        //    var filter = Builders<Motorcycle>.Filter.In(u => u.Status, rentStatus);
        //    return await _motorcycleCollection.Find(filter).ToListAsync();
        //}
        public Task CreateAsync(Motorcycle motorcycle)
        {
            throw new NotImplementedException();
        }

        public Task<List<Motorcycle>> GetAllByStatusAsync(List<string> rentStatus)
        {
            throw new NotImplementedException();
        }

        public Task<List<Motorcycle>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Motorcycle> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Motorcycle motorcycle)
        {
            throw new NotImplementedException();
        }
    }
}
