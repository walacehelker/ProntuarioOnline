using System.Security.Claims;
using Domain.Base;
using Domain.Cadastro;
using Domain.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Configuration
{
  public class AppDbContext : IdentityDbContext<ApplicationUser>
  {
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AppDbContext(DbContextOptions<AppDbContext> options,
                        IHttpContextAccessor httpContextAccessor)
        : base(options)
    {
      _httpContextAccessor = httpContextAccessor;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseConfiguration<>).Assembly);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
      var userId = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
      var now = DateTime.UtcNow;

      foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
      {
        if (entry.State == EntityState.Added)
        {
          if (entry.Entity.DataInsercao == default)
            entry.Entity.DataInsercao = now;

          if (string.IsNullOrEmpty(entry.Entity.UsuarioProprietarioId) && !string.IsNullOrEmpty(userId))
            entry.Entity.UsuarioProprietarioId = userId;
        }
      }

      return await base.SaveChangesAsync(cancellationToken);
    }
  }
}