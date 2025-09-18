using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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


    [BindProperty]
    public TVm Item { get; set; }

    public IList<TVm> Items { get; set; }

    protected PageBaseCadForm(ILogger logger, IBaseService<TVm> service)
    {
      Logger = logger;
      Service = service;
    }

    public virtual async Task<IActionResult> OnGetAsync()
    {
      Logger.LogInformation($"OnGet executado em {GetType().Name}");

      Items = new List<TVm>(await Service.GetAllAsync());
      return Page();
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
      Logger.LogInformation($"OnPost executado em {GetType().Name}");

      if (!ModelState.IsValid)
      {
        Items = new List<TVm>(await Service.GetAllAsync());
        return Page();
      }

      await Service.CreateAsync(Item);

      if (!string.IsNullOrWhiteSpace(PageName))
      {
        if (!string.IsNullOrWhiteSpace(AreaName))
          return RedirectToPage($"/{PageName}", new { area = AreaName });
        else
          return RedirectToPage($"/{PageName}");
      }

      return RedirectToPage(); // recarrega a mesma página
    }
  }
}