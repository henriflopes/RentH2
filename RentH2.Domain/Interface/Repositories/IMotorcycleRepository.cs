using RentH2.Domain.Entities;

namespace RentH2.Domain.Interface.Repositories
{
    public interface IMotorcycleRepository : IRepository<Motorcycle>
    {
        Task<Motorcycle> GetByNumberPlateAsync(string numberPlate);
        Task<List<Motorcycle>> GetAllByStatusAsync(List<string> rentStatus);
    }
}
