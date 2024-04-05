using RentH2.Domain.Entities;

namespace RentH2.Infrastructure.Repositories.Interfaces
{
    public interface IRentGateway
    {
        Task<List<Rent>> GetAsync();
        Task<Rent> GetAsync(string id);
        Task<Rent> CreateAsync(Rent plan);
        Task<Rent> UpdateAsync(Rent plan);
        Task RemoveAsync(string id);
    }
}
