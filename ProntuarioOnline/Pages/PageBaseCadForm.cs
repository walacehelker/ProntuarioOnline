using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Base;
using Services.Base;

namespace WebApp.Pages.Base
{
  public abstract class PageBaseCadForm<TVm> : PageModel
      where TVm : class, new()
  {
    protected readonly ILogger Logger;
    protected readonly IBaseService<TVm> Service;

    protected string AreaName { get; set; }
    protected string PageName { get; set; }

    [BindProperty(SupportsGet = true)]
    public Guid? Id { get; set; }

    [BindProperty]
    public TVm EntityVm { get; set; }

    public IList<TVm> Items { get; set; }

    protected PageBaseCadForm(ILogger logger, IBaseService<TVm> service)
    {
      Logger = logger;
      Service = service;
    }

    public virtual async Task<IActionResult> OnGetAsync(Guid? id)
    {
      Logger.LogInformation($"OnGet executado em {GetType().Name}");

      if (id.HasValue && id.Value != Guid.Empty)
      {
        // Busca o item pelo ID
        var itemEncontrado = await Service.GetByIdAsync(id.Value);

        if (itemEncontrado == null)
        {
          // Retorna 404 se não encontrar
          return NotFound();
        }

        EntityVm = itemEncontrado;
      }
      else
      {
        // Se não houver ID, não carrega nada
        EntityVm = new TVm();
      }

      return Page();
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
      Logger.LogInformation($"OnPost executado em {GetType().Name}");

      if (!TryValidateModel(EntityVm))
      {
        Items = new List<TVm>(await Service.GetAllAsync());
        return Page();
      }

      var entityExist = (EntityVm is BaseVmEntity baseEntity && baseEntity.Id != Guid.Empty)
          ? await Service.GetByIdAsync(baseEntity.Id)
          : null;

      if (entityExist == null)
      {
        await Service.CreateAsync(EntityVm);
      }
      else
      {
        await Service.UpdateAsync(EntityVm);
      }

      if (!string.IsNullOrWhiteSpace(PageName))
      {
        if (!string.IsNullOrWhiteSpace(AreaName))
          return RedirectToPage($"/{PageName}", new { area = AreaName });
        else
          return RedirectToPage($"/{PageName}");
      }

      return RedirectToPage();
    }
  }
}