using MongoDB.Driver;
using RentH2.Domain.Entities;

namespace RentH2.Domain.Interface.Repositories
{
    public interface IRentRepository : IRepository<Rent>
    {
        Task<Rent> GetRentByUserIdAsync(string userId, string status);
        Task<List<Rent>> GetAllRentedByExpectedDateAsync(DateTime startDate, DateTime endDate);
        Task<List<Rent>> GetAllRentByIdsAsync(List<string> ids);
        Task<List<Rent>> GetRentedMotorcyclesByIdAsync(List<string> ids);
    }
}
