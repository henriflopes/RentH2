using Bogus;
using RentH2.Domain.Utility;
using RentH2.Domain.Entities;

namespace RentH2.Domain.Test._Builders
{
    public class PlanBuilder
    {
        protected string    Id;
        protected string?   Description;
        protected int       TotalDays;
        protected double    DailyPrice;
        protected double    TotalPrice;
        protected double    FineAntecipated;
        protected double    FineDelayed;
        protected string?   Status;

        public static PlanBuilder New()
        {
            var faker = new Faker();

            return new PlanBuilder
            {
                Description = faker.Random.Words(100)[..100],
                TotalDays = faker.Random.Int(7, 30),
                DailyPrice = faker.Random.Int(15, 30),
                TotalPrice = faker.Random.Int(150, 300),
                FineAntecipated = faker.Random.Int(10, 30),
                FineDelayed = faker.Random.Int(10, 50),
                Status = RentStatus.Available
            };
        }

        public PlanBuilder WithDescription(string description)
        {
            Description = description;
            return this;
        }

        public PlanBuilder WithTotalDays(int totalDays)
        {
            TotalDays = totalDays;
            return this;
        }

        public PlanBuilder WithDailyPrice(double dailyPrice)
        {
            DailyPrice = dailyPrice;
            return this;
        }

        public PlanBuilder WithTotalPrice(double totalPrice)
        {
            TotalPrice = totalPrice;
            return this;
        }

        public PlanBuilder WithFineAntecipated(double fineAntecipated)
        {
            FineAntecipated = fineAntecipated;
            return this;
        }

        public PlanBuilder WithFineDelayed(double fineDelayed)
        {
            FineDelayed = fineDelayed;
            return this;
        }
        public PlanBuilder WithStatus(string status)
        {
            Status = status;
            return this;
        }

        public Plan Build()
        {
            var plan = new Plan(Description, TotalDays, DailyPrice, TotalPrice, FineAntecipated, FineDelayed, Status);

            if (string.IsNullOrEmpty(Id)) return plan;

            var propertyInfo = plan.GetType().GetProperty("Id");
            propertyInfo.SetValue(plan, Convert.ChangeType(Id, propertyInfo.PropertyType), null);

            return plan;
        }
    }
}