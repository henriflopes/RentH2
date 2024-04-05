using FluentValidation;
using RentH2.Domain.Base;
using RentH2.Domain.Utility;

namespace RentH2.Domain.Entities.Validators
{
    public class MotorcycleValidator : RuleValidator<Motorcycle>
    {
        public MotorcycleValidator()
        {
            TypeValidate();
            YearValidate();
            NumberPlateValidate();
            LocationValidate();
            StatusValidate();   
        }

        public MotorcycleValidator(string propertyName)
        {
            switch (propertyName)
            {
                case "Type":
                    TypeValidate();
                    break;
                case "Year":
                    YearValidate();
                    break;
                case "NumberPlate":
                    NumberPlateValidate();
                    break;
                case "Location":
                    LocationValidate();
                    break;
                case "Status":
                    StatusValidate();
                    break;
                default:
                    break;
            }
        }

        private void TypeValidate()
        {
            RuleFor(c => c.Type)
                .NotEmpty()
                .WithMessage(Resources.MotorcycleInvalidType)
                .NotNull()
                .WithMessage(Resources.MotorcycleInvalidType)
                .Length(4, 120)
                .WithMessage(Resources.MotorcycleInvalidType);
        }

        private void YearValidate()
        {
            RuleFor(c => c.Year)
                .NotEmpty()
                .WithMessage(Resources.MotorcycleInvalidYear)
                .NotNull()
                .WithMessage(Resources.MotorcycleInvalidYear)
                .Length(0, 4)
                .WithMessage(Resources.MotorcycleInvalidYear);

            Transform(from: x => x.Year, to: value => int.TryParse(value, out int val) ? (int?)val : null)
                .GreaterThan(0)
                .WithMessage(Resources.MotorcycleInvalidYear)
                .NotNull()
                .WithMessage(Resources.MotorcycleInvalidYear);
        }

        private void NumberPlateValidate()
        {
            RuleFor(c => c.NumberPlate)
                .NotEmpty()
                .WithMessage(Resources.MotorcycleInvalidNumberPlate)
                .NotNull()
                .WithMessage(Resources.MotorcycleInvalidNumberPlate)
                .Length(4, 40)
                .WithMessage(Resources.MotorcycleInvalidNumberPlate);
        }

        private void LocationValidate()
        {
            RuleFor(c => c.Location)
                .NotEmpty()
                .WithMessage(Resources.MotorcycleInvalidLocation)
                .NotNull()
                .WithMessage(Resources.MotorcycleInvalidLocation)
                .Length(10, 120)
                .WithMessage(Resources.MotorcycleInvalidLocation);
        }

        private void StatusValidate()
        {
            RuleFor(c => c.Status)
                .NotEmpty()
                .WithMessage(Resources.MotorcycleInvalidStatus)
                .NotNull()
                .WithMessage(Resources.MotorcycleInvalidStatus)
                .Length(10, 120)
                .WithMessage(Resources.MotorcycleInvalidStatus)
                .Must( status => RentStatus.GetAllRentStatus().Contains(status) )
                .WithMessage(Resources.MotorcycleInvalidStatus);
        }
    }
}