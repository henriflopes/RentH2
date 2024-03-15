using MongoDB.Driver;
using RentH2.Services.MotorcycleAPI.Models;

namespace RentH2.Services.MotorcycleAPI.Services.IService
{
    public interface IMotorcycleService
    {
        Task<List<Motorcycle>> GetAsync();
        Task<Motorcycle> GetAsync(string id);
        Task CreateAsync(Motorcycle motorcycle);
        Task UpdateAsync(Motorcycle motorcycle);
        Task RemoveAsync(string id);
        Task<List<Motorcycle>> GetAllByStatusAsync(List<string> rentStatus);

    }
}
