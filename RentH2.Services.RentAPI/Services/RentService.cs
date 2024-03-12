
using RentH2.Services.RentAPI.Utility;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using RentH2.Services.RentAPI.Models;
using RentH2.Services.RentAPI.Services.IService;

namespace RentH2.Services.RentAPI.Services
{
	public class RentService : IRentService
	{
		private readonly IMongoCollection<Rent> _rentCollection;

		public RentService(IOptions<DatabaseSettings> databaseSettings)
		{
			var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
			var mongoDb = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
			_rentCollection = mongoDb.GetCollection<Rent>(databaseSettings.Value.CollectionName);
		}

		public async Task<List<Rent>> GetAsync() =>
			await _rentCollection.Find(_ => true).ToListAsync();

		public async Task<Rent> GetAsync(string id) =>
			await _rentCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

		public async Task CreateAsync(Rent rent) =>
			await _rentCollection.InsertOneAsync(rent);

		public async Task<ReplaceOneResult> UpdateAsync(Rent rent) =>
			await _rentCollection.ReplaceOneAsync(x => x.Id == rent.Id, rent, new ReplaceOptions { IsUpsert = true });

		public async Task<DeleteResult> RemoveAsync(string id) => await _rentCollection.DeleteOneAsync(x => x.Id == id);

	}
}
