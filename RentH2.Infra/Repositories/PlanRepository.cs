﻿using MongoDB.Driver;
using RentH2.Domain.Contracts;
using RentH2.Domain.Entities;
using RentH2.Infrastructure.Repositories.Base.MongoDB;
using RentH2.Infrastructure.Repositories.Base.MongoDB.Interfaces;

namespace RentH2.Infrastructure.Repositories
{
    public class PlanRepository : MongoRepository<Plan>, IPlanRepository
    {
        public PlanRepository(IMongoDbSettings settings) : base(settings)
        {
                
        }

        public async Task<List<Plan>> GetAllByStatusAsync(List<string> rentStatus)
            => (await FilterByAsync(filter => rentStatus.Contains(filter.Status))).ToList();
    }
}
