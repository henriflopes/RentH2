using RentH2.Domain.Entities;

namespace RentH2.Infrastructure.Repositories.Interfaces
{
    public interface IMotorcycleGateway
    {
        Task<List<Motorcycle>> GetAsync();
        Task<Motorcycle> GetAsync(string id);
        Task<Motorcycle> CreateAsync(Motorcycle motorcycle);
        Task<Motorcycle> UpdateAsync(Motorcycle motorcycle);
        Task RemoveAsync(string id);
        Task<List<Motorcycle>> GetAllByStatusAsync(List<string> rentStatus);
        Task<Motorcycle> GetByNumberPlateAsync(string numberPlate);
    }
}
