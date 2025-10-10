using AutoMapper;
using Domain.Cadastro;
using Domain.Prontuarios;
using Models.Cadastro;
namespace ProntuarioOnline.Mappings;

public class MappingProfile : Profile
{
  public MappingProfile()
  {
    CreateMap<CadPessoa, CadPessoaVm>().ReverseMap();
    CreateMap<CadPessoaHistorico, CadPessoaHistoricoVm>().ReverseMap();
    CreateMap<PtBotox, PtBotoxVm>().ReverseMap();
    CreateMap<PtBioestimulador, PtBioestimuladorVm>().ReverseMap();
    CreateMap<PtPreenchimentoFacial, PtPreenchimentoFacialVm>().ReverseMap();
    CreateMap<PtPreenchimentoFacialRelacaoAplicacao, PtPreenchimentoFacialRelacaoAplicacaoVm>().ReverseMap();
    CreateMap<PtPreenchimentoFacialRelacaoEtiqueta, PtPreenchimentoFacialRelacaoEtiquetaVm>().ReverseMap();

    CreateMap<CadAgenda, CadAgendaVm>().ReverseMap();
  }
}