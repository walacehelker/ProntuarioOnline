using Domain.Cadastro;
using Microsoft.AspNetCore.Mvc;
using Models.Cadastro;
using Services.Cadastro;
using System.ComponentModel.DataAnnotations;
using WebApp.Pages.Base;

namespace ProntuarioOnline.Areas.Cadastral.Pages
{
  public class CadAgendasModel : PageBaseGrid<CadAgendaVm>
  {
    public CadAgendasModel(ILogger<CadAgenda> logger, IAgendaService service)
        : base(logger, service)
    {
    }

    // Propriedade de filtro (bind no GET)
    [BindProperty(SupportsGet = true)]
    [DataType(DataType.Date)]
    public DateTime? FiltroData { get; set; }

    public override async Task<IActionResult> OnGetAsync()
    {
      // Se não foi informado, usa o dia atual
      if (FiltroData == null)
        FiltroData = DateTime.Today;

      // Aqui você pode usar o service para buscar filtrado
      Items = (await Service.GetAllAsync())
    .Where(a => a.Data.Date == FiltroData.Value.Date)
    .ToList();

      // Exemplo de filtro simples (ajuste conforme sua query real)
      if (FiltroData.HasValue)
        Items = Items.Where(a => a.Data.Date == FiltroData.Value.Date).ToList();

      return Page();
    }
  }
}