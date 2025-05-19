using System.ComponentModel.DataAnnotations;

public class Funcionario
{
    [Key]
    public int FuncionarioID { get; set; }

    [Required]
    public required string Nome { get; set; }

    [Required]
    public required string CPF { get; set; }

    [Required]
    public required string Cargo { get; set; }

    public decimal Salario { get; set; }

    public DateTime DataContratacao { get; set; }

    [Required]
    public required string CEP { get; set; }
}
