using RentH2.Domain.Entities;
using RentH2.Domain.Entities.Base;

namespace RentH2.Domain.Contracts
{
    public interface IMotorcycleRepository
    {
        Task<List<Motorcycle>> GetAsync();
        Task<Motorcycle> GetAsync(string id);
        Task CreateAsync(Motorcycle motorcycle);
        Task UpdateAsync(Motorcycle motorcycle);
        Task RemoveAsync(string id);
        Task<List<Motorcycle>> GetAllByStatusAsync(List<string> rentStatus);
    }
}
