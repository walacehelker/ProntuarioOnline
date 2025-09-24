using Domain.Identity;
using Enuns;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Cadastro;

[Authorize(Roles = "Admin")]
public class UsuariosCadModel : PageModel
{
  private readonly UserManager<ApplicationUser> _userManager;

  public UsuariosCadModel(UserManager<ApplicationUser> userManager)
  {
    _userManager = userManager;
  }

  [BindProperty]
  public CadUsuarioVm Usuario { get; set; }

  public async Task OnGetAsync(Guid? id)
  {
    if (id != null)
    {
      var user = await _userManager.FindByIdAsync(id.ToString());
      if (user != null)
      {
        Usuario = new CadUsuarioVm
        {
          Id = Guid.Parse(user.Id),
          NomeCompleto = user.NomeCompleto,
          Email = user.Email,
          TipoUsuario = user.TipoUsuario
        };
      }
    }
    else
    {
      Usuario = new CadUsuarioVm();
    }
  }

  public async Task<IActionResult> OnPostAsync()
  {
    if (!ModelState.IsValid)
      return Page();

    if (Usuario.Id == null)
    {
      // Novo usuário
      var user = new ApplicationUser
      {
        Email = Usuario.Email,
        UserName = Usuario.Email,
        NomeCompleto = Usuario.NomeCompleto,
        TipoUsuario = Usuario.TipoUsuario,
        EmailConfirmed = true
      };

      var result = await _userManager.CreateAsync(user, Usuario.Senha);

      if (result.Succeeded)
      {
        await _userManager.AddToRoleAsync(user, Usuario.TipoUsuario.ToString());
        return RedirectToPage("Usuarios");
      }

      foreach (var error in result.Errors)
        ModelState.AddModelError(string.Empty, error.Description);
    }
    else
    {
      // Edição
      var user = await _userManager.FindByIdAsync(Usuario.Id.ToString());
      if (user != null)
      {
        user.NomeCompleto = Usuario.NomeCompleto;
        user.Email = Usuario.Email;
        user.UserName = Usuario.Email;
        user.TipoUsuario = Usuario.TipoUsuario;

        var result = await _userManager.UpdateAsync(user);

        if (result.Succeeded)
          return RedirectToPage("Usuarios");

        foreach (var error in result.Errors)
          ModelState.AddModelError(string.Empty, error.Description);
      }
    }

    return Page();
  }
}