using AutoMapper;
using Domain.Cadastro;
using Implementations.Base;
using Configuration;
using Services.Cadastro;

namespace Implementations.Cadastro
{
  public class PessoaHistoricoService : BaseService<CadPessoaHistorico, CadPessoaHistoricoVm>, IPessoaHistoricoService
  {
    public PessoaHistoricoService(AppDbContext context, IMapper mapper)
        : base(context, mapper)
    {
    }
  }
}