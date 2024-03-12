
using RentH2.Services.PlanAPI.Utility;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using RentH2.Services.PlanAPI.Models;
using RentH2.Services.PlanAPI.Services.IService;

namespace RentH2.Services.PlanAPI.Services
{
	public class PlanService : IPlanService
	{
		private readonly IMongoCollection<Plan> _planCollection;

		public PlanService(IOptions<DatabaseSettings> databaseSettings)
		{
			var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
			var mongoDb = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
			_planCollection = mongoDb.GetCollection<Plan>(databaseSettings.Value.CollectionName);
		}

		public async Task<List<Plan>> GetAsync() =>
			await _planCollection.Find(_ => true).ToListAsync();

		public async Task<Plan> GetAsync(string id) =>
			await _planCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

		public async Task CreateAsync(Plan plan) =>
			await _planCollection.InsertOneAsync(plan);

		public async Task<ReplaceOneResult> UpdateAsync(Plan plan) =>
			await _planCollection.ReplaceOneAsync(x => x.Id == plan.Id, plan, new ReplaceOptions { IsUpsert = true });

		public async Task<DeleteResult> RemoveAsync(string id) => await _planCollection.DeleteOneAsync(x => x.Id == id);

	}
}
