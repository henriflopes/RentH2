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
            => _motorcycleRepository.InsertOneAsync(motorcycle);

        public async Task<List<Motorcycle>> GetAllByStatusAsync(List<string> rentStatus)
            => await _motorcycleRepository.GetAllByStatusAsync(rentStatus);

        public async Task<List<Motorcycle>> GetAsync()
            => (await _motorcycleRepository.FilterByAsync(filter => 1 == 1)).ToList();

        public async Task<Motorcycle> GetAsync(string id)
            => await _motorcycleRepository.FindByIdAsync(id);

        public Task RemoveAsync(string id) 
            => _motorcycleRepository.DeleteByIdAsync(id);

        public Task UpdateAsync(Motorcycle motorcycle) 
            => _motorcycleRepository.ReplaceOneAsync(motorcycle);
    }
}
