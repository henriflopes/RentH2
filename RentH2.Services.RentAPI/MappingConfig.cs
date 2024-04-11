//using AutoMapper;
//using RentH2.Common.Models;
//using RentH2.Services.RentAPI.Models;
//using RentH2.Services.RentAPI.Models.Dto;

//namespace RentH2.Services.RentAPI
//{
//	public class MappingConfig
//	{
//		public static MapperConfiguration RegisterMaps()
//		{
//			var mappingConfig = new MapperConfiguration(config =>
//			{
//				config.CreateMap<RentDto, Rent>().ReverseMap();
//				config.CreateMap<MotorcycleDto, Motorcycle>().ReverseMap();
//				config.CreateMap<PlanDto, Plan>().ReverseMap();
//				config.CreateMap<ApplicationUserDto, ApplicationUser>().ReverseMap();

//				config.CreateMap<RidersRentsDto, RidersRents>().ReverseMap();
//				config.CreateMap<RentAgendaDto, RentAgenda>().ReverseMap();
//				config.CreateMap<Rent, RentAgenda>().ReverseMap();

//                config.CreateMap<RentAgendaModel, RentAgenda>().ReverseMap();

//            });

//			return mappingConfig;
//		}
//	}
//}