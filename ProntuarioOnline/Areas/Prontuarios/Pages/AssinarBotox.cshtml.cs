using Domain.Cadastro;
using Domain.Prontuarios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Prontuarios;

namespace ProntuarioOnline.Areas.Prontuarios.Pages
{
  public class AssinarBotoxModel : PageModel
  {
    private readonly IPtBotoxCadService _ptBotoxCadService;
    public AssinarBotoxModel(IPtBotoxCadService ptBotoxCadService)
    {
      _ptBotoxCadService = ptBotoxCadService;
    }

    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    public Guid BotoxId => Id;

    [BindProperty]
    public PtBotoxCadVm PtBotoxCad { get; set; }

    [ValidateAntiForgeryToken]
    public async Task<IActionResult> OnPostSalvarAssinaturaAsync([FromBody] AssinaturaBotoxVm assinatura)
    {
      if (assinatura?.PdfAssinado == null || assinatura.PdfAssinado.Length == 0)
        return BadRequest("Assinatura inválida.");

      var dados = await _ptBotoxCadService.GetByIdAsync(assinatura.Id);
      if (dados == null) return NotFound();

      dados.PdfAssinado = assinatura.PdfAssinado;
      dados.AceitaDivulgacao = assinatura.AceitaDivulgacao;
      dados.Observacoes = assinatura.Observacoes;
      dados.DataAssinatura = DateTime.Now;

      await _ptBotoxCadService.UpdateAsync(dados);

      return new JsonResult(new { success = true });
    }
  }
}
