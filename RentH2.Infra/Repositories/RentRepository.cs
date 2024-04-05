using MongoDB.Driver;
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
    }
}
