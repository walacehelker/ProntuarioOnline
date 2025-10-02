using AutoMapper;
using Configuration;
using Domain.Prontuarios;
using Implementations.Base;
using Microsoft.EntityFrameworkCore;
using Services.Cadastro;
using Services.Prontuarios;

namespace Implementations.Prontuarios
{
  public class PtPreenchimentoFacialRelacaoEtiquetaService : BaseService<PtPreenchimentoFacialRelacaoEtiqueta, PtPreenchimentoFacialRelacaoEtiquetaVm>, IPtPreenchimentoFacialRelacaoEtiquetaService
  {
    private readonly IMapper _mapper;
    private readonly IPessoaService _pessoaService;
    public PtPreenchimentoFacialRelacaoEtiquetaService(AppDbContext context, 
      IMapper mapper,
      IPessoaService pessoaService)
        : base(context, mapper)
    {
      _mapper = mapper;
      _pessoaService = pessoaService;
    }   

  }
}