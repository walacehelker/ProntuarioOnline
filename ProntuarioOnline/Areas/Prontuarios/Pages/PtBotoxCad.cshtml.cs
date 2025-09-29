using Domain.Prontuarios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Cadastro;
using Services.Prontuarios;
using WebApp.Pages.Base;

namespace ProntuarioOnline.Areas.Prontuarios.Pages
{
  public class PtBotoxCadModel : PageBaseCadForm<PtBotoxCadVm>
  {
    private readonly IPtBotoxCadService _dataService;
    private readonly IPessoaService _pessoaService;
    public PtBotoxCadModel(ILogger<PtBotox> logger,
      IPtBotoxCadService dataService,
      IPessoaService pessoaService)
    : base(logger, dataService)
    {
      AreaName = "Prontuarios";
      PageName = "PtBotox";
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
