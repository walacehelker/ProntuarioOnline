using System.ComponentModel.DataAnnotations;

namespace Enuns
{
  public enum TipoUsuario
  {
    [Display(Name = "Admin")] Admin = 1,
    [Display(Name = "Fisio Chefe")] FisioChefe = 2,
    [Display(Name = "Fisio")] Fisio = 3,
    [Display(Name = "Contratante")] Contratante = 4
  }

}
