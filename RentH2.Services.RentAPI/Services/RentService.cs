
using RentH2.Services.RentAPI.Utility;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using RentH2.Services.RentAPI.Models;
using RentH2.Services.RentAPI.Services.IService;
using RentH2.Services.RentAPI.Models.Dto;

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

		public async Task<Rent> CreateAsync(Rent rent) { 
			await _rentCollection.InsertOneAsync(rent);
			return rent;
		}

		public async Task<ReplaceOneResult> UpdateAsync(Rent rent) =>
			await _rentCollection.ReplaceOneAsync(x => x.Id == rent.Id, rent, new ReplaceOptions { IsUpsert = true });

		public async Task<DeleteResult> RemoveAsync(string id) => await _rentCollection.DeleteOneAsync(x => x.Id == id);

		public async Task<List<RentAgenda>> GetAllRentedByExpectedDateAsync(RentAgenda rentAgenda) {

			var startDate = rentAgenda.StartDate;
			var endDate = rentAgenda.EndDate;

			var resultUnavailableDates = await _rentCollection.Find(x =>
				(
					   (startDate <= x.StartDate && endDate >= x.EndDate)
					|| (startDate >= x.StartDate && endDate <= x.EndDate)
					|| (startDate >= x.StartDate && startDate <= x.EndDate && endDate >= x.EndDate)
					|| (startDate <= x.StartDate && startDate >= x.EndDate && endDate <= x.EndDate)
				) && x.Status == RentStatus.Rented
			).ToListAsync();

			List<RentAgenda> unavailableDates = [];
			RentAgenda unavailableDate;

			resultUnavailableDates.ForEach(x =>
			{
				unavailableDate = new RentAgenda
				{
					StartDate = x.StartDate,
					EndDate = x.EndDate,
					TotalDaysInRow = (x.EndDate - x.StartDate).TotalDays,
					MotorcycleId = x.Motorcycle.Id,
					MotorcycleStatus = x.Motorcycle.Status,
					Plan = new Plan()
				};
				unavailableDate.Plan = x.Plan;

				unavailableDates.Add(unavailableDate);
			});

			return unavailableDates;
		}
	 


	}
}
