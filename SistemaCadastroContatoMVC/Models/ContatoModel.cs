using System.ComponentModel.DataAnnotations;

namespace SistemaCadastroContatoMVC.Models;

public class ContatoModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Digite o nome do contato!")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "Digite o email do contato!")]
    [EmailAddress(ErrorMessage = "O email informado é invalido!")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Digite o número de telefone do contato!")]
    [Phone(ErrorMessage = "O número de telefone é invalido")]
    public string Telefone { get; set; } = string.Empty;
}
