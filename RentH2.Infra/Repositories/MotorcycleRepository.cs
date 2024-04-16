using MongoDB.Driver;
using RentH2.Domain.Interface.Repositories;
using RentH2.Domain.Entities;
using RentH2.Infrastructure.Repositories.Base.MongoDB;
using RentH2.Infrastructure.Repositories.Base.MongoDB.Interfaces;

namespace RentH2.Infrastructure.Repositories
{
    public class MotorcycleRepository : MongoRepository<Motorcycle>, IMotorcycleRepository
    {
        public MotorcycleRepository(IMongoDbSettings settings) : base(settings)
        {
                
        }

        public async Task<List<Motorcycle>> GetAllByStatusAsync(List<string> rentStatus) 
            => (await FilterByAsync(filter => rentStatus.Contains(filter.Status))).ToList();

        public async Task<Motorcycle?> GetByNumberPlateAsync(string numberPlate) 
            => (await FilterByAsync(filter => filter.NumberPlate == numberPlate)).FirstOrDefault();
    }
}
