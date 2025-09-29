using Domain.Cadastro;
using Microsoft.AspNetCore.Mvc;
using Services.Cadastro;
using WebApp.Pages.Base;

namespace ProntuarioOnline.Areas.Cadastral.Pages.CadPessoas
{
  public class CadPessoasCad : PageBaseCadForm<CadPessoaCadVm>
  {
    private readonly IPessoaCadService _dataService;
    public CadPessoasCad(ILogger<CadPessoasCad> logger, IPessoaCadService dataService)
        : base(logger, dataService)
    {
      AreaName = "Cadastral";
      PageName = "CadPessoas";
      _dataService = dataService;
    }


    public override async Task<IActionResult> OnPostAsync()
    {
      Logger.LogInformation($"OnPost executado em {GetType().Name}");

      if (!TryValidateModel(EntityVm))
      {
        Items = new List<CadPessoaCadVm>(await _dataService.GetAllAsync());
        return Page();
      }

      if (EntityVm.Id != Guid.Empty)
      {
        await _dataService.UpdatePessoaComHistoricoAsync(EntityVm.Id, EntityVm);
      }
      else
      {
        await _dataService.CreatePessoaComHistoricoAsync(EntityVm);
      }

      return RedirectToPage($"/{PageName}", new { area = AreaName });
    }

  }
}