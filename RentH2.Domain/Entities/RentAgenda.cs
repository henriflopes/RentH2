using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using RentH2.Domain.Base;

namespace RentH2.Domain.Entities
{
    [BsonCollection("RentAgendas")]
    public class RentAgenda : Document
    {
        public string MotorcycleId { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime StartDate { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime EndDate { get; set; }
        public double TotalDaysInRow { get; set; }
        public string MotorcycleStatus { get; set; }
        public Plan Plan { get; set; }
    }
}


