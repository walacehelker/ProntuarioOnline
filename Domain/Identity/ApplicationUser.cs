using Microsoft.AspNetCore.Identity;
using Enuns;

namespace Domain.Identity
{
  public class ApplicationUser : IdentityUser
  {
    public TipoUsuario TipoUsuario { get; set; }
  }
}