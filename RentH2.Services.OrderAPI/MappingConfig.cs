using AutoMapper;
using RentH2.Services.OrderAPI.Models;
using RentH2.Services.OrderAPI.Models.Dto;

namespace RentH2.Services.OrderAPI
{
	public class MappingConfig
	{
		public static MapperConfiguration RegisterMaps()
		{
			var mappingConfig = new MapperConfiguration(config =>
			{
				config.CreateMap<OrderDto, Order>().ReverseMap();
				config.CreateMap<UserOrdersDto, UserOrders>().ReverseMap();
			});

			return mappingConfig;
		}
	}
}
