using Domain.Prontuarios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Cadastro;
using Services.Prontuarios;
using WebApp.Pages.Base;

namespace ProntuarioOnline.Areas.Prontuarios.Pages
{
  public class PtBioestimuladorCadModel : PageBaseCadForm<PtBioestimuladorCadVm>
  {
    private readonly IPtBioestimuladorCadService _dataService;
    private readonly IPessoaService _pessoaService;
    public PtBioestimuladorCadModel(ILogger<PtBioestimulador> logger,
      IPtBioestimuladorCadService dataService,
      IPessoaService pessoaService)
    : base(logger, dataService)
    {
      AreaName = "Prontuarios";
      PageName = "PtBioestimulador";
      _dataService = dataService;
      _pessoaService = pessoaService;
    }

    public SelectList PessoasSelectList { get; set; }

    public override async Task<IActionResult> OnGetAsync(Guid? id)
    {
      var resultadoBase = await base.OnGetAsync(id);

      EntityVm.PdfAssinado = null;
      EntityVm.DataAssinatura = null;

      var pessoas = await _pessoaService.GetAllAsync();
      PessoasSelectList = new SelectList(pessoas, "Id", "Nome");

      
      return resultadoBase;
    }

  }
}
