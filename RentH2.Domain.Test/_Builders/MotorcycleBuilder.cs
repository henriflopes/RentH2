using Bogus;
using Bogus.Extensions.UnitedKingdom;
using RentH2.Common.Utility;
using RentH2.Domain.Entities;

namespace RentH2.Domain.Test._Builders
{
    public class MotorcycleBuilder
    {
        protected string Id;
        protected string Year;
        protected string? Type;
        protected string NumberPlate;
        protected string? Location;
        protected string Status;

        public static MotorcycleBuilder New()
        {
            var faker = new Faker();

            return new MotorcycleBuilder
            {
                Year = faker.Random.Int(2000, 2024).ToString(),
                Type = faker.Random.Words(10)[..10],
                NumberPlate = faker.Vehicle.GbRegistrationPlate(new DateTime(2005, 1, 1), new DateTime(2024, 1, 1)),
                Location = faker.Address.FullAddress(),
                Status = RentStatus.Available
            };
        }


        public MotorcycleBuilder WithYear(string year)
        {
            Year = year;
            return this;
        }

        public MotorcycleBuilder WithType(string? type)
        {
            Type = type;
            return this;
        }

        public MotorcycleBuilder WithNumberPlate(string numberPlate)
        {
            NumberPlate = numberPlate;
            return this;
        }

        public MotorcycleBuilder WithLocation(string location)
        {
            Location = location;
            return this;
        }

        public MotorcycleBuilder WithStatus(string status)
        {
            Status = status;
            return this;
        }

        public Motorcycle Build()
        {
            var motorcycle = new Motorcycle(Year, Type, NumberPlate, Location, Status);

            if (string.IsNullOrEmpty(Id)) return motorcycle;

            var propertyInfo = motorcycle.GetType().GetProperty("Id");
            propertyInfo.SetValue(motorcycle, Convert.ChangeType(Id, propertyInfo.PropertyType), null);

            return motorcycle;
        }
    }
}