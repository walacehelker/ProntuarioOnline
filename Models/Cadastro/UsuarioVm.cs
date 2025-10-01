using Domain.Identity;
using Enuns;
using System.ComponentModel.DataAnnotations;

namespace Models.Cadastro
{
  public class UsuarioVm
  {
    public Guid? Id { get; set; }

    [Display(Name = "Nome")]
    public string NomeCompleto { get; set; }

    [Display(Name = "Email")]
    public string Email { get; set; }

    [Display(Name = "Tipo do Usuário")]
    public TipoUsuario TipoUsuario { get; set; }
  }

  public class CadUsuarioVm
  {
    public string Id { get; set; }

    [Display(Name = "Nome")]
    [Required(ErrorMessage = "O nome é obrigatório")]
    public string NomeCompleto { get; set; }

    [Display(Name = "Email")]
    [Required(ErrorMessage = "O e-mail é obrigatório")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    public string Email { get; set; }

    [Display(Name = "Senha")]
    [Required(ErrorMessage = "A senha é obrigatória")]
    [DataType(DataType.Password)]
    public string Senha { get; set; }

    [Display(Name = "Confirmar Senha")]
    [DataType(DataType.Password)]
    [Compare("Senha", ErrorMessage = "As senhas não conferem")]
    public string ConfirmarSenha { get; set; }

    [Display(Name = "Tipo do Usuário")]
    public TipoUsuario TipoUsuario { get; set; }
  }
}
