using Domain.Cadastro;
using Services.Cadastro;
using WebApp.Pages.Base;

namespace ProntuarioOnline.Areas.Cadastral.Pages.CadPessoas
{
  public class CadPessoas : PageBaseGrid<CadPessoaVm>
  {
    public CadPessoas(ILogger<CadPessoas> logger, IPessoaService service)
        : base(logger, service)
    {
    }

    // Se quiser l�gica extra, pode sobrescrever OnGetAsync ou OnPostAsync
  }

}
