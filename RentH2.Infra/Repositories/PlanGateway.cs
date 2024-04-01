using RentH2.Common.Models;
using RentH2.Domain.Contracts;
using RentH2.Domain.Entities;
using RentH2.Infrastructure.Repositories.Base;
using RentH2.Infrastructure.Repositories.Interfaces;

namespace RentH2.Infrastructure.Repositories
{
    public class PlanGateway : BaseHttp<HttpParam, MotorcycleModel>, IPlanGateway
    {
        private readonly IPlanRepository _planRepository;

        public PlanGateway(IPlanRepository planRepository)
        {
            _planRepository = planRepository;
        }

        public async Task<List<Plan>> GetAllByStatusAsync(List<string> rentStatus)
            => await _planRepository.GetAllByStatusAsync(rentStatus);

        public async Task<List<Plan>> GetAsync()
            => (await _planRepository.FilterByAsync(filter => true)).ToList();

        public async Task<Plan> GetAsync(string id)
            => await _planRepository.FindByIdAsync(id);
        public async Task<Plan> CreateAsync(Plan plan)
            => await _planRepository.InsertOneAsync(plan);

        public Task RemoveAsync(string id)
            => _planRepository.DeleteByIdAsync(id);

        public async Task<Plan> UpdateAsync(Plan plan)
            => await _planRepository.ReplaceOneAsync(plan);
    }
}
