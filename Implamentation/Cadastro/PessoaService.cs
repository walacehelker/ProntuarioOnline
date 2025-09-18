using AutoMapper;
using Domain.Cadastro;
using Implementations.Base;
using Configuration;
using Services.Cadastro;

namespace Implementations.Cadastro
{
  public class PessoaService : BaseService<CadPessoa, CadPessoaVm>, IPessoaService
  {
    public PessoaService(AppDbContext context, IMapper mapper)
        : base(context, mapper)
    {
    }
  }
}