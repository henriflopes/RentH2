using MongoDB.Driver;
using RentH2.Common.Utility;
using RentH2.Domain.Contracts;
using RentH2.Domain.Entities;
using RentH2.Infrastructure.Repositories.Base.MongoDB;
using RentH2.Infrastructure.Repositories.Base.MongoDB.Interfaces;

namespace RentH2.Infrastructure.Repositories
{
    public class RentRepository : MongoRepository<Rent>, IRentRepository
    {
        public RentRepository(IMongoDbSettings settings) : base(settings)
        {
                
        }

        public async Task<List<Rent>> GetAllByStatusAsync(List<string> rentStatus)
            => (await FilterByAsync(filter => rentStatus.Contains(filter.Status))).ToList();

        public async Task<List<Rent>> GetAllRentByIdsAsync(List<string> ids)
            => (await FilterByAsync(filter => ids.Contains(filter.Id.ToString()))).ToList();

        public async Task<List<RentAgenda>> GetAllRentedByExpectedDateAsync(RentAgenda rentAgenda)
        {
            var startDate = rentAgenda.StartDate;
            var endDate = rentAgenda.EndDate;

            var resultUnavailableDates = (await FilterByAsync(x =>
                (
                       (startDate <= x.StartDate && endDate >= x.EndDate)
                    || (startDate >= x.StartDate && endDate <= x.EndDate)
                    || (startDate >= x.StartDate && startDate <= x.EndDate && endDate >= x.EndDate)
                    || (startDate <= x.StartDate && startDate >= x.EndDate && endDate <= x.EndDate)
                ) && x.Status == RentStatus.Rented
            )).ToList();

            List<RentAgenda> unavailableDates = [];
            RentAgenda unavailableDate;

            resultUnavailableDates.ForEach(x =>
            {
                unavailableDate = new RentAgenda
                {
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    TotalDaysInRow = (x.EndDate - x.StartDate).TotalDays,
                    MotorcycleId = x.MotorcycleId
                };
                unavailableDate.Plan = x.Plan;

                unavailableDates.Add(unavailableDate);
            });

            return unavailableDates;
        }

        public async Task<Rent> GetRentByUserIdAsync(string userId, string status)
            => (await FilterByAsync(x => x.UserId.ToString() == userId && x.Status == status)).FirstOrDefault();

        public async Task<List<Rent>> GetRentedMotorcyclesByIdAsync(List<string> ids)
            => (await FilterByAsync(filter => ids.Contains(filter.MotorcycleId.ToString()))).ToList();
    }
}
