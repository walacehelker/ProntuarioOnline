using AutoMapper;
using Configuration;
using Domain.Cadastro;
using Domain.Prontuarios;
using Implementations.Base;
using Services.Prontuarios;

namespace Implementations.Prontuarios
{
  public class PtBotoxCadService : BaseService<PtBotox, PtBotoxCadVm>, IPtBotoxCadService
  {
    private readonly IMapper _mapper;
    private readonly IPtBotoxService _ptBotoxService;
    public PtBotoxCadService(AppDbContext context,
      IMapper mapper,
      IPtBotoxService ptBotoxService)
        : base(context, mapper)
    {
      _mapper = mapper;
      _ptBotoxService = ptBotoxService;
    }

    public override async Task<PtBotoxCadVm> GetByIdAsync(Guid id)
    {
      var pessoaVm = await _ptBotoxService.GetByIdAsync(id);
      var pessoaCadVm = MapperToCadVm(pessoaVm);

      return pessoaCadVm;
    }

    private PtBotoxCadVm MapperToCadVm(PtBotoxVm modelCadVm)
    {
      if (modelCadVm == null) return null;

      var dado = new PtBotoxCadVm
      {
        Id = modelCadVm.Id,
        PessoaId = modelCadVm.PessoaId,
        PessoaNome = modelCadVm.PessoaNome,
        DataProcedimento = modelCadVm.DataProcedimento,
        MarcaProduto = modelCadVm.MarcaProduto,
        DataDiluicao = modelCadVm.DataDiluicao,
        VolumeDiluicao = modelCadVm.VolumeDiluicao,
        NumeroLote = modelCadVm.NumeroLote,
        DataValidade = modelCadVm.DataValidade,

        // Pontos de aplicação
        Frontal = modelCadVm.Frontal,
        Procero = modelCadVm.Procero,
        Nasal = modelCadVm.Nasal,
        DepressorSeptoNasal = modelCadVm.DepressorSeptoNasal,
        OrbicularBoca = modelCadVm.OrbicularBoca,
        DepressorAnguloBocaDireito = modelCadVm.DepressorAnguloBocaDireito,
        DepressorAnguloBocaEsquerdo = modelCadVm.DepressorAnguloBocaEsquerdo,
        CorrugadorDireito = modelCadVm.CorrugadorDireito,
        CorrugadorEsquerdo = modelCadVm.CorrugadorEsquerdo,
        LevantadorLabioSuperiorDireito = modelCadVm.LevantadorLabioSuperiorDireito,
        LevantadorLabioSuperiorEsquerdo = modelCadVm.LevantadorLabioSuperiorEsquerdo,
        LLabioSupAsaNarizDireito = modelCadVm.LLabioSupAsaNarizDireito,
        LLabioSupAsaNarizEsquerdo = modelCadVm.LLabioSupAsaNarizEsquerdo,
        RisorioDireito = modelCadVm.RisorioDireito,
        RisorioEsquerdo = modelCadVm.RisorioEsquerdo,
        ZigomaticoMaiorDireito = modelCadVm.ZigomaticoMaiorDireito,
        ZigomaticoMaiorEsquerdo = modelCadVm.ZigomaticoMaiorEsquerdo,
        ZigomaticoMenorDireito = modelCadVm.ZigomaticoMenorDireito,
        ZigomaticoMenorEsquerdo = modelCadVm.ZigomaticoMenorEsquerdo,
        OrbicularOlhoDireito = modelCadVm.OrbicularOlhoDireito,
        OrbicularOlhoEsquerdo = modelCadVm.OrbicularOlhoEsquerdo,
        MentonianoDireito = modelCadVm.MentonianoDireito,
        MentonianoEsquerdo = modelCadVm.MentonianoEsquerdo,
        PlatismaDireito = modelCadVm.PlatismaDireito,
        PlatismaEsquerdo = modelCadVm.PlatismaEsquerdo,
        DepressorLabioInferiorDireito = modelCadVm.DepressorLabioInferiorDireito,
        DepressorLabioInferiorEsquerdo = modelCadVm.DepressorLabioInferiorEsquerdo,
        MassesterDireito = modelCadVm.MassesterDireito,
        MassesterEsquerdo = modelCadVm.MassesterEsquerdo,
        TotalUtilizado = modelCadVm.TotalUtilizado,
        PdfAssinado = modelCadVm.PdfAssinado,
        Observacoes = modelCadVm.Observacoes,
        AceitaDivulgacao = modelCadVm.AceitaDivulgacao,
        DataAssinatura = modelCadVm.DataAssinatura
      };

      return dado;
    }

    public override async Task<PtBotoxCadVm> CreateAsync(PtBotoxCadVm cadVm)
    {
      var vm = MapperToVm(cadVm);
      await _ptBotoxService.CreateAsync(vm);

      return cadVm;
    }

    public override async Task<PtBotoxCadVm> UpdateAsync(PtBotoxCadVm cadVm)
    {
      var vm = MapperToVm(cadVm);
      await _ptBotoxService.UpdateAsync(vm);

      return cadVm;
    }

    private PtBotoxVm MapperToVm(PtBotoxCadVm cadVm)
    {
      if (cadVm == null) return null;

      var vm = new PtBotoxVm
      {
        Id = cadVm.Id,
        PessoaId = cadVm.PessoaId,
        PessoaNome = cadVm.PessoaNome,
        DataProcedimento = cadVm.DataProcedimento,
        MarcaProduto = cadVm.MarcaProduto,
        DataDiluicao = cadVm.DataDiluicao,
        VolumeDiluicao = cadVm.VolumeDiluicao,
        NumeroLote = cadVm.NumeroLote,
        DataValidade = cadVm.DataValidade,

        // Pontos de aplicação
        Frontal = cadVm.Frontal,
        Procero = cadVm.Procero,
        Nasal = cadVm.Nasal,
        DepressorSeptoNasal = cadVm.DepressorSeptoNasal,
        OrbicularBoca = cadVm.OrbicularBoca,
        DepressorAnguloBocaDireito = cadVm.DepressorAnguloBocaDireito,
        DepressorAnguloBocaEsquerdo = cadVm.DepressorAnguloBocaEsquerdo,
        CorrugadorDireito = cadVm.CorrugadorDireito,
        CorrugadorEsquerdo = cadVm.CorrugadorEsquerdo,
        LevantadorLabioSuperiorDireito = cadVm.LevantadorLabioSuperiorDireito,
        LevantadorLabioSuperiorEsquerdo = cadVm.LevantadorLabioSuperiorEsquerdo,
        LLabioSupAsaNarizDireito = cadVm.LLabioSupAsaNarizDireito,
        LLabioSupAsaNarizEsquerdo = cadVm.LLabioSupAsaNarizEsquerdo,
        RisorioDireito = cadVm.RisorioDireito,
        RisorioEsquerdo = cadVm.RisorioEsquerdo,
        ZigomaticoMaiorDireito = cadVm.ZigomaticoMaiorDireito,
        ZigomaticoMaiorEsquerdo = cadVm.ZigomaticoMaiorEsquerdo,
        ZigomaticoMenorDireito = cadVm.ZigomaticoMenorDireito,
        ZigomaticoMenorEsquerdo = cadVm.ZigomaticoMenorEsquerdo,
        OrbicularOlhoDireito = cadVm.OrbicularOlhoDireito,
        OrbicularOlhoEsquerdo = cadVm.OrbicularOlhoEsquerdo,
        MentonianoDireito = cadVm.MentonianoDireito,
        MentonianoEsquerdo = cadVm.MentonianoEsquerdo,
        PlatismaDireito = cadVm.PlatismaDireito,
        PlatismaEsquerdo = cadVm.PlatismaEsquerdo,
        DepressorLabioInferiorDireito = cadVm.DepressorLabioInferiorDireito,
        DepressorLabioInferiorEsquerdo = cadVm.DepressorLabioInferiorEsquerdo,
        MassesterDireito = cadVm.MassesterDireito,
        MassesterEsquerdo = cadVm.MassesterEsquerdo,
        TotalUtilizado = cadVm.TotalUtilizado,
        PdfAssinado = cadVm.PdfAssinado,
        Observacoes = cadVm.Observacoes,
        AceitaDivulgacao = cadVm.AceitaDivulgacao,
        DataAssinatura = cadVm.DataAssinatura,
      };

      return vm;
    }
  }
}