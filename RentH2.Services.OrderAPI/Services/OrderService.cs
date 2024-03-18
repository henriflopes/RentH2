using RentH2.Services.OrderAPI.Utility;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using RentH2.Services.OrderAPI.Models;
using RentH2.Services.OrderAPI.Services.IServices;

namespace RentH2.Services.OrderAPI.Services
{
	public class OrderService : IOrderService
	{
		private readonly IMongoCollection<Order> _orderCollection;

		public OrderService(IOptions<DatabaseSettings> databaseSettings)
		{
			var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
			var mongoDb = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
			_orderCollection = mongoDb.GetCollection<Order>(databaseSettings.Value.CollectionName);
		}

		public async Task<List<Order>> GetAsync() =>
			await _orderCollection.Find(_ => true).ToListAsync();

		public async Task<Order> GetAsync(string id) =>
			await _orderCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

		public async Task CreateAsync(Order order) =>
			await _orderCollection.InsertOneAsync(order);

		public async Task UpdateAsync(Order order) =>
			await _orderCollection.ReplaceOneAsync(x => x.Id == order.Id, order, new ReplaceOptions { IsUpsert = true });

		public async Task RemoveAsync(string id) => await _orderCollection.DeleteOneAsync(x => x.Id == id);

		public async Task<List<Order>> GetAllByStatusAsync(List<string> rentStatus) {
			var filter = Builders<Order>.Filter.In(u => u.Status, rentStatus);
			return await _orderCollection.Find(filter).ToListAsync();
		}
	}
}
