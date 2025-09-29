using Domain.Prontuarios;
using Services.Prontuarios;
using WebApp.Pages.Base;

namespace ProntuarioOnline.Areas.Prontuarios.Pages
{
  public class PtBotoxModel : PageBaseGrid<PtBotoxVm>
  {
    public PtBotoxModel(ILogger<PtBotox> logger, IPtBotoxService service)
    : base(logger, service)
    {
    }
  }
}
