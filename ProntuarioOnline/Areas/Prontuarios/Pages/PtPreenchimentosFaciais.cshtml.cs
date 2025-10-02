using Domain.Prontuarios;
using Services.Prontuarios;
using WebApp.Pages.Base;

namespace ProntuarioOnline.Areas.Prontuarios.Pages
{
  public class PtPreenchimentosFaciaisModel : PageBaseGrid<PtPreenchimentoFacialVm>
  {
    public PtPreenchimentosFaciaisModel(ILogger<PtPreenchimentoFacial> logger, IPtPreenchimentoFacialService service)
    : base(logger, service)
    {
    }
  }
}
