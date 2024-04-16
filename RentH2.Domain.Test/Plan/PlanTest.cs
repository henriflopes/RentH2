using Bogus;
using RentH2.Domain.Utility;
using RentH2.Domain.Entities;
using ExpectedObjects;
using RentH2.Domain.Entities.Validators;
using RentH2.Domain.Test._Builders;
using RentH2.Domain.Base;
using RentH2.Domain.Test._Utility;

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

            _description = _faker.Random.Words(100)[..100];
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

        
        [Theory]
        [InlineData(null)]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void ShouldNotHaveInvalidTotalDays(int invalidTotalDays)
        {
            Assert.Throws<ExceptionDomain>(() =>
                PlanBuilder.New().WithTotalDays(invalidTotalDays).Build())
                .WithMessage(Resources.PlanTotalDaysInvalid);
        }

        
        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void ShouldNotHaveInvalidDailyPrice(double invalidDailyPrice)
        {
            Assert.Throws<ExceptionDomain>(() =>
                PlanBuilder.New().WithDailyPrice(invalidDailyPrice).Build())
                .WithMessage(Resources.PlanDailyPriceInvalid);
        }

        
        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void ShouldNotHaveInvalidTotalPrice(double invalidTotalPrice)
        {
            Assert.Throws<ExceptionDomain>(() =>
                PlanBuilder.New().WithTotalPrice(invalidTotalPrice).Build())
                .WithMessage(Resources.PlanTotalPriceInvalid);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void ShouldNotHaveInvalidFineAntecipated(double invalidFineAntecipated)
        {
            Assert.Throws<ExceptionDomain>(() =>
                PlanBuilder.New().WithFineAntecipated(invalidFineAntecipated).Build())
                .WithMessage(Resources.PlanFineAntecipatedInvalid);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void ShouldNotHaveInvalidFineDelayed(double invalidFineDelayed)
        {
            Assert.Throws<ExceptionDomain>(() =>
                PlanBuilder.New().WithFineDelayed(invalidFineDelayed).Build())
                .WithMessage(Resources.PlanFineDelayedInvalid);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("ABC")]
        [InlineData("Enable")]
        public void ShouldNotHaveInvalidStatus(string? invalidStatus)
        {
            Assert.Throws<ExceptionDomain>(() =>
                PlanBuilder.New().WithStatus(invalidStatus).Build())
                .WithMessage(Resources.PlanStatusInvalid);
        }
    }
}
