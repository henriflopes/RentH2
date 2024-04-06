using FluentValidation;
using RentH2.Domain.Base;
using RentH2.Domain.Utility;

namespace RentH2.Domain.Entities.Validators
{
    public class PlanValidator : RuleValidator<Plan>
    {
        public PlanValidator()
        {
            DescriptionValidate();
            TotalDaysValidate();
            DailyPriceValidate();
            TotalPriceValidate();
            FineAntecipatedValidate();
            FineDelayedValidate();
            StatusValidate();
        }

        public PlanValidator(string propertyName)
        {
            switch (propertyName)
            {
                case "Description":
                    DescriptionValidate();
                    break;
                case "TotalDays":
                    TotalDaysValidate();
                    break;
                case "DailyPrice":
                    DailyPriceValidate();
                    break;
                case "TotalPrice":
                    TotalPriceValidate();
                    break;
                case "FineAntecipated":
                    FineAntecipatedValidate();
                    break;
                case "FineDelayed":
                    FineDelayedValidate();
                    break;
                case "Status":
                    StatusValidate();
                    break;
                default:
                    break;
            }
        }

        private void FineDelayedValidate()
        {
            RuleFor(c => c.FineDelayed)
                .GreaterThan(0)
                .WithMessage(Resources.PlanFineDelayedInvalid)
                .NotNull()
                .WithMessage(Resources.PlanFineDelayedInvalid)
                .NotEmpty()
                .WithMessage(Resources.PlanFineDelayedInvalid);
        }

        private void FineAntecipatedValidate()
        {
            RuleFor(c => c.FineAntecipated)
                .GreaterThan(0)
                .WithMessage(Resources.PlanFineAntecipatedInvalid)
                .NotNull()
                .WithMessage(Resources.PlanFineAntecipatedInvalid)
                .NotEmpty()
                .WithMessage(Resources.PlanFineAntecipatedInvalid);
        }

        private void TotalPriceValidate()
        {
            RuleFor(c => c.TotalPrice)
                .GreaterThan(0)
                .WithMessage(Resources.PlanTotalPriceInvalid)
                .NotNull()
                .WithMessage(Resources.PlanTotalPriceInvalid)
                .NotEmpty()
                .WithMessage(Resources.PlanTotalPriceInvalid);
        }

        private void DailyPriceValidate()
        {
            RuleFor(c => c.DailyPrice)
                .GreaterThan(0)
                .WithMessage(Resources.PlanDailyPriceInvalid)
                .NotNull()
                .WithMessage(Resources.PlanDailyPriceInvalid)
                .NotEmpty()
                .WithMessage(Resources.PlanDailyPriceInvalid);
        }

        private void TotalDaysValidate()
        {
            RuleFor(c => c.TotalDays)
                .GreaterThan(0)
                .WithMessage(Resources.PlanTotalDaysInvalid)
                .NotNull()
                .WithMessage(Resources.PlanTotalDaysInvalid)
                .NotEmpty()
                .WithMessage(Resources.PlanTotalDaysInvalid);
        }

        private void DescriptionValidate()
        {
            RuleFor(c => c.Description)
                .NotEmpty()
                .WithMessage(Resources.PlanDescriptionInvalid)
                .NotNull()
                .WithMessage(Resources.PlanDescriptionInvalid)
                .Length(30, 120)
                .WithMessage(Resources.PlanDescriptionInvalid);
        }

        private void StatusValidate()
        {
            RuleFor(c => c.Status)
                .NotEmpty()
                .WithMessage(Resources.PlanStatusInvalid)
                .NotNull()
                .WithMessage(Resources.PlanStatusInvalid)
                .Length(10, 120)
                .WithMessage(Resources.PlanStatusInvalid)
                .Must(status => RentStatus.GetAllRentStatus().Contains(status))
                .WithMessage(Resources.PlanStatusInvalid);
        }
    }
}