using MongoDB.Driver;
using RentH2.Domain.Contracts;
using RentH2.Domain.Entities;
using RentH2.Infra.Repositories.Base;

namespace RentH2.Infra.Repositories
{
    public class MotorcycleRepository : BaseRepository<Motorcycle>, IMotorcycleRepository
    {
        public MotorcycleRepository(MongoDBContext<Motorcycle> dbContext) : base(dbContext)
        {
        }

        public async Task CreateAsync(Motorcycle motorcycle) => Add(motorcycle);

        public async Task<List<Motorcycle>> GetAsync() => await GetAll();

        public async Task<Motorcycle> GetAsync(string id) => await GetById(id);

        public async Task RemoveAsync(string id) => Delete(id);

        public async Task UpdateAsync(Motorcycle motorcycle) 
        {
            var filter = Builders<Motorcycle>.Filter.Eq(x => x.Id, motorcycle.Id);
            await UpdateAsync(filter, motorcycle);
        }

        public async Task<List<Motorcycle>> GetAllByStatusAsync(List<string> rentStatus)
        {
            var filter = Builders<Motorcycle>.Filter.In(u => u.Status, rentStatus);
            return await FindByFilterAsync(filter);
        }
    }
}
