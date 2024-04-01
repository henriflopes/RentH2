using FluentValidation;
using RentH2.Common.Models;

namespace RentH2.Application.CQRSPlan.Validators
{
    public class DeletePlanValidator : AbstractValidator<PlanModel>
    {
        public DeletePlanValidator()
        {
            IdValidate();
        }

        private void IdValidate()
        {
            RuleFor(c => c.Id)
                .NotNull()
                .NotEmpty()
                .WithMessage("Id inválido para exclusão. Por favor verificar!");
        }
    }
}