﻿using FluentValidation;
using RentH2.Domain.Base;
using RentH2.Domain.Utility;

namespace RentH2.Domain.Entities.Validators
{
    public class RentValidator : RuleValidator<Rent>
    {
        public RentValidator()
        {
            StartDateValidate();
            EndDateValidate();
            EndDateExpectedValidate();
            TotalValidate();
            TotalExpectedValidate();
            StatusValidate();
            UserIdValidate();
            MotorcycleIdValidate();
            PlanValidate();
        }

        public RentValidator(string propertyName)
        {
            switch (propertyName)
            {
                case "StartDate":
                    StartDateValidate();
                    break;
                case "EndDate":
                    EndDateValidate();
                    break;
                case "EndDateExpected":
                    EndDateExpectedValidate();
                    break;
                case "Total":
                    TotalValidate();
                    break;
                case "TotalExpected":
                    TotalExpectedValidate();
                    break;
                case "Status":
                    StatusValidate();
                    break;
                case "UserId":
                    UserIdValidate();
                    break;
                case "MotorcycleId":
                    MotorcycleIdValidate();
                    break;
                default:
                    break;
            }
        }

        private void StatusValidate()
        {
            RuleFor(c => c.Status)
                .NotEmpty()
                .WithMessage(Resources.RentStatusInvalid)
                .NotNull()
                .WithMessage(Resources.RentStatusInvalid)
                .Length(10, 120)
                .WithMessage(Resources.RentStatusInvalid)
                .Must(status => RentStatus.GetAllRentStatus().Contains(status))
                .WithMessage(Resources.RentStatusInvalid);
        }

        private void MotorcycleIdValidate()
        {
            RuleFor(c => c.MotorcycleId)
                .NotEmpty()
                .WithMessage(Resources.MotorcyclesNullIdInvalid)
                .NotNull()
                .WithMessage(Resources.MotorcyclesNullIdInvalid);
        }

        private void UserIdValidate()
        {
            RuleFor(c => c.UserId)
                .NotEmpty()
                .WithMessage(Resources.UserNullIdInvalid)
                .NotNull()
                .WithMessage(Resources.UserNullIdInvalid);
        }

        private void PlanValidate()
        {
            RuleFor(c => c.Plan)
                .NotEmpty()
                .WithMessage(Resources.PlanInvalid)
                .NotNull()
                .WithMessage(Resources.PlanInvalid);
        }

        private void TotalExpectedValidate()
        {
            RuleFor(c => c.TotalExpected)
                .GreaterThan(0)
                .WithMessage(Resources.RentTotalExpectedInvalid)
                .NotNull()
                .WithMessage(Resources.RentTotalExpectedInvalid)
                .NotEmpty()
                .WithMessage(Resources.RentTotalExpectedInvalid);
        }

        private void TotalValidate()
        {
            RuleFor(c => c.Total)
                .GreaterThan(0)
                .WithMessage(Resources.RentTotalInvalid)
                .NotNull()
                .WithMessage(Resources.RentTotalInvalid)
                .NotEmpty()
                .WithMessage(Resources.RentTotalInvalid);
        }

        private void StartDateValidate()
        {
            RuleFor(c => c.StartDate)
                .NotNull()
                .WithMessage(Resources.RentStartDateInvalid)
                .NotEmpty()
                .WithMessage(Resources.RentStartDateInvalid)
                .GreaterThanOrEqualTo(DateTime.Now)
                .WithMessage(Resources.RentStartDateInvalid)
                .LessThan(c => c.EndDate)
                .WithMessage(Resources.RentStartDateInvalid)
                .LessThan(s => s.EndDateExpected)
                .WithMessage(Resources.RentStartDateInvalid);
        }

        private void EndDateValidate()
        {
            RuleFor(c => c.EndDate)
                .NotNull()
                .WithMessage(Resources.RentEndDateInvalid)
                .NotEmpty()
                .WithMessage(Resources.RentEndDateInvalid)
                .GreaterThanOrEqualTo(DateTime.Now)
                .WithMessage(Resources.RentEndDateInvalid)
                .GreaterThan(s => s.StartDate)
                .WithMessage(Resources.RentEndDateInvalid);
        }

        private void EndDateExpectedValidate()
        {
            RuleFor(c => c.EndDateExpected)
                .NotNull()
                .WithMessage(Resources.RentEndDateInvalid)
                .NotEmpty()
                .WithMessage(Resources.RentEndDateInvalid)
                .GreaterThanOrEqualTo(DateTime.Now)
                .WithMessage(Resources.RentEndDateInvalid)
                .GreaterThan(s => s.StartDate)
                .WithMessage(Resources.RentEndDateInvalid);
        }
    }
}