using AutoMapper;
using RentH2.Services.NotificationAPI.Models;
using RentH2.Services.NotificationAPI.Models.Dto;

namespace RentH2.Services.NotificationAPI
{
	public class MappingConfig
	{
		public static MapperConfiguration RegisterMaps()
		{
			var mappingConfig = new MapperConfiguration(config =>
			{
				config.CreateMap<NotificationDto, Notification>().ReverseMap();
				config.CreateMap<UserNotificationDto, UserNotification>().ReverseMap();
			});

			return mappingConfig;
		}
	}
}
