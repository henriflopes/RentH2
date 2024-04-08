using Bogus;
using RentH2.Common.Utility;
using RentH2.Domain.Entities;
using System.Net.NetworkInformation;

namespace RentH2.Domain.Test._Builders
{
    public class RentBuilder
    {
        protected string? Id;
        protected DateTime StartDate;
        protected DateTime EndDate;
        protected DateTime EndDateExpected;
        protected double Total;
        protected double TotalExpected;
        protected string? Status;
        protected string? UserId;
        protected string? MotorcycleId;
        protected Plan? Plan;

        public static RentBuilder New()
        {
            var faker = new Faker();
            double total = faker.Random.Double(200, 1000);

            return new RentBuilder
            {
                StartDate = DateTime.Now.AddDays(1),
                EndDate = DateTime.Now.AddDays(7),
                EndDateExpected = DateTime.Now.AddDays(7),
                Total = total,
                TotalExpected = total,
                UserId = Guid.NewGuid().ToString(),
                MotorcycleId = Guid.NewGuid().ToString(),
                Plan = PlanBuilder.New().Build(),
                Status = RentStatus.Available
            };
        }

        public RentBuilder WithStartDate(DateTime startDate)
        {
            StartDate = startDate;
            return this;
        }
        public RentBuilder WithEndDate(DateTime endDate)
        {
            EndDate = endDate;
            return this;
        }
        public RentBuilder WithEndDateExpected(DateTime endDateExpected)
        {
            EndDateExpected = endDateExpected;
            return this;
        }
        public RentBuilder WithTotal(double total)
        {
            Total = total;
            return this;
        }
        public RentBuilder WithTotalExpected(double totalExpected)
        {
            TotalExpected = totalExpected;
            return this;
        }
        public RentBuilder WithUserId(string userId)
        {
            UserId = userId;
            return this;
        }
        public RentBuilder WithMotorcycleId(string motorcycleId)
        {
            MotorcycleId = motorcycleId;
            return this;
        }
        public RentBuilder WithPlan(Plan plan)
        {
            Plan = plan;
            return this;
        }
        public RentBuilder WithStatus(string status)
        {
            Status = status;
            return this;
        }

        public Rent Build()
        {
            var rent = new Rent(StartDate, EndDate, EndDateExpected, Total, TotalExpected, Status, UserId, MotorcycleId, Plan);

            if (string.IsNullOrEmpty(Id)) return rent;

            var propertyInfo = rent.GetType().GetProperty("Id");
            propertyInfo.SetValue(rent, Convert.ChangeType(Id, propertyInfo.PropertyType), null);

            return rent;
        }
    }
}