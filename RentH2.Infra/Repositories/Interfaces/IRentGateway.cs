using RentH2.Domain.Entities;

namespace RentH2.Infrastructure.Repositories.Interfaces
{
    public interface IRentGateway
    {
        Task<List<Rent>> GetAsync();
        Task<Rent> GetAsync(string id);
        Task<Rent> CreateAsync(Rent rent);
        Task<Rent> UpdateAsync(Rent rent);
        Task RemoveAsync(string id);
        Task<Rent> GetRentByUserIdAsync(string userId, string status);
        Task<List<RentAgenda>> GetAllRentedByExpectedDateAsync(RentAgenda rentAgenda);
        Task<List<Rent>> GetAllRentByIdsAsync(List<string> ids);
        Task<List<Rent>> GetRentedMotorcyclesByIdAsync(List<string> ids);
    }
}
