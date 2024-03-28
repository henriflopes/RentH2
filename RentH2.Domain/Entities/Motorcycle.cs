using RentH2.Domain.Entities.Base;

namespace RentH2.Domain.Entities
{
    [BsonCollection("Motorcycles")]
    public class Motorcycle : Document
	{
		public string Year { get; set; }

		public string Type { get; set; }

		public string NumberPlate { get; set; }

		public string? Location { get; set; }

		public string Status { get; set; }
	}
}


