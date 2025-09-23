using AutoMapper;
using Domain.Cadastro;
namespace ProntuarioOnline.Mappings;

public class MappingProfile : Profile
{
  public MappingProfile()
  {
    CreateMap<CadPessoa, CadPessoaVm>().ReverseMap();
    CreateMap<CadPessoaHistorico, CadPessoaHistoricoVm>().ReverseMap();
  }
}