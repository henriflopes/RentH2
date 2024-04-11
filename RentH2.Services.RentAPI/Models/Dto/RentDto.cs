//using MongoDB.Bson.Serialization.Attributes;
//using MongoDB.Bson;
//using RentH2.Services.RentAPI.Utility;
//using System.ComponentModel.DataAnnotations;

//namespace RentH2.Services.RentAPI.Models.Dto
//{
//	public class RentDto
//	{
//		[BsonId]
//		[BsonRepresentation(BsonType.ObjectId)]
//		public string? Id { get; set; }
//		[Required(ErrorMessage = "Informar uma data de inicio.")]
//		public DateTime StartDate { get; set; }
//		public DateTime EndDate { get; set; }
//		public DateTime EndDateExpected { get; set; }
//		public double Total { get; set; }
//		public double TotalExpected { get; set; }
//		public string Status { get; set; } = RentStatus.Available;
//		public DateTime TimeStamp { get; set; } = DateTime.Now;
//		public ApplicationUserDto User { get; set; }
//		public MotorcycleDto Motorcycle { get; set; }
//		public PlanDto Plan { get; set; }
//	}
//}