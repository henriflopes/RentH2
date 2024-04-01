using RentH2.Domain.Entities;
using RentH2.Domain.Repositories.Base.MongoDB.Interfaces;

namespace RentH2.Domain.Contracts
{
    public interface IPlanRepository : IRepository<Plan>
    {
        Task<List<Plan>> GetAllByStatusAsync(List<string> rentStatus);
    }
}
