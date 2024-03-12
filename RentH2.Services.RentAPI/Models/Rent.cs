using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.EntityFrameworkCore;
using RentH2.Services.RentAPI.Utility;

namespace RentH2.Services.RentAPI.Models
{
	[Collection("Rents")]
	public class Rent
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string? Id { get; set; }
        public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public DateTime EndDateExpected { get; set; }
        public double Total { get; set; }
		public double TotalExpected { get; set; }
		public string Status { get; set; } = RentStatus.Available;
        public ApplicationUser User { get; set; }
        public Motorcycle Motorcycle { get; set; }
        public Plan Plan { get; set; }
    }
}


