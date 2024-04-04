using RentH2.Domain.Base;
using RentH2.Domain.Entities.Validators;
namespace RentH2.Domain.Entities
{
    [BsonCollection("Motorcycles")]
    public class Motorcycle : Document
	{
        public string Year { get; private set; }
        public string? Type { get; private set; }
        public string NumberPlate { get; private set; }
        public string? Location { get; private set; }
        public string Status { get; private set; }

        public Motorcycle(string year, string? type, string numberPlate, string? location, string status)
        {
            Year = year;
            Type = type;
            NumberPlate = numberPlate;
            Location = location;
            Status = status;

            var validator = new MotorcycleValidator().Validate(this);

            if (!validator.IsValid)
                throw new ExceptionDomain(validator.Errors.Select( s => s.ErrorMessage).ToList());
        }
	}
}


