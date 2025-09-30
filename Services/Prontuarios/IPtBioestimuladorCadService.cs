using Domain.Cadastro;
using Domain.Prontuarios;
using Services.Base;

namespace Services.Prontuarios
{
  public interface IPtBioestimuladorCadService : IBaseService<PtBioestimuladorCadVm>
  {
    Task<PtBioestimuadorDadosPessoaVm> GetByIdComPessoaAsync(Guid id);
  }
}
