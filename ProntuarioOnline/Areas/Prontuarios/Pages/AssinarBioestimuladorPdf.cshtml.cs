using Domain.Cadastro;
using Domain.Identity;
using Domain.Prontuarios;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Prontuarios;

namespace ProntuarioOnline.Areas.Prontuarios.Pages
{
  public class AssinarBioestimuladorPdfModel : PageModel
  {
    private readonly IPtBioestimuladorCadService _ptBioestimuladorCadService;
    private readonly UserManager<ApplicationUser> _userManager;
    public AssinarBioestimuladorPdfModel(IPtBioestimuladorCadService ptBioestimuladorCadService,
      UserManager<ApplicationUser> userManager)
    {
      _ptBioestimuladorCadService = ptBioestimuladorCadService;
      _userManager = userManager;
    }

    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    public Guid BioestimuladorId => Id;

    [BindProperty]
    public PtBioestimuadorDadosPessoaVm Dados { get; set; }

    public string UsuarioLogado { get; set; }

    public async Task OnGetAsync()
    {
      Dados = await _ptBioestimuladorCadService.GetByIdComPessoaAsync(Id);
      var user = await _userManager.GetUserAsync(User);
      UsuarioLogado = user?.NomeCompleto;
    }

    [ValidateAntiForgeryToken]
    public async Task<IActionResult> OnPostSalvarAssinaturaAsync([FromBody] AssinaturaBioestimuladorVm assinatura)
    {
      if (assinatura?.PdfAssinado == null || assinatura.PdfAssinado.Length == 0)
        return BadRequest("Assinatura inválida.");

      var dados = await _ptBioestimuladorCadService.GetByIdAsync(assinatura.Id);
      if (dados == null) return NotFound();

      dados.PdfAssinado = assinatura.PdfAssinado;
      dados.AceitaCompartilhamentoDados = assinatura.AceitaCompartilhamentoDados;
      dados.AceitaDivulgacao = assinatura.AceitaDivulgacao;
      dados.AceitaDivulgacaoCongresso = assinatura.AceitaDivulgacaoCongresso;

      await _ptBioestimuladorCadService.UpdateAsync(dados);

      return new JsonResult(new { success = true });
    }
  }
}
