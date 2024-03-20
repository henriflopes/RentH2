using System;
using System.ComponentModel.DataAnnotations;

namespace RentH2.Web.Utility
{
    public class DoubleAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null && !double.TryParse(value.ToString(), out _))
            {
                return new ValidationResult("Please enter a AAAvalid numeric value.");
            }
            return ValidationResult.Success;
        }
    }
}
