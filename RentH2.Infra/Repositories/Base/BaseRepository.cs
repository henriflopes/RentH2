using MongoDB.Driver;
using RentH2.Domain.Contracts;

namespace RentH2.Infra.Repositories.Base
{
    public class BaseRepository<T> : IRepository<T>, IDisposable where T : class, new()
    {
        private MongoDBContext<T> _dbContext;

        public BaseRepository(MongoDBContext<T> dbContext) => _dbContext = dbContext;

        public virtual async void Add(T entity) => await _dbContext.GetColection.InsertOneAsync(entity);

        public async void Delete(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            await _dbContext.GetColection.DeleteOneAsync(filter);
        }

        public async Task<T> GetById(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            var document = await _dbContext.GetColection.FindAsync(filter);
            return await document.FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAll()
        {
            var documents = await _dbContext.GetColection.FindAsync(Builders<T>.Filter.Empty);

            return await documents.ToListAsync();
        }

        public void Dispose() => GC.SuppressFinalize(this);

        public async Task UpdateAsync(FilterDefinition<T> filter, T entity)
        {
            await _dbContext.GetColection.ReplaceOneAsync(filter, entity, new ReplaceOptions { IsUpsert = true });
        }

        public async Task<List<T>> FindByFilterAsync(FilterDefinition<T> filter)
        {
            return await _dbContext.GetColection.Find(filter).ToListAsync();
        }
    }
}
