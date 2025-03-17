using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BinOdonto.Domain.Entities
{

    [Table("tb_funcionario")]
    public class Funcionario
    {
        [Key]
        public int FuncionarioID { get; set; }
        [DisplayName("Campo Nome:")]
        [Required(ErrorMessage = "Campo nome é obrigatorio")]
        public required string Nome { get; set; }
        public required string CPF { get; set; }
        public required string Cargo { get; set; }
        public decimal Salario { get; set; }
        public DateTime DataContratacao { get; set; }
    }


}