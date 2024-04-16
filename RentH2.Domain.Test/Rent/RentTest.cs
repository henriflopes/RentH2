using Bogus;
using RentH2.Domain.Utility;
using RentH2.Domain.Entities;
using ExpectedObjects;
using RentH2.Domain.Entities.Validators;
using RentH2.Domain.Test._Builders;
using RentH2.Domain.Base;
using RentH2.Domain.Test._Utility;

namespace RentH2.Domain.Test.RentTest
{
    public class PlanTest
    {
        private readonly Faker _faker;

        private readonly DateTime _startDate;
        private readonly DateTime _endDate;
        private readonly DateTime _endDateExpected;
        private readonly double _total;
        private readonly double _totalExpected;
        private readonly string _userId;
        private readonly string _motorcycleId;
        private readonly Plan? _plan;
        private readonly string? _status;

        public PlanTest()
        {
            _faker = new Faker();

            _startDate = DateTime.Now.AddDays(1);
            _endDate = DateTime.Now.AddDays(7);
            _endDateExpected = DateTime.Now.AddDays(7);
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
                Status = _status
            };

            var rent = new Rent(expectedRent.StartDate, expectedRent.EndDate, expectedRent.EndDateExpected, expectedRent.Total, expectedRent.TotalExpected, expectedRent.Status, expectedRent.UserId, expectedRent.MotorcycleId, expectedRent.Plan);

            expectedRent.ToExpectedObject().ShouldMatch(rent);
        }

        public static TheoryData<DateTime> StartDate = new TheoryData<DateTime>
        {
             new DateTime(2023,12,31),
             DateTime.MinValue,
             DateTime.MaxValue,
             DateTime.Now.AddDays(-10)
        };
        [Theory, MemberData(nameof(StartDate))]
        public void ShouldNotHaveInvalidStartDate(DateTime invalidStartDate)
        {
            Assert.Throws<ExceptionDomain>(() => RentBuilder.New().WithStartDate(invalidStartDate).Build())
                .WithMessage(Resources.RentStartDateInvalid);
        }

        public static TheoryData<DateTime> EndDate = new TheoryData<DateTime>
        {
             new DateTime(2023,12,31),
             DateTime.MinValue,
             DateTime.Now,
             DateTime.Now.AddDays(-10)
        };
        [Theory, MemberData(nameof(EndDate))]
        public void ShouldNotHaveInvalidEndDate(DateTime invalidEndDate)
        {
            Assert.Throws<ExceptionDomain>(() =>
                RentBuilder.New().WithEndDate(invalidEndDate).Build())
                .WithMessage(Resources.RentEndDateInvalid);
        }

        public static TheoryData<DateTime> EndDateExpected = new TheoryData<DateTime>
        {
             new DateTime(2023,12,31),
             DateTime.MinValue,
             DateTime.Now,
             DateTime.Now.AddDays(-10)
        };
        [Theory, MemberData(nameof(EndDateExpected))]
        public void ShouldNotHaveInvalidEndDateExpected(DateTime invalidEndDateExpected)
        {
            Assert.Throws<ExceptionDomain>(() =>
                RentBuilder.New().WithEndDateExpected(invalidEndDateExpected).Build())
                .WithMessage(Resources.RentEndDateInvalid);
        }

        [Theory]
        [InlineData(-2)]
        [InlineData(-200)]
        [InlineData(null)]
        public void ShouldNotHaveInvalidTotal(int invalidTotal)
        {
            Assert.Throws<ExceptionDomain>(() =>
                RentBuilder.New().WithTotal(invalidTotal).Build())
                .WithMessage(Resources.RentTotalInvalid);
        }


        [Theory]
        [InlineData(-2)]
        [InlineData(-200)]
        [InlineData(null)]
        public void ShouldNotHaveInvalidTotalExpected(int invalidTotalExpected)
        {
            Assert.Throws<ExceptionDomain>(() =>
                RentBuilder.New().WithTotalExpected(invalidTotalExpected).Build())
                .WithMessage(Resources.RentTotalExpectedInvalid);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotHaveInvalidUserId(string invalidUserId)
        {
            Assert.Throws<ExceptionDomain>(() =>
                RentBuilder.New().WithUserId(invalidUserId).Build())
                .WithMessage(Resources.UserNullIdInvalid);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotHaveInvalidMotorcycleId(string invalidMotorcycleId)
        {
            Assert.Throws<ExceptionDomain>(() =>
                RentBuilder.New().WithMotorcycleId(invalidMotorcycleId).Build())
                .WithMessage(Resources.MotorcyclesNullIdInvalid);
        }

        [Theory]
        [InlineData(null)]
        public void ShouldNotHaveInvalidPlan(Plan invalidPlan)
        {
            Assert.Throws<ExceptionDomain>(() =>
                RentBuilder.New().WithPlan(invalidPlan).Build())
                .WithMessage(Resources.PlanInvalid);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("ABC")]
        [InlineData("Enable")]
        public void ShouldNotHaveInvalidStatus(string invalidStatus)
        {
            Assert.Throws<ExceptionDomain>(() =>
                RentBuilder.New().WithStatus(invalidStatus).Build())
                .WithMessage(Resources.RentStatusInvalid);
        }

    }
}
