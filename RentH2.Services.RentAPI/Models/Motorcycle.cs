//using MongoDB.Bson;
//using MongoDB.Bson.Serialization.Attributes;
//using MongoDB.EntityFrameworkCore;
//using RentH2.Services.RentAPI.Utility;

//namespace RentH2.Services.RentAPI.Models
//{
//    [Collection("Motorcycles")]
//    public class Motorcycle
//    {
//        [BsonId]
//        [BsonRepresentation(BsonType.ObjectId)]
//        public string? Id { get; set; }

//        public string Year { get; set; }

//        public string Type { get; set; }

//        public string NumberPlate { get; set; }

//        public string? Location { get; set; }

//        public string Status { get; set; } = RentStatus.Available;
//    }
//}


