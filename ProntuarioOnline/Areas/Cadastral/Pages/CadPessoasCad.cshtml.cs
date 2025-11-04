using Domain.Cadastro;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Cadastro;
using WebApp.Pages.Base;

namespace ProntuarioOnline.Areas.Cadastral.Pages.CadPessoas
{
  public class CadPessoasCad : PageBaseCadForm<CadPessoaCadVm>
  {
    private readonly IPessoaCadService _dataService;
    private readonly IPessoaService _pessoaService;
    public CadPessoasCad(ILogger<CadPessoasCad> logger,
      IPessoaCadService dataService,
      IPessoaService pessoaService)
        : base(logger, dataService)
    {
      AreaName = "Cadastral";
      PageName = "CadPessoas";
      _dataService = dataService;
      _pessoaService = pessoaService;
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
        EntityVm.PdfAssinado = null;
        await _dataService.UpdatePessoaComHistoricoAsync(EntityVm.Id, EntityVm);
      }
      else
      {
        await _dataService.CreatePessoaComHistoricoAsync(EntityVm);
      }

      return RedirectToPage($"/{PageName}", new { area = AreaName });
    }

    [HttpGet]
    public async Task<IActionResult> OnGetVerificarCpfAsync(string cpf)
    {
      if (string.IsNullOrWhiteSpace(cpf))
        return new JsonResult(new { existe = false });

      var pessoa = await _pessoaService.FindOneAsync(c => c.Cpf == cpf);

      return new JsonResult(new { existe = pessoa != null });
    }

  }
}