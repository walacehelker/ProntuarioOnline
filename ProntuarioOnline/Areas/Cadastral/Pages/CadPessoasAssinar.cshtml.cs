using Domain.Cadastro;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Cadastro;
using System;
using System.Threading.Tasks;

namespace ProntuarioOnline.Areas.Cadastral.Pages
{
  public class CadPessoasAssinarModel : PageModel
  {
    private readonly IPessoaService _pessoaService;
    private readonly IPessoaCadService _pessoaCadService;

    public CadPessoasAssinarModel(IPessoaService pessoaService, IPessoaCadService pessoaCadService)
    {
      _pessoaService = pessoaService;
      _pessoaCadService = pessoaCadService;
    }

    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    public string PdfFileName { get; set; }
    public Guid PessoaId => Id;

    // 🔹 Propriedade que a view vai usar
    [BindProperty]
    public CadPessoaCadVm Pessoa { get; set; }

    public async Task OnGetAsync()
    {
      // Carrega os dados da pessoa
      Pessoa = await _pessoaCadService.GetByIdAsync(Id);

      // Define qual PDF abrir (pode ser um contrato padrão, por exemplo)
      PdfFileName = "contrato-modelo.pdf";
    }

    [ValidateAntiForgeryToken]
    public async Task<IActionResult> OnPostSalvarAssinaturaAsync([FromBody] AssinaturaVm assinatura)
    {
      if (assinatura?.PdfAssinado == null || assinatura.PdfAssinado.Length == 0)
        return BadRequest("Assinatura inválida.");

      var pessoa = await _pessoaCadService.GetByIdAsync(assinatura.Id);
      if (pessoa == null) return NotFound();

      pessoa.PdfAssinado = assinatura.PdfAssinado;
      await _pessoaCadService.UpdatePessoaComHistoricoAsync(pessoa.Id, pessoa);

      return new JsonResult(new { success = true });
    }


  }
}