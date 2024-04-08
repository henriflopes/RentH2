using Bogus;
using Bogus.Extensions.UnitedKingdom;
using RentH2.Common.Utility;
using RentH2.Domain.Entities;
using ExpectedObjects;
using RentH2.Domain.Entities.Validators;
using RentH2.Domain.Test._Builders;
using RentH2.Domain.Base;
using RentH2.Domain.Test._Utility;
using Bogus.DataSets;

namespace RentH2.Domain.Test.MotorcycleTest
{
    public class RentTest
    {
        private readonly Faker _faker;

        private readonly string _year;
        private readonly string _type;
        private readonly string _numberPlate;
        private readonly string? _location;
        private readonly string _status;

        public RentTest()
        {
            _faker = new Faker();

            _year = _faker.Random.Int(2000, 2024).ToString();
            _type = _faker.Random.Words(10)[..10];
            _numberPlate = _faker.Vehicle.GbRegistrationPlate(new DateTime(2005, 1, 1), new DateTime(2024, 1, 1));
            _location = _faker.Address.FullAddress();
            _status = RentStatus.Available;
        }

        [Fact]
        public void ShouldCreateMotorcycle() 
        {
            var expectedMotorcycle = new
            {
                Year = _year,
                Type = _type,
                NumberPlate = _numberPlate,
                Location = _location,
                Status = _status
            };

            var motorcycle = new Motorcycle(expectedMotorcycle.Year, expectedMotorcycle.Type, expectedMotorcycle.NumberPlate, expectedMotorcycle.Location, expectedMotorcycle.Status);

            expectedMotorcycle.ToExpectedObject().ShouldMatch(motorcycle);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("ABC")]
        public void ShouldNotHaveInvalidType(string? invalidType) 
        {
            Assert.Throws<ExceptionDomain>(() =>
                MotorcycleBuilder.New().WithType(invalidType).Build())
                .WithMessage(Resources.MotorcycleInvalidType);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("0")]
        [InlineData("-2")]
        [InlineData("-100")]
        [InlineData("ABCD")]
        public void ShouldNotHaveInvalidYear(string invalidYear)
        {
            Assert.Throws<ExceptionDomain>(() =>
                MotorcycleBuilder.New().WithYear(invalidYear).Build())
                .WithMessage(Resources.MotorcycleInvalidYear);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("ABC")]
        public void ShouldNotHaveInvalidNumberPlate(string invalidNumberPlate)
        {
            Assert.Throws<ExceptionDomain>(() =>
                MotorcycleBuilder.New().WithNumberPlate(invalidNumberPlate).Build())
                .WithMessage(Resources.MotorcycleInvalidNumberPlate);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("ABC")]
        public void ShouldNotHaveInvalidLocation(string invalidLocation)
        {
            Assert.Throws<ExceptionDomain>(() =>
                MotorcycleBuilder.New().WithLocation(invalidLocation).Build())
                .WithMessage(Resources.MotorcycleInvalidLocation);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("ABC")]
        [InlineData("Enable")]
        public void ShouldNotHaveInvalidStatus(string invalidStatus)
        {
            Assert.Throws<ExceptionDomain>(() =>
                MotorcycleBuilder.New().WithStatus(invalidStatus).Build())
                .WithMessage(Resources.MotorcycleInvalidStatus);
        }
    }
}
