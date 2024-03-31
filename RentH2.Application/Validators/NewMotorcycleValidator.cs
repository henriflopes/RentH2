using FluentValidation;
using RentH2.Common.Models;

namespace RentH2.Application.Validators
{
    public class NewMotorcycleValidator : AbstractValidator<MotorcycleModel>
    {
        public NewMotorcycleValidator()
        {
            TypeValidate();
            YearValidate();
            NumberPlateValidate();
            LocationValidate();
            StatusValidate();
        }

        private void TypeValidate()
        {
            RuleFor(c => c.Type)
                .NotEmpty()
                .NotNull()
                .Length(4, 120)
                .WithMessage("Tipo inválido. Por favor verificar os dados informados!");
        }

        private void YearValidate()
        {
            RuleFor(c => c.Year)
                .NotEmpty()
                .NotNull()
                .Length(0, 4)
                .WithMessage("Ano inválido. Por favor verificar os dados informados!");
        }

        private void NumberPlateValidate()
        {
            RuleFor(c => c.NumberPlate)
                .NotEmpty()
                .NotNull()
                .Length(4, 120)
                .WithMessage("Numero da Placa inválido. Por favor verificar os dados informados!");
        }

        private void LocationValidate()
        {
            RuleFor(c => c.Location)
                .NotEmpty()
                .NotNull()
                .Length(10, 120)
                .WithMessage("Localização inválido. Por favor verificar os dados informados!");
        }

        private void StatusValidate()
        {
            RuleFor(c => c.Status)
                .NotEmpty()
                .NotNull()
                .Length(10, 120)
                .WithMessage("Status inválido. Por favor verificar os dados informados!");
        }
    }
}