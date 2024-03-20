using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.EntityFrameworkCore;

namespace RentH2.Services.OrderAPI.Models
{
	
	[Collection("Orders")]
	public class Order
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string? Id { get; set; }

		public string? UserId { get; set; }
		
		public double ShippingTax { get; set; }
        public string? Description { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Timestamp { get; set; }

		public string Status { get; set; }
	}
}


