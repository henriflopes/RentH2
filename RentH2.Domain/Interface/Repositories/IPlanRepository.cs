using RentH2.Domain.Entities;

namespace RentH2.Domain.Interface.Repositories
{
    public interface IPlanRepository : IRepository<Plan>
    {
        Task<List<Plan>> GetAllByStatusAsync(List<string> rentStatus);
    }
}
