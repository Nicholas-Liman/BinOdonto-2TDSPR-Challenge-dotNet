using System;
using System.ComponentModel.DataAnnotations;
using BinOdonto.Application.Validations;

namespace BinOdonto.Application.Dtos
{
    public class ClienteDTO
    {
        public int ClienteID { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode ter mais que 100 caracteres.")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [CpfValidation(ErrorMessage = "O CPF informado é inválido.")]
        public required string CPF { get; set; }

        [Required(ErrorMessage = "A Data de Nascimento é obrigatória.")]
        [DataType(DataType.Date, ErrorMessage = "Data de Nascimento inválida.")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O formato do email é inválido.")]
        public required string Email { get; set; }
    }
}
