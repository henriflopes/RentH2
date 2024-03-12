using AutoMapper;
using RentH2.Services.PlanAPI.Models;
using RentH2.Services.PlanAPI.Models.Dto;

namespace RentH2.Services.PlanAPI
{
	public class MappingConfig
	{
		public static MapperConfiguration RegisterMaps()
		{
			var mappingConfig = new MapperConfiguration(config =>
			{
				config.CreateMap<PlanDto, Plan>().ReverseMap();
			});

			return mappingConfig;
		}
	}
}
