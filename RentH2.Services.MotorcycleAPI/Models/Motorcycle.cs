using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RentH2.Services.MotorcycleAPI.Models
{
	[Collection("Motorcycles")]
	public class Motorcycle
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string? Id { get; set; }

		public string Year { get; set; }

		public string Model { get; set; }

		public string NumberPlate { get; set; }

		public string? Location { get; set; }

		public bool IsBooked { get; set; } = false;
	}
}


