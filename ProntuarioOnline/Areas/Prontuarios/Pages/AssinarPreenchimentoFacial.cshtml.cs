using Domain.Cadastro;
using Domain.Identity;
using Domain.Prontuarios;
using Implementations.Prontuarios;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Cadastro;
using Services.Prontuarios;

namespace ProntuarioOnline.Areas.Prontuarios.Pages
{
  public class AssinarPreenchimentoFacialModel : PageModel
  {
    private readonly IPtPreenchimentoFacialCadService _ptPreenchimentoFacialCadService;
    private readonly IPessoaService _pessoaService;
    private readonly UserManager<ApplicationUser> _userManager;
    public AssinarPreenchimentoFacialModel(IPtPreenchimentoFacialCadService ptPreenchimentoFacialCadService,
      IPessoaService pessoaService,
      UserManager<ApplicationUser> userManager)
    {
      _ptPreenchimentoFacialCadService = ptPreenchimentoFacialCadService;
      _pessoaService = pessoaService;
      _userManager = userManager;
    }

    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    public Guid PreenchimentoFacialId => Id;

    [BindProperty]
    public PtPreenchimentoFacialCadVm PtPreenchimentoFacialCad { get; set; }

    public CadPessoaVm Pessoa { get; set; }
    public string UsuarioLogado { get; set; }
    public async Task OnGetAsync()
    {
      var dados = await _ptPreenchimentoFacialCadService.GetByIdAsync(Id);
      Pessoa = _pessoaService.FindOne(c => c.Id == dados.PessoaId);
      var user = await _userManager.GetUserAsync(User);
      UsuarioLogado = user?.NomeCompleto;
    }

    [ValidateAntiForgeryToken]
    public async Task<IActionResult> OnPostSalvarAssinaturaAsync([FromBody] AssinaturaPreenchimentoFacialVm assinatura)
    {
      if (assinatura?.PdfAssinado == null || assinatura.PdfAssinado.Length == 0)
        return BadRequest("Assinatura inválida.");

      var dados = await _ptPreenchimentoFacialCadService.GetByIdAsync(assinatura.Id);
      if (dados == null) return NotFound();

      dados.AssinaturaTermoConsentimento = assinatura.PdfAssinado;
      dados.Observacoes = assinatura.Observacoes;
      dados.DataAssinatura = DateTime.Now;

      await _ptPreenchimentoFacialCadService.UpdateAsync(dados);

      return new JsonResult(new { success = true });
    }
  }
}
