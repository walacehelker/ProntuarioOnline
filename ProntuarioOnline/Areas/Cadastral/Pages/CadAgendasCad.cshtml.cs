using Microsoft.AspNetCore.Mvc;
using Models.Cadastro;
using Services.Cadastro;
using WebApp.Pages.Base;

namespace ProntuarioOnline.Areas.Cadastral.Pages
{
  public class CadAgendasCadModel : PageBaseCadForm<CadAgendaCadVm>
  {
    private readonly IAgendaCadService _dataService;
    private readonly IAgendaService _AgendaService;
    public CadAgendasCadModel(ILogger<CadAgendasCadModel> logger,
      IAgendaCadService dataService,
      IAgendaService AgendaService)
        : base(logger, dataService)
    {
      AreaName = "Cadastral";
      PageName = "CadAgendas";
      _dataService = dataService;
      _AgendaService = AgendaService;
    }


    public override async Task<IActionResult> OnGetAsync(Guid? id)
    {
      var result = await base.OnGetAsync(id);

      if (id == null && EntityVm != null && EntityVm.Data == default)
        EntityVm.Data = DateTime.Now;

      ModelState.Clear();

      return result;
    }
  }
}