using RentH2.Domain.Base;
using RentH2.Domain.Entities.Validators;

namespace RentH2.Domain.Entities
{
    [BsonCollection("Plans")]
    public class Plan : Document
    {
        public string? Description { get; private set; }
        public int TotalDays { get; private set; }
        public double DailyPrice { get; private set; }
        public double TotalPrice { get; private set; }
        public double FineAntecipated { get; private set; }
        public double FineDelayed { get; private set; }
        public string? Status { get; private set; }

        public Plan(string? description, int totalDays, double dailyPrice, double totalPrice, double fineAntecipated, double fineDelayed, string? status)
        {
            Description = description;
            TotalDays = totalDays;
            DailyPrice = dailyPrice;
            TotalPrice = totalPrice;
            FineAntecipated = fineAntecipated;
            FineDelayed = fineDelayed;
            Status = status;

            var validator = new PlanValidator().Validate(this);
            if (!validator.IsValid)
                throw new ExceptionDomain(validator.Errors.Select(s => s.ErrorMessage).ToList());
        }

        public void UpdateDescription(string description)
        {
            var validator = new PlanValidator(nameof(Description)).Validate(this);
            if (!validator.IsValid)
                throw new ExceptionDomain(validator.Errors.Select(s => s.ErrorMessage).ToList());

            Description = description;
        }

        public void UpdateTotalDays(int totalDays)
        {
            var validator = new PlanValidator(nameof(TotalDays)).Validate(this);
            if (!validator.IsValid)
                throw new ExceptionDomain(validator.Errors.Select(s => s.ErrorMessage).ToList());

            TotalDays = totalDays;
        }

        public void UpdateDailyPrice(double dailyPrice)
        {
            var validator = new PlanValidator(nameof(DailyPrice)).Validate(this);
            if (!validator.IsValid)
                throw new ExceptionDomain(validator.Errors.Select(s => s.ErrorMessage).ToList());

            DailyPrice = dailyPrice;
        }

        public void UpdateTotalPrice(double totalPrice)
        {
            var validator = new PlanValidator(nameof(TotalPrice)).Validate(this);
            if (!validator.IsValid)
                throw new ExceptionDomain(validator.Errors.Select(s => s.ErrorMessage).ToList());

            TotalPrice = totalPrice;
        }

        public void UpdateFineAntecipated(double fineAntecipated)
        {
            var validator = new PlanValidator(nameof(FineAntecipated)).Validate(this);
            if (!validator.IsValid)
                throw new ExceptionDomain(validator.Errors.Select(s => s.ErrorMessage).ToList());

            FineAntecipated = fineAntecipated;
        }

        public void UpdateFineDelayed(double fineDelayed)
        {
            var validator = new PlanValidator(nameof(FineDelayed)).Validate(this);
            if (!validator.IsValid)
                throw new ExceptionDomain(validator.Errors.Select(s => s.ErrorMessage).ToList());

            FineDelayed = fineDelayed;
        }

        public void UpdateStatus(string status)
        {
            var validator = new PlanValidator(nameof(Status)).Validate(this);
            if (!validator.IsValid)
                throw new ExceptionDomain(validator.Errors.Select(s => s.ErrorMessage).ToList());

            Status = status;
        }
    }
}


