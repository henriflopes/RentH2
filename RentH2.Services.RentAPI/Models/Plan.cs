//using MongoDB.Bson;
//using MongoDB.Bson.Serialization.Attributes;
//using MongoDB.EntityFrameworkCore;
//using RentH2.Services.RentAPI.Utility;

//namespace RentH2.Services.RentAPI.Models
//{
//	[Collection("Plans")]
//    public class Plan
//    {
//        [BsonId]
//        [BsonRepresentation(BsonType.ObjectId)]
//        public string? Id { get; set; }
//        public string Description { get; set; }
//        public int TotalDays { get; set; }
//        public double DailyPrice { get; set; }
//        public double TotalPrice { get; set; }
//        public double FineAntecipated { get; set; }
//        public double FineDelayed { get; set; }
//        public string Status { get; set; } = RentStatus.Available;
//    }
//}


