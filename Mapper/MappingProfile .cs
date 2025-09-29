using AutoMapper;
using Domain.Cadastro;
using Domain.Prontuarios;
namespace ProntuarioOnline.Mappings;

public class MappingProfile : Profile
{
  public MappingProfile()
  {
    CreateMap<CadPessoa, CadPessoaVm>().ReverseMap();
    CreateMap<CadPessoaHistorico, CadPessoaHistoricoVm>().ReverseMap();
    CreateMap<PtBotox, PtBotoxVm>().ReverseMap();
  }
}