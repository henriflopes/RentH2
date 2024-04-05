using RentH2.Common.Models;
using RentH2.Domain.Contracts;
using RentH2.Domain.Entities;
using RentH2.Infrastructure.Repositories.Base;
using RentH2.Infrastructure.Repositories.Interfaces;

namespace RentH2.Infrastructure.Repositories
{
    public class RentGateway : BaseHttp<HttpParam, MotorcycleModel>, IRentGateway
    {
        private readonly IRentRepository _rentRepository;

        public RentGateway(IRentRepository rentRepository)
        {
            _rentRepository = rentRepository;
        }

        public async Task<List<Rent>> GetAsync()
            => (await _rentRepository.FilterByAsync(filter => true)).ToList();

        public async Task<Rent> GetAsync(string id)
            => await _rentRepository.FindByIdAsync(id);
        public async Task<Rent> CreateAsync(Rent rent)
            => await _rentRepository.InsertOneAsync(rent);

        public Task RemoveAsync(string id)
            => _rentRepository.DeleteByIdAsync(id);

        public async Task<Rent> UpdateAsync(Rent rent)
            => await _rentRepository.ReplaceOneAsync(rent);
    }
}
