using MongoDB.Bson;
using RentH2.Common.Models.Base;
using RentH2.Domain.Base;
using RentH2.Domain.Entities;

namespace RentH2.Common.Models
{
    [BsonCollection("Rents")]
    public class RentModel : HttpBaseResult
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime EndDateExpected { get; set; }
        public double Total { get; set; }
        public double TotalExpected { get; set; }
        public string? Status { get; set; }
        public string UserId { get; set; }
        public string MotorcycleId { get; set; }
        public Plan? Plan { get; set; }
    }
}


