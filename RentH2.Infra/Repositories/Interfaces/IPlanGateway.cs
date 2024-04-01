using RentH2.Domain.Entities;

namespace RentH2.Infrastructure.Repositories.Interfaces
{
    public interface IPlanGateway
    {
        Task<List<Plan>> GetAsync();
        Task<Plan> GetAsync(string id);
        Task<Plan> CreateAsync(Plan plan);
        Task<Plan> UpdateAsync(Plan plan);
        Task RemoveAsync(string id);
        Task<List<Plan>> GetAllByStatusAsync(List<string> rentStatus);
    }
}
