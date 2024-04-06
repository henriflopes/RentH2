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
using Bogus.DataSets;

namespace RentH2.Domain.Test.PlanTest
{
    public class PlanTest
    {
        private readonly Faker _faker;

        private readonly string? _description;
        private readonly int _totalDays;
        private readonly double _dailyPrice;
        private readonly double _totalPrice;
        private readonly double _fineAntecipated;
        private readonly double _fineDelayed;
        private readonly string? _status;

        public PlanTest()
        {
            _faker = new Faker();

            _description = _faker.Lorem.Paragraph()[..100];
            _totalDays = _faker.Random.Int(7, 30);
            _dailyPrice = _faker.Random.Int(15, 30);
            _totalPrice = _faker.Random.Int(150, 300);
            _fineAntecipated = _faker.Random.Int(10, 30);
            _fineDelayed = _faker.Random.Int(10, 50);
            _status = RentStatus.Available;
        }

        [Fact]
        public void ShouldCreateRent()
        {
            var expectedRent = new
            {
                Description = _description,
                TotalDays = _totalDays,
                DailyPrice = _dailyPrice,
                TotalPrice = _totalPrice,
                FineAntecipated = _fineAntecipated,
                FineDelayed = _fineDelayed,
                Status = _status
            };

            var plan = new Plan(expectedRent.Description, expectedRent.TotalDays, expectedRent.DailyPrice, expectedRent.TotalPrice, expectedRent.FineAntecipated, expectedRent.FineDelayed, expectedRent.Status);

            expectedRent.ToExpectedObject().ShouldMatch(plan);
        }

        
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("ABC")]
        public void ShouldNotHaveInvalidDescription(string? invalidDescription) 
        {
            Assert.Throws<ExceptionDomain>(() =>
                PlanBuilder.New().WithDescription(invalidDescription).Build())
                .WithMessage(Resources.PlanDescriptionInvalid);
        }

        /*
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
