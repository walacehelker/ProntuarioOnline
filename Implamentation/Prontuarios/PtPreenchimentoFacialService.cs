using AutoMapper;
using Configuration;
using Domain.Prontuarios;
using Implementations.Base;
using Microsoft.EntityFrameworkCore;
using Services.Cadastro;
using Services.Prontuarios;

namespace Implementations.Prontuarios
{
  public class PtPreenchimentoFacialService : BaseService<PtPreenchimentoFacial, PtPreenchimentoFacialVm>, IPtPreenchimentoFacialService
  {
    private readonly IMapper _mapper;
    private readonly IPessoaService _pessoaService;
    public PtPreenchimentoFacialService(AppDbContext context, 
      IMapper mapper,
      IPessoaService pessoaService)
        : base(context, mapper)
    {
      _mapper = mapper;
      _pessoaService = pessoaService;
    }

    public override async Task<IEnumerable<PtPreenchimentoFacialVm>> GetAllAsync()
    {
      var entities = await _context.Set<PtPreenchimentoFacial>().Include(c => c.CadPessoa)
        .Select(c => new PtPreenchimentoFacialVm
        {
          Id = c.Id,
          PessoaId = c.PessoaId,
          PessoaNome = c.CadPessoa.Nome, 
          DataProcedimento = c.DataProcedimento,
          AssinaturaTermoConsentimento = c.AssinaturaTermoConsentimento,
          DataAssinatura = c.DataAssinatura,
        }).ToListAsync();

      return entities;
    }

    public override async Task<PtPreenchimentoFacialVm> GetByIdAsync(Guid id)
    {
      var retorno = await _context.Set<PtPreenchimentoFacial>().Include(c => c.CadPessoa).Where(c => c.Id == id).FirstOrDefaultAsync();

      if (retorno == null) return null;

      var vm = new PtPreenchimentoFacialVm
      {
        Id = retorno.Id,
        PessoaId = retorno.PessoaId,
        PessoaNome = retorno.CadPessoa?.Nome,
        DataProcedimento = retorno.DataProcedimento,   
        AssinaturaTermoConsentimento = retorno.AssinaturaTermoConsentimento,
        Observacoes = retorno.Observacoes,
        DataAssinatura = retorno.DataAssinatura,
      };

      return vm;
    }

  }
}