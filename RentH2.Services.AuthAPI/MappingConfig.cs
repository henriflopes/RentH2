using AutoMapper;
using RentH2.Services.AuthAPI.Models;
using RentH2.Services.AuthAPI.Models.Dto;


namespace RentH2.Services.AuthAPI
{
	public class MappingConfig
	{
		public static MapperConfiguration RegisterMaps()
		{
			var mappingConfig = new MapperConfiguration(config =>
			{
				config.CreateMap<ApplicationUserDto, ApplicationUser>().ReverseMap();
			});

			return mappingConfig;
		}
	}
}
