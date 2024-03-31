using RentH2.Common.Models;

namespace RentH2.Infra.Services.Contracts
{
    public interface IRidersRentsService
    {
        Task<RidersRentsModel> GetOneByMotorcycleIdAsync(string motorcycleId);
    }
}
