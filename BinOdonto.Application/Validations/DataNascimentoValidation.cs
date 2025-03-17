using System;
using System.ComponentModel.DataAnnotations;

namespace BinOdonto.Application.Validations
{
    public class DataNascimentoValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not DateTime dataNascimento)
            {
                return new ValidationResult("Data de nascimento inválida.");
            }

            if (dataNascimento >= DateTime.Now)
            {
                return new ValidationResult("A data de nascimento deve ser no passado.");
            }

            var idade = DateTime.Now.Year - dataNascimento.Year;
            if (dataNascimento.AddYears(idade) > DateTime.Now)
            {
                idade--;
            }

            if (idade > 150)
            {
                return new ValidationResult("A idade não pode ser maior que 150 anos.");
            }

            return ValidationResult.Success;
        }
    }
}
