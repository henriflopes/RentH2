using RentH2.Services.OrderAPI.Utility;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using RentH2.Services.OrderAPI.Models;
using RentH2.Services.OrderAPI.Services.IServices;

namespace RentH2.Services.OrderAPI.Services
{
	public class UserOrdersService : IUserOrdersService
	{
		private readonly IMongoCollection<UserOrders> _userOrdersCollection;

		public UserOrdersService(IOptions<DatabaseSettings> databaseSettings)
		{
			var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
			var mongoDb = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
			_userOrdersCollection = mongoDb.GetCollection<UserOrders>("UserOrders");
		}

		public async Task<List<UserOrders>> GetAsync() =>
			await _userOrdersCollection.Find(_ => true).ToListAsync();

		public async Task<UserOrders> GetAsync(string id) =>
			await _userOrdersCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

		public async Task CreateAsync(UserOrders userOrders) =>
			await _userOrdersCollection.InsertOneAsync(userOrders);

		public async Task UpdateAsync(UserOrders userOrders) =>
			await _userOrdersCollection.ReplaceOneAsync(x => x.Id == userOrders.Id, userOrders, new ReplaceOptions { IsUpsert = true });

		public async Task RemoveAsync(string id) => await _userOrdersCollection.DeleteOneAsync(x => x.Id == id);
	}
}
