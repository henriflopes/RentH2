using MongoDB.Bson.Serialization.Attributes;
using RentH2.Domain.Base;
using RentH2.Domain.Entities.Validators;

namespace RentH2.Domain.Entities
{
    [BsonCollection("Rents")]
    public class Rent : Document
    {
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime StartDate { get; private set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime EndDate { get; private set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime EndDateExpected { get; private set; }
        public double Total { get; private set; }
        public double TotalExpected { get; private set; }
        public string? Status { get; private set; }
        public string UserId { get; private set; }
        public string MotorcycleId { get; private set; }
        public Plan? Plan { get; private set; }

        public Rent(DateTime startDate, DateTime endDate, DateTime endDateExpected, double total, double totalExpected, string? status, string userId, string motorcycleId, Plan? plan)
        {
            StartDate = startDate;
            EndDate = endDate;
            EndDateExpected = endDateExpected;
            Total = total;
            TotalExpected = totalExpected;
            Status = status;
            UserId = userId;
            MotorcycleId = motorcycleId;
            Plan = plan;

            var validator = new RentValidator().Validate(this);
            if (!validator.IsValid)
                throw new ExceptionDomain(validator.Errors.Select(s => s.ErrorMessage).ToList());

        }

        public void UpdateStartDate(DateTime startDate)
        {
            var validator = new RentValidator(nameof(StartDate)).Validate(this);
            if (!validator.IsValid)
                throw new ExceptionDomain(validator.Errors.Select(s => s.ErrorMessage).ToList());

            StartDate = startDate;
        }

        public void UpdateEndDate(DateTime endDate)
        {
            var validator = new RentValidator(nameof(EndDate)).Validate(this);
            if (!validator.IsValid)
                throw new ExceptionDomain(validator.Errors.Select(s => s.ErrorMessage).ToList());

            EndDate = endDate;
        }
        
        public void UpdateEndDateExpected(DateTime endDateExpected)
        {
            var validator = new RentValidator(nameof(EndDateExpected)).Validate(this);
            if (!validator.IsValid)
                throw new ExceptionDomain(validator.Errors.Select(s => s.ErrorMessage).ToList());

            EndDateExpected = endDateExpected;
        }

        public void UpdateTotal(double total)
        {
            var validator = new RentValidator(nameof(Total)).Validate(this);
            if (!validator.IsValid)
                throw new ExceptionDomain(validator.Errors.Select(s => s.ErrorMessage).ToList());

            Total = total;
        }

        public void UpdateTotalExpected(double totalExpected)
        {
            var validator = new RentValidator(nameof(TotalExpected)).Validate(this);
            if (!validator.IsValid)
                throw new ExceptionDomain(validator.Errors.Select(s => s.ErrorMessage).ToList());

            TotalExpected = totalExpected;
        }

        public void UpdateStatus(string status)
        {
            var validator = new RentValidator(nameof(status)).Validate(this);
            if (!validator.IsValid)
                throw new ExceptionDomain(validator.Errors.Select(s => s.ErrorMessage).ToList());

            Status = status;
        }

        public void UpdateUserId(string userId)
        {
            var validator = new RentValidator(nameof(UserId)).Validate(this);
            if (!validator.IsValid)
                throw new ExceptionDomain(validator.Errors.Select(s => s.ErrorMessage).ToList());

            UserId = userId;
        }

        public void UpdateMotorcycleId(string motorcycleId)
        {
            var validator = new RentValidator(nameof(MotorcycleId)).Validate(this);
            if (!validator.IsValid)
                throw new ExceptionDomain(validator.Errors.Select(s => s.ErrorMessage).ToList());

            MotorcycleId = motorcycleId;
        }

        public void UpdatePlan(Plan plan)
        {
            var validator = new RentValidator(nameof(Plan)).Validate(this);
            if (!validator.IsValid)
                throw new ExceptionDomain(validator.Errors.Select(s => s.ErrorMessage).ToList());

            Plan = plan;
        }
    }
}