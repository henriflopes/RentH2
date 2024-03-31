using RentH2.Common.Models;

namespace RentH2.Infrastructure.Services.Contracts
{
    public interface IRidersRentsService
    {
        Task<RidersRentsModel> GetOneByMotorcycleIdAsync(string motorcycleId);
    }
}
