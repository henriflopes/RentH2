using Bogus;
using Bogus.Extensions.UnitedKingdom;
using RentH2.Common.Utility;
using RentH2.Domain.Entities;
using ExpectedObjects;
using RentH2.Domain.Entities.Validators;
using RentH2.Domain.Test._Builders;
using RentH2.Domain.Base;
using RentH2.Domain.Test._Utility;
using MongoDB.Bson.Serialization.Attributes;
using ExpectedObjects.Strategies;

namespace RentH2.Domain.Test.RentTest
{
    public class PlanTest
    {
        private readonly Faker _faker;

        private readonly DateTime   _startDate;
        private readonly DateTime   _endDate;
        private readonly DateTime   _endDateExpected;
        private readonly double     _total;
        private readonly double     _totalExpected;
        private readonly string     _userId;
        private readonly string     _motorcycleId;
        private readonly Plan?      _plan;
        private readonly string?    _status;

        public PlanTest()
        {
            _faker = new Faker();

            _startDate = new DateTime(2024,4,6);
            _endDate = new DateTime(2024, 4, 17);
            _endDateExpected = new DateTime(2024, 4, 17);
            _total = _faker.Random.Double(200, 1000);
            _totalExpected = _total;
            _userId = Guid.NewGuid().ToString();
            _motorcycleId = Guid.NewGuid().ToString();
            _plan = PlanBuilder.New().Build();
            _status = RentStatus.Available;
        }

        [Fact]
        public void ShouldCreateRent() 
        {
            var expectedRent = new
            {
                StartDate = _startDate,
                EndDate = _endDate,
                EndDateExpected = _endDateExpected,
                Total = _total,
                TotalExpected = _totalExpected,
                UserId = _userId,
                MotorcycleId = _motorcycleId,
                Plan = _plan,
                Status =  _status
            };

            var rent = new Rent(expectedRent.StartDate, expectedRent.EndDate, expectedRent.EndDateExpected, expectedRent.Total, expectedRent.TotalExpected, expectedRent.Status, expectedRent.UserId, expectedRent.MotorcycleId, expectedRent.Plan);

            expectedRent.ToExpectedObject().ShouldMatch(rent);
        }

        /*
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
        */
    }
}
