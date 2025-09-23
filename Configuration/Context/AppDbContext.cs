using Domain.Cadastro;
using Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Configuration
{
  public class AppDbContext : IdentityDbContext<ApplicationUser>
  {
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    // DbSets para cada entidade do domínio
    public DbSet<CadPessoa> CadPessoas { get; set; }
    public DbSet<CadPessoaHistorico> CadPessoaHistorico { get; set; }
    // Adicione aqui todos os outros DbSets do seu domínio

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // Configura tabelas do Identity
      base.OnModelCreating(modelBuilder);

      // Aplica todas as configurações Fluent API do projeto Configuration
      modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseConfiguration<>).Assembly);
    }
  }
}