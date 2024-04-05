using FluentValidation;
using RentH2.Domain.Entities.Validators;

namespace RentH2.Domain.Base
{
    public class RuleValidator<T> : AbstractValidator<T>
    {
        private readonly List<string> _errorMessages;

        public RuleValidator()
        {
            _errorMessages = new List<string>();
        }

        public static RuleValidator<T> New()
        {
            return new RuleValidator<T>();
        }

        public RuleValidator<T> When(bool hasError, string errorMessage)
        {
            if (hasError)
                _errorMessages.Add(errorMessage);

            return this;
        }

        public void ThrowExceptionIfExists()
        {
            if (_errorMessages.Any())
                throw new ExceptionDomain(_errorMessages);
        }
    }
}
