using Microsoft.AspNetCore.Identity;
using Enuns;

namespace Domain.Identity
{
  public class ApplicationUser : IdentityUser
  {
    public string NomeCompleto { get; set; }
    public TipoUsuario TipoUsuario { get; set; }
  }
}