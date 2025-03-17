using System;
using System.ComponentModel.DataAnnotations;

namespace BinOdonto.Application.Validations
{
    public class DataContratacaoValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not DateTime dataContratacao)
            {
                return new ValidationResult("Data de contratação inválida.");
            }

            if (dataContratacao > DateTime.Now)
            {
                return new ValidationResult("A data de contratação não pode ser no futuro.");
            }

            return ValidationResult.Success;
        }
    }
}
