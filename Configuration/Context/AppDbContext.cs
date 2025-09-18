using Domain.Cadastro;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Configuration
{
  public class AppDbContext : IdentityDbContext<IdentityUser>
  {
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    // DbSets para cada entidade do domínio
    public DbSet<CadPessoa> CadPessoas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // Aplica todas as configurações do projeto Configuration
      modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseConfiguration<>).Assembly);

      base.OnModelCreating(modelBuilder);
    }
  }
}