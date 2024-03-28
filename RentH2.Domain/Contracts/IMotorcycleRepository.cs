using RentH2.Domain.Entities;
using RentH2.Infra.Repositories.Base.MongoDB.Interfaces;

namespace RentH2.Domain.Contracts
{
    public interface IMotorcycleRepository : IRepository<Motorcycle>
    {
        Task<Motorcycle> GetByNumberPlateAsync(string numberPlate);
        Task<List<Motorcycle>> GetAllByStatusAsync(List<string> rentStatus);
    }
}
