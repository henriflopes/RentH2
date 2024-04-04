using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using RentH2.Domain.Base;

namespace RentH2.Domain.Entities
{
    [BsonCollection("Rents")]
    public class Rent : Document
    {
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime StartDate { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime EndDate { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime EndDateExpected { get; set; }
        public double Total { get; set; }
        public double TotalExpected { get; set; }
        public string? Status { get; set; }
        public ObjectId UserId { get; set; }
        public ObjectId MotorcycleId { get; set; }
        public Plan? Plan { get; set; }
    }
}


