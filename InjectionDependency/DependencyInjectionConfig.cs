using Microsoft.Extensions.DependencyInjection;
using Services.Cadastro;
using Implementations.Cadastro;

namespace InjectionDependency
{
  public static class DependencyInjectionConfig
  {
    public static IServiceCollection AddProjectDependencies(this IServiceCollection services)
    {
      services.AddScoped<IPessoaService, PessoaService>();
      services.AddScoped<IPessoaCadService, PessoaCadService>();
      services.AddScoped<IPessoaHistoricoService, PessoaHistoricoService>();

      return services;
    }
  }
}