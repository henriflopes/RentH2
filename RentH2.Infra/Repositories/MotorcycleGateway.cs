using RentH2.Domain.Contracts;
using RentH2.Domain.Entities;
using RentH2.Infra.Models;
using RentH2.Infra.Repositories.Base;
using RentH2.Infra.Repositories.Interfaces;

namespace RentH2.Infra.Repositories
{
    public class MotorcycleGateway : BaseHttp<HttpParam, MotorcycleModel>, IMotorcycleGateway
    {
        private readonly IMotorcycleRepository _motorcycleRepository;

        public MotorcycleGateway(IMotorcycleRepository motorcycleRepository)
        {
            _motorcycleRepository = motorcycleRepository;
        }

        public Task CreateAsync(Motorcycle motorcycle)
        {
            return _motorcycleRepository.CreateAsync(motorcycle);
        }

        public async Task<List<Motorcycle>> GetAllByStatusAsync(List<string> rentStatus)
        {
            return await _motorcycleRepository.GetAllByStatusAsync(rentStatus);
        }

        public async Task<List<Motorcycle>> GetAsync()
        {
            return await _motorcycleRepository.GetAsync();
        }

        public async Task<Motorcycle> GetAsync(string id)
        {
            return await _motorcycleRepository.GetAsync(id);
        }

        public Task RemoveAsync(string id)
        {
            return _motorcycleRepository.RemoveAsync(id);
        }

        public Task UpdateAsync(Motorcycle motorcycle)
        {
            return _motorcycleRepository.UpdateAsync(motorcycle);
        }
    }
}
