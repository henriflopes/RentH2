﻿using MongoDB.Driver;
using RentH2.Domain.Contracts;
using RentH2.Domain.Entities;
using RentH2.Infra.Repositories.Base.MongoDB;
using RentH2.Infra.Repositories.Base.MongoDB.Interfaces;

namespace RentH2.Infra.Repositories
{
    public class MotorcycleRepository : MongoRepository<Motorcycle>, IMotorcycleRepository
    {
        public MotorcycleRepository(IMongoDbSettings settings) : base(settings)
        {
                
        }

        public async Task<List<Motorcycle>> GetAllByStatusAsync(List<string> rentStatus) 
            => (await FilterByAsync(filter => rentStatus.Contains(filter.Status))).ToList();

        public async Task<Motorcycle?> GetByNumberPlateAsync(string numberPlate) 
            => (await FilterByAsync(filter => filter.NumberPlate == numberPlate)).FirstOrDefault();
    }
}
