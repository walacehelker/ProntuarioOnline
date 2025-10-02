using Microsoft.Extensions.DependencyInjection;
using Services.Cadastro;
using Implementations.Cadastro;
using Services.Prontuarios;
using Implementations.Prontuarios;

namespace InjectionDependency
{
  public static class DependencyInjectionConfig
  {
    public static IServiceCollection AddProjectDependencies(this IServiceCollection services)
    {
      services.AddScoped<IPessoaService, PessoaService>();
      services.AddScoped<IPessoaCadService, PessoaCadService>();
      services.AddScoped<IPessoaHistoricoService, PessoaHistoricoService>();
      services.AddScoped<IPtBotoxService, PtBotoxService>();
      services.AddScoped<IPtBotoxCadService, PtBotoxCadService>();
      services.AddScoped<IPtBioestimuladorService, PtBioestimuladorService>();
      services.AddScoped<IPtBioestimuladorCadService, PtBioestimuladorCadService>();
      services.AddScoped<IPtPreenchimentoFacialService, PtPreenchimentoFacialService>();
      services.AddScoped<IPtPreenchimentoFacialCadService, PtPreenchimentoFacialCadService>();
      services.AddScoped<IPtPreenchimentoFacialRelacaoAplicacaoService, PtPreenchimentoFacialRelacaoAplicacaoService>();
      services.AddScoped<IPtPreenchimentoFacialRelacaoEtiquetaService, PtPreenchimentoFacialRelacaoEtiquetaService>();

      return services;
    }
  }
}