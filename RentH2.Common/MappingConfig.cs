using AutoMapper;
using RentH2.Common.Models;
using RentH2.Domain.Entities;

namespace RentH2.Common
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<MotorcycleModel, Motorcycle>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
