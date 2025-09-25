using System.ComponentModel.DataAnnotations;

namespace Enuns
{
  public enum TipoUsuario
  {
    [Display(Name = "Administrador")] Admin = 1,
    [Display(Name = "Contratante")] Contratante = 2,
    [Display(Name = "Outro")] Outro = 3
  }

}
