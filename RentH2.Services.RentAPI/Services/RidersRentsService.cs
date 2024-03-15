
using RentH2.Services.RentAPI.Utility;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using RentH2.Services.RentAPI.Models;
using RentH2.Services.RentAPI.Services.IService;

namespace RentH2.Services.RentAPI.Services
{
	public class RidersRentsService : IRidersRentsService
	{
		private readonly IMongoCollection<RidersRents> _ridersRentsCollection;

		public RidersRentsService(IOptions<DatabaseSettings> databaseSettings)
		{
			var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
			var mongoDb = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
			_ridersRentsCollection = mongoDb.GetCollection<RidersRents>(databaseSettings.Value.CollectionName);
		}

		public async Task<List<RidersRents>> GetAsync() =>
			await _ridersRentsCollection.Find(_ => true).ToListAsync();

		public async Task<RidersRents> GetAsync(string id) =>
			await _ridersRentsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

		public async Task CreateAsync(RidersRents ridersRents) =>
			await _ridersRentsCollection.InsertOneAsync(ridersRents);

		public async Task<ReplaceOneResult> UpdateAsync(RidersRents ridersRents) =>
			await _ridersRentsCollection.ReplaceOneAsync(x => x.Id == ridersRents.Id, ridersRents, new ReplaceOptions { IsUpsert = true });

		public async Task<DeleteResult> RemoveAsync(string id) => await _ridersRentsCollection.DeleteOneAsync(x => x.Id == id);

		public async Task<RidersRents> GetOneByMotorcycleIdAsync(string motorcycleId) => 
			await _ridersRentsCollection.Find(x => x.MotorcycleId == motorcycleId).FirstOrDefaultAsync();
	}
}
