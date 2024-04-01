using RentH2.Common.Models;

namespace RentH2.Infrastructure.Services.Contracts
{
    public interface IRentService
    {
        Task<RentModel> GetOneByMotorcycleIdAsync(string motorcycleId);
    }
}
