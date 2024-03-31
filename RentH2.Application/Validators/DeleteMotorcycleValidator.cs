using FluentValidation;
using RentH2.Common.Models;

namespace RentH2.Application.Validators
{
    public class DeleteMotorcycleValidator : AbstractValidator<MotorcycleModel>
    {
        public DeleteMotorcycleValidator()
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