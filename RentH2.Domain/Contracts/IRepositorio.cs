using MongoDB.Driver;
using RentH2.Domain.Entities.Base;
using System.Linq.Expressions;

namespace RentH2.Domain.Contracts
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Delete(string id);
        Task<List<T>> GetAll();
        void Dispose();
        Task<T> GetById(string id);
        Task UpdateAsync(FilterDefinition<T> filter, T entity);
        Task<List<T>> FindByFilterAsync(FilterDefinition<T> filter);
    }
}
