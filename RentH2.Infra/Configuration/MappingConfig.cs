using AutoMapper;
using RentH2.Domain.Models;
using RentH2.Domain.Entities;

namespace RentH2.Infrastructure.Configuration
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<MotorcycleModel, Motorcycle>().ReverseMap();
                config.CreateMap<PlanModel, Plan>().ReverseMap();
                config.CreateMap<RentModel, Rent>().ReverseMap();
                config.CreateMap<ApplicationUserModel, ApplicationUser>().ReverseMap();
                config.CreateMap<RentAgendaModel, RentAgenda>().ReverseMap();

                
            });

            return mappingConfig;
        }
    }
}
