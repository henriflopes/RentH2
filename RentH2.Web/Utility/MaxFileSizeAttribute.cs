﻿using System.ComponentModel.DataAnnotations;

namespace RentH2.Web.Utility
{
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int _maxFileSize;

        public MaxFileSizeAttribute(int maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                if (file.Length > _maxFileSize * 1024 * 1024)
                {
                    return new ValidationResult($"O tamanho total do arquivo permitido é {_maxFileSize} MB.");
                }
            }

            return ValidationResult.Success;
        }
    }
}