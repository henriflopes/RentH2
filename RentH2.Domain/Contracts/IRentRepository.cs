using MongoDB.Driver;
using RentH2.Domain.Entities;
using RentH2.Domain.Repositories.Base.MongoDB.Interfaces;

namespace RentH2.Domain.Contracts
{
    public interface IRentRepository : IRepository<Rent>
    {
        Task<Rent> GetRentByUserIdAsync(string userId, string status);
        Task<List<RentAgenda>> GetAllRentedByExpectedDateAsync(RentAgenda rentAgenda);
        Task<List<Rent>> GetAllRentByIdsAsync(List<string> ids);
        Task<List<Rent>> GetRentedMotorcyclesByIdAsync(List<string> ids);
    }
}
