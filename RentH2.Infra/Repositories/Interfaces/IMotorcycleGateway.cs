using RentH2.Domain.Entities;

namespace RentH2.Infra.Repositories.Interfaces
{
    public interface IMotorcycleGateway
    {
        Task<List<Motorcycle>> GetAsync();
        Task<Motorcycle> GetAsync(string id);
        Task CreateAsync(Motorcycle motorcycle);
        Task UpdateAsync(Motorcycle motorcycle);
        Task RemoveAsync(string id);
        Task<List<Motorcycle>> GetAllByStatusAsync(List<string> rentStatus);
    }
}
