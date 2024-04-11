//using MongoDB.Bson;
//using MongoDB.Bson.Serialization.Attributes;
//using MongoDB.EntityFrameworkCore;

//namespace RentH2.Services.RentAPI.Models
//{
//    [Collection("RidersRents")]
//    public class RidersRents
//	{
//        [BsonId]
//        [BsonRepresentation(BsonType.ObjectId)]
//        public string? Id { get; set; }
//        public string RentId { get; set; }
//		public string PlanId { get; set; }
//		public string UserId { get; set; }
//		public string MotorcycleId { get; set; }
//        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
//        public DateTime TimeStamp { get; set; } = DateTime.Now;
//	}
//}


