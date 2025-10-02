using Domain.Prontuarios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Cadastro;
using Services.Prontuarios;
using WebApp.Pages.Base;

namespace ProntuarioOnline.Areas.Prontuarios.Pages
{
  public class PtPreenchimentosFaciaisCadCadModel : PageBaseCadForm<PtPreenchimentoFacialCadVm>
  {
    private readonly IPtPreenchimentoFacialCadService _dataService;
    private readonly IPessoaService _pessoaService;
    public PtPreenchimentosFaciaisCadCadModel(ILogger<PtPreenchimentoFacial> logger,
      IPtPreenchimentoFacialCadService dataService,
      IPessoaService pessoaService)
    : base(logger, dataService)
    {
      AreaName = "Prontuarios";
      PageName = "PtPreenchimentosFaciais";
      _dataService = dataService;
      _pessoaService = pessoaService;
    }

    public SelectList PessoasSelectList { get; set; }

    public override async Task<IActionResult> OnGetAsync(Guid? id)
    {  
      var pessoas = await _pessoaService.GetAllAsync();
      PessoasSelectList = new SelectList(pessoas, "Id", "Nome");

      
      return await base.OnGetAsync(id);
    }

  }
}
