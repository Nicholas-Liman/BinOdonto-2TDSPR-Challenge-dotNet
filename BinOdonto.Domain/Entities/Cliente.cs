using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BinOdonto.Domain.Entities
{
    [Table("tb_cliente")]
    public class Cliente
    {
        [Key]
        public int ClienteID { get; set; }
        public required string Nome { get; set; }
        public required string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public required string Email { get; set; }
    }
}
