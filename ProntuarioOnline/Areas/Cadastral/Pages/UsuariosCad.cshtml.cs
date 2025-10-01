using Domain.Identity;
using Enuns;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Cadastro;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

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
  public List<SelectListItem> TiposUsuarios { get; set; } = new();

  public async Task OnGetAsync(Guid? id)
  {
    if (id != null)
    {
      var user = await _userManager.FindByIdAsync(id.ToString());
      if (user != null)
      {
        Usuario = new CadUsuarioVm
        {
          Id = user.Id,
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

    var usuarioLogado = await _userManager.GetUserAsync(User);

    var tipos = Enum.GetValues(typeof(TipoUsuario))
        .Cast<TipoUsuario>();

    if (usuarioLogado.TipoUsuario != TipoUsuario.Admin)
      tipos = tipos.Where(t => t != TipoUsuario.Admin);

    TiposUsuarios = tipos
        .Select(t => new SelectListItem
        {
          Value = ((int)t).ToString(),
          Text = t.GetType()
                    .GetMember(t.ToString())
                    .First()
                    .GetCustomAttribute<DisplayAttribute>()?.Name ?? t.ToString()
        })
        .ToList();
  }


  public async Task<IActionResult> OnPostAsync()
  {
    if (!ModelState.IsValid)
      return Page();

    ApplicationUser user;
    var usuarioLogado = await _userManager.GetUserAsync(User);

    if (string.IsNullOrEmpty(Usuario.Id))
    {
      // Novo usuário
      user = new ApplicationUser
      {
        UserName = Usuario.Email,
        Email = Usuario.Email,
        NomeCompleto = Usuario.NomeCompleto,
        TipoUsuario = Usuario.TipoUsuario,
        UsuarioProprietarioId = usuarioLogado?.Id
      };

      var result = await _userManager.CreateAsync(user, Usuario.Senha);
      if (!result.Succeeded)
      {
        foreach (var error in result.Errors)
          ModelState.AddModelError(string.Empty, error.Description);
        return Page();
      }
    }
    else
    {
      // Edição de usuário
      user = await _userManager.FindByIdAsync(Usuario.Id.ToString());
      if (user == null)
        return NotFound();

      user.NomeCompleto = Usuario.NomeCompleto;
      user.Email = Usuario.Email;
      user.UserName = Usuario.Email;
      user.TipoUsuario = Usuario.TipoUsuario;
      user.UsuarioProprietarioId = usuarioLogado?.Id;

      var result = await _userManager.UpdateAsync(user);
      if (!result.Succeeded)
      {
        foreach (var error in result.Errors)
          ModelState.AddModelError(string.Empty, error.Description);
        return Page();
      }

      // 🔹 Se senha foi informada, atualiza
      if (!string.IsNullOrWhiteSpace(Usuario.Senha))
      {
        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        var passwordResult = await _userManager.ResetPasswordAsync(user, token, Usuario.Senha);

        if (!passwordResult.Succeeded)
        {
          foreach (var error in passwordResult.Errors)
            ModelState.AddModelError(string.Empty, error.Description);
          return Page();
        }
      }
    }

    return RedirectToPage("Usuarios");
  }
}