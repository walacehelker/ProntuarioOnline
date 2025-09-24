using Domain.Cadastro;
using Services.Base;

namespace Services.Cadastro
{
  public interface IPessoaCadService : IBaseService<CadPessoaCadVm>
  {
    Task<bool> CreatePessoaComHistoricoAsync(CadPessoaCadVm model);
    Task<bool> UpdatePessoaComHistoricoAsync(Guid id, CadPessoaCadVm model);
  }
}
