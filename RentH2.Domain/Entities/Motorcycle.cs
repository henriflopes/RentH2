using RentH2.Domain.Entities.Base;
using MongoDB.EntityFrameworkCore;

namespace RentH2.Domain.Entities
{
    [Collection("Motorcycles")]
    public class Motorcycle : Entity
	{
		public string Year { get; set; }

		public string Type { get; set; }

		public string NumberPlate { get; set; }

		public string? Location { get; set; }

		public string Status { get; set; }
	}
}


