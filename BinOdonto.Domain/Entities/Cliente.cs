using System.ComponentModel.DataAnnotations;

public class Cliente
{
    [Key]
    public int ClienteID { get; set; }

    [Required]
    public required string Nome { get; set; }

    [Required]
    public required string CPF { get; set; }

    public DateTime DataNascimento { get; set; }

    [Required]
    public required string Email { get; set; }

    [Required]
    public required string CEP { get; set; }
}
