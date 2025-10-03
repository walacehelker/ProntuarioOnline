using AutoMapper;
using Configuration;
using Domain.Prontuarios;
using Implementations.Base;
using Microsoft.EntityFrameworkCore;
using Services.Cadastro;
using Services.Prontuarios;

namespace Implementations.Prontuarios
{
  public class PtBotoxService : BaseService<PtBotox, PtBotoxVm>, IPtBotoxService
  {
    private readonly IMapper _mapper;
    private readonly IPessoaService _pessoaService;
    public PtBotoxService(AppDbContext context, 
      IMapper mapper,
      IPessoaService pessoaService)
        : base(context, mapper)
    {
      _mapper = mapper;
      _pessoaService = pessoaService;
    }

    public override async Task<IEnumerable<PtBotoxVm>> GetAllAsync()
    {
      var entities = await _context.Set<PtBotox>().Include(c => c.CadPessoa)
        .Select(c => new PtBotoxVm
        {
          Id = c.Id,
          PessoaId = c.PessoaId,
          PessoaNome = c.CadPessoa.Nome, 
          DataProcedimento = c.DataProcedimento,
          MarcaProduto = c.MarcaProduto,
          DataDiluicao = c.DataDiluicao,
          VolumeDiluicao = c.VolumeDiluicao,
          NumeroLote = c.NumeroLote,
          DataValidade = c.DataValidade,
          PdfAssinado = c.PdfAssinado,
          DataAssinatura = c.DataAssinatura,
        }).ToListAsync();

      return entities;
    }

    public override async Task<PtBotoxVm> GetByIdAsync(Guid id)
    {
      var retorno = await _context.Set<PtBotox>().Include(c => c.CadPessoa).Where(c => c.Id == id).FirstOrDefaultAsync();

      if (retorno == null) return null;

      var vm = new PtBotoxVm
      {
        Id = retorno.Id,
        PessoaId = retorno.PessoaId,
        PessoaNome = retorno.CadPessoa?.Nome,
        DataProcedimento = retorno.DataProcedimento,
        MarcaProduto = retorno.MarcaProduto,
        DataDiluicao = retorno.DataDiluicao,
        VolumeDiluicao = retorno.VolumeDiluicao,
        NumeroLote = retorno.NumeroLote,
        DataValidade = retorno.DataValidade,

        // Pontos de aplicação
        Frontal = retorno.Frontal,
        Procero = retorno.Procero,
        Nasal = retorno.Nasal,
        DepressorSeptoNasal = retorno.DepressorSeptoNasal,
        OrbicularBoca = retorno.OrbicularBoca,
        DepressorAnguloBocaDireito = retorno.DepressorAnguloBocaDireito,
        DepressorAnguloBocaEsquerdo = retorno.DepressorAnguloBocaEsquerdo,
        CorrugadorDireito = retorno.CorrugadorDireito,
        CorrugadorEsquerdo = retorno.CorrugadorEsquerdo,
        LevantadorLabioSuperiorDireito = retorno.LevantadorLabioSuperiorDireito,
        LevantadorLabioSuperiorEsquerdo = retorno.LevantadorLabioSuperiorEsquerdo,
        LLabioSupAsaNarizDireito = retorno.LLabioSupAsaNarizDireito,
        LLabioSupAsaNarizEsquerdo = retorno.LLabioSupAsaNarizEsquerdo,
        RisorioDireito = retorno.RisorioDireito,
        RisorioEsquerdo = retorno.RisorioEsquerdo,
        ZigomaticoMaiorDireito = retorno.ZigomaticoMaiorDireito,
        ZigomaticoMaiorEsquerdo = retorno.ZigomaticoMaiorEsquerdo,
        ZigomaticoMenorDireito = retorno.ZigomaticoMenorDireito,
        ZigomaticoMenorEsquerdo = retorno.ZigomaticoMenorEsquerdo,
        OrbicularOlhoDireito = retorno.OrbicularOlhoDireito,
        OrbicularOlhoEsquerdo = retorno.OrbicularOlhoEsquerdo,
        MentonianoDireito = retorno.MentonianoDireito,
        MentonianoEsquerdo = retorno.MentonianoEsquerdo,
        PlatismaDireito = retorno.PlatismaDireito,
        PlatismaEsquerdo = retorno.PlatismaEsquerdo,
        DepressorLabioInferiorDireito = retorno.DepressorLabioInferiorDireito,
        DepressorLabioInferiorEsquerdo = retorno.DepressorLabioInferiorEsquerdo,
        MassesterDireito = retorno.MassesterDireito,
        MassesterEsquerdo = retorno.MassesterEsquerdo,
        TotalUtilizado = retorno.TotalUtilizado,
        Observacoes = retorno.Observacoes,
        AceitaDivulgacao = retorno.AceitaDivulgacao,
        PdfAssinado = retorno.PdfAssinado,
        DataAssinatura = retorno.DataAssinatura,
      };

      return vm;
    }

  }
}