using Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProntuarioOnline.Areas.Cadastral.Pages
{
  public class UsuariosAssinaturasModel : PageModel
  {
    private readonly UserManager<ApplicationUser> _userManager;

    public UsuariosAssinaturasModel(UserManager<ApplicationUser> userManager)
    {
      _userManager = userManager;
    }
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }
    public Guid UsuarioId => Id;

    public class AssinaturaUsuarioVm
    {
      public Guid Id { get; set; }
      public byte[] PdfAssinado { get; set; }
    }

    [ValidateAntiForgeryToken]
    public async Task<IActionResult> OnPostSalvarAssinaturaAsync([FromBody] AssinaturaUsuarioVm assinatura)
    {
      if (assinatura?.PdfAssinado == null || assinatura.PdfAssinado.Length == 0)
        return BadRequest("Assinatura inválida.");

      var user = await _userManager.FindByIdAsync(assinatura.Id.ToString());
      if (user == null) return NotFound();

      user.Assinatura = assinatura.PdfAssinado;

      var result = await _userManager.UpdateAsync(user);
      if (!result.Succeeded)
        return BadRequest(result.Errors);

      return new JsonResult(new { success = true });
    }
  }
}