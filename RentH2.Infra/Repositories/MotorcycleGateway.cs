using RentH2.Common.Models;
using RentH2.Domain.Contracts;
using RentH2.Domain.Entities;
using RentH2.Infrastructure.Repositories.Base;
using RentH2.Infrastructure.Repositories.Interfaces;

namespace RentH2.Infrastructure.Repositories
{
    public class MotorcycleGateway : BaseHttp<HttpParam, MotorcycleModel>, IMotorcycleGateway
    {
        private readonly IMotorcycleRepository _motorcycleRepository;

        public MotorcycleGateway(IMotorcycleRepository motorcycleRepository)
        {
            _motorcycleRepository = motorcycleRepository;
        }

        public async Task<Motorcycle> CreateAsync(Motorcycle motorcycle) 
            => await _motorcycleRepository.InsertOneAsync(motorcycle);

        public async Task<List<Motorcycle>> GetAllByStatusAsync(List<string> rentStatus)
            => await _motorcycleRepository.GetAllByStatusAsync(rentStatus);

        public async Task<List<Motorcycle>> GetAsync()
            => (await _motorcycleRepository.FilterByAsync(filter => true)).ToList();

        public async Task<Motorcycle> GetAsync(string id)
            => await _motorcycleRepository.FindByIdAsync(id);

        public Task<Motorcycle> GetByNumberPlateAsync(string numberPlate)
            => _motorcycleRepository.GetByNumberPlateAsync(numberPlate);

        public Task RemoveAsync(string id) 
            => _motorcycleRepository.DeleteByIdAsync(id);

        public async Task<Motorcycle> UpdateAsync(Motorcycle motorcycle) 
            => await _motorcycleRepository.ReplaceOneAsync(motorcycle);
    }
}
