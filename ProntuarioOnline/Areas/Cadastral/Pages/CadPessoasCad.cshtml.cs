using Domain.Cadastro;
using Microsoft.AspNetCore.Mvc;
using Services.Cadastro;
using WebApp.Pages.Base;

namespace ProntuarioOnline.Areas.Cadastral.Pages.CadPessoas
{
  public class CadPessoasCad : PageBaseCadForm<CadPessoaVm>
  {
    private readonly IPessoaService _dataService;
    public CadPessoasCad(ILogger<CadPessoasCad> logger, IPessoaService dataService)
        : base(logger, dataService)
    {
      AreaName = "Cadastral";
      PageName = "CadPessoas";
      _dataService = dataService;
    }
  }
}