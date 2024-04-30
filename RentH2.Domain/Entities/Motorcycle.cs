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

        public void UpdateYear(string year)
        {
            var validator = new MotorcycleValidator(nameof(Year)).Validate(this);

            if (!validator.IsValid)
                throw new ExceptionDomain(validator.Errors.Select(s => s.ErrorMessage).ToList());

            Year = year;
        }

        public void UpdateType(string type)
        {
            Type = type;

            var validator = new MotorcycleValidator(nameof(Type)).Validate(this);

            if (!validator.IsValid)
                throw new ExceptionDomain(validator.Errors.Select(s => s.ErrorMessage).ToList());
        }

        public void UpdateNumberPlate(string numberPlate)
        {
            NumberPlate = numberPlate;

            var validator = new MotorcycleValidator(nameof(NumberPlate)).Validate(this);

            if (!validator.IsValid)
                throw new ExceptionDomain(validator.Errors.Select(s => s.ErrorMessage).ToList());
        }

        public void UpdateLocation(string location)
        {
            Location = location;

            var validator = new MotorcycleValidator(nameof(Location)).Validate(this);

            if (!validator.IsValid)
                throw new ExceptionDomain(validator.Errors.Select(s => s.ErrorMessage).ToList());
        }

        public void UpdateStatus(string status)
        {
            Status = status;

            var validator = new MotorcycleValidator(nameof(Status)).Validate(this);

            if (!validator.IsValid)
                throw new ExceptionDomain(validator.Errors.Select(s => s.ErrorMessage).ToList());
        }
    }
}


