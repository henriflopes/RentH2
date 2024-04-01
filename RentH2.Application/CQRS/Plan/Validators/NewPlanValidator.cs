using FluentValidation;
using RentH2.Common.Models;

namespace RentH2.Application.CQRSPlan.Validators
{
    public class NewPlanValidator : AbstractValidator<PlanModel>
    {
        public NewPlanValidator()
        {
            DescriptionValidate();
            TotalDaysValidate();
            DailyPriceValidate();
            TotalPriceValidate();
            FineAntecipatedValidate();
            FineDelayedValidate();
        }

        private void DescriptionValidate()
        {
            RuleFor(c => c.Description)
                .NotEmpty()
                .NotNull()
                .Length(4, 120)
                .WithMessage("Descrição inválida. Por favor verificar os dados informados!");
        }

        private void TotalDaysValidate()
        {
            RuleFor(c => c.TotalDays)
                .GreaterThan(0)
                .WithMessage("Total de dias inválido. Por favor verificar os dados informados!");
        }

        private void DailyPriceValidate()
        {
            RuleFor(c => c.DailyPrice)
                .GreaterThan(0)
                .WithMessage("Preço diário inválido. Por favor verificar os dados informados!");
        }

        private void TotalPriceValidate()
        {
            RuleFor(c => c.TotalPrice)
                .GreaterThan(0)
                .WithMessage("Valor total do plano inválido. Por favor verificar os dados informados!");
        }

        private void FineAntecipatedValidate()
        {
            RuleFor(c => c.FineAntecipated)
                .GreaterThan(0)
                .WithMessage("Valor da multa por antecipação inválida. Por favor verificar os dados informados!");
        }

        private void FineDelayedValidate()
        {
            RuleFor(c => c.FineDelayed)
                .GreaterThan(0)
                .WithMessage("Valor da multa por atraso inválida. Por favor verificar os dados informados!");
        }
    }
}