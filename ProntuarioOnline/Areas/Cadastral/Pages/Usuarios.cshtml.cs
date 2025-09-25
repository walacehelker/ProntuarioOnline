using Domain.Identity;
using Enuns;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Cadastro;

[Authorize(Roles = "Admin")] // só administradores acessam
public class UsuariosModel : PageModel
{
  private readonly UserManager<ApplicationUser> _userManager;

  public UsuariosModel(UserManager<ApplicationUser> userManager)
  {
    _userManager = userManager;
  }

  public List<UsuarioVm> Usuarios { get; set; }

  public async Task OnGetAsync()
  {
    var usuarioLogado = await _userManager.GetUserAsync(User);

    var query = _userManager.Users.AsQueryable();

    if (usuarioLogado.TipoUsuario == TipoUsuario.Admin)
    {
      query = query;
    }
    else
    {
      query = query.Where(u => u.TipoUsuario != TipoUsuario.Admin);
    }

    Usuarios = query
        .Select(u => new UsuarioVm
        {
          Id = Guid.Parse(u.Id),
          NomeCompleto = u.NomeCompleto,
          Email = u.Email,
          TipoUsuario = u.TipoUsuario
        })
        .ToList();
  }

  public async Task<IActionResult> OnPostDeleteAsync(string id)
  {
    var user = await _userManager.FindByIdAsync(id);
    if (user != null)
    {
      await _userManager.DeleteAsync(user);
    }
    return RedirectToPage();
  }
}