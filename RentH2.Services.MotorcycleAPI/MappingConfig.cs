using AutoMapper;
using RentH2.Services.MotorcycleAPI.Models;
using RentH2.Services.MotorcycleAPI.Models.Dto;

namespace RentH2.Services.MotorcycleAPI
{
	public class MappingConfig
	{
		public static MapperConfiguration RegisterMaps()
		{
			var mappingConfig = new MapperConfiguration(config =>
			{
				config.CreateMap<MotorcycleDto, Motorcycle>().ReverseMap();
			});

			return mappingConfig;
		}
	}
}
