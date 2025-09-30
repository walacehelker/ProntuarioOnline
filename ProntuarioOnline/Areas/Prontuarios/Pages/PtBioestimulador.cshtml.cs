using Domain.Prontuarios;
using Services.Prontuarios;
using WebApp.Pages.Base;

namespace ProntuarioOnline.Areas.Prontuarios.Pages
{
  public class PtBioestimuladorModel : PageBaseGrid<PtBioestimuladorVm>
  {
    public PtBioestimuladorModel(ILogger<PtBioestimulador> logger, IPtBioestimuladorService service)
    : base(logger, service)
    {
    }
  }
}
