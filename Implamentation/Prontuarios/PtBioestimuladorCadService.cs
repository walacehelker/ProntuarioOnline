using AutoMapper;
using Configuration;
using Domain.Cadastro;
using Domain.Prontuarios;
using Implementations.Base;
using Services.Prontuarios;

namespace Implementations.Prontuarios
{
  public class PtBioestimuladorCadService : BaseService<PtBioestimulador, PtBioestimuladorCadVm>, IPtBioestimuladorCadService
  {
    private readonly IMapper _mapper;
    private readonly IPtBioestimuladorService _ptBioestimuladorService;
    public PtBioestimuladorCadService(AppDbContext context,
      IMapper mapper,
      IPtBioestimuladorService ptBioestimuladorService)
        : base(context, mapper)
    {
      _mapper = mapper;
      _ptBioestimuladorService = ptBioestimuladorService;
    }

    public override async Task<PtBioestimuladorCadVm> GetByIdAsync(Guid id)
    {
      var pessoaVm = await _ptBioestimuladorService.GetByIdAsync(id);
      var pessoaCadVm = MapperToCadVm(pessoaVm);

      return pessoaCadVm;
    }

    private PtBioestimuladorCadVm MapperToCadVm(PtBioestimuladorVm modelCadVm)
    {
      if (modelCadVm == null) return null;

      var dado = new PtBioestimuladorCadVm
      {
        Id = modelCadVm.Id,
        PessoaId = modelCadVm.PessoaId,
        PessoaNome = modelCadVm.PessoaNome,
        DataProcedimento = modelCadVm.DataProcedimento,
        PdfAssinado = modelCadVm.PdfAssinado,
        TratamentoFace = modelCadVm.TratamentoFace,

        AnguloMandibulaRadiesseLidocaina = modelCadVm.AnguloMandibulaRadiesseLidocaina,
        AnguloMandibulaRadiesseDuo = modelCadVm.AnguloMandibulaRadiesseDuo,
        AnguloMandibulaDireita = modelCadVm.AnguloMandibulaDireita,
        AnguloMandibulaEsquerda = modelCadVm.AnguloMandibulaEsquerda,
        AnguloMandibulaQtdTotal = modelCadVm.AnguloMandibulaQtdTotal,
        AnguloMandibulaDiluicao = modelCadVm.AnguloMandibulaDiluicao,

        LinhaMandibularRadiesseLidocaina = modelCadVm.LinhaMandibularRadiesseLidocaina,
        LinhaMandibularRadiesseDuo = modelCadVm.LinhaMandibularRadiesseDuo,
        LinhaMandibularDireita = modelCadVm.LinhaMandibularDireita,
        LinhaMandibularEsquerda = modelCadVm.LinhaMandibularEsquerda,
        LinhaMandibularQtdTotal = modelCadVm.LinhaMandibularQtdTotal,
        LinhaMandibularDiluicao = modelCadVm.LinhaMandibularDiluicao,

        RegiaoMentonianaRadiesseLidocaina = modelCadVm.RegiaoMentonianaRadiesseLidocaina,
        RegiaoMentonianaRadiesseDuo = modelCadVm.RegiaoMentonianaRadiesseDuo,
        RegiaoMentonianaDireita = modelCadVm.RegiaoMentonianaDireita,
        RegiaoMentonianaEsquerda = modelCadVm.RegiaoMentonianaEsquerda,
        RegiaoMentonianaQtdTotal = modelCadVm.RegiaoMentonianaQtdTotal,
        RegiaoMentonianaDiluicao = modelCadVm.RegiaoMentonianaDiluicao,

        RegiaoSubmalarRadiesseLidocaina = modelCadVm.RegiaoSubmalarRadiesseLidocaina,
        RegiaoSubmalarRadiesseDuo = modelCadVm.RegiaoSubmalarRadiesseDuo,
        RegiaoSubmalarDireita = modelCadVm.RegiaoSubmalarDireita,
        RegiaoSubmalarEsquerda = modelCadVm.RegiaoSubmalarEsquerda,
        RegiaoSubmalarQtdTotal = modelCadVm.RegiaoSubmalarQtdTotal,
        RegiaoSubmalarDiluicao = modelCadVm.RegiaoSubmalarDiluicao,

        RegiaoTemporalRadiesseLidocaina = modelCadVm.RegiaoTemporalRadiesseLidocaina,
        RegiaoTemporalRadiesseDuo = modelCadVm.RegiaoTemporalRadiesseDuo,
        RegiaoTemporalDireita = modelCadVm.RegiaoTemporalDireita,
        RegiaoTemporalEsquerda = modelCadVm.RegiaoTemporalEsquerda,
        RegiaoTemporalQtdTotal = modelCadVm.RegiaoTemporalQtdTotal,
        RegiaoTemporalDiluicao = modelCadVm.RegiaoTemporalDiluicao,

        SulcoLabiomentualRadiesseLidocaina = modelCadVm.SulcoLabiomentualRadiesseLidocaina,
        SulcoLabiomentualRadiesseDuo = modelCadVm.SulcoLabiomentualRadiesseDuo,
        SulcoLabiomentualDireita = modelCadVm.SulcoLabiomentualDireita,
        SulcoLabiomentualEsquerda = modelCadVm.SulcoLabiomentualEsquerda,
        SulcoLabiomentualQtdTotal = modelCadVm.SulcoLabiomentualQtdTotal,
        SulcoLabiomentualDiluicao = modelCadVm.SulcoLabiomentualDiluicao,

        SulcoNasolabialRadiesseLidocaina = modelCadVm.SulcoNasolabialRadiesseLidocaina,
        SulcoNasolabialRadiesseDuo = modelCadVm.SulcoNasolabialRadiesseDuo,
        SulcoNasolabialDireita = modelCadVm.SulcoNasolabialDireita,
        SulcoNasolabialEsquerda = modelCadVm.SulcoNasolabialEsquerda,
        SulcoNasolabialQtdTotal = modelCadVm.SulcoNasolabialQtdTotal,
        SulcoNasolabialDiluicao = modelCadVm.SulcoNasolabialDiluicao,

        TratamentoCorpo = modelCadVm.TratamentoCorpo,

        AbdomenRadiesseDuo = modelCadVm.AbdomenRadiesseDuo,
        AbdomenDireita = modelCadVm.AbdomenDireita,
        AbdomenEsquerda = modelCadVm.AbdomenEsquerda,
        AbdomenQtdTotal = modelCadVm.AbdomenQtdTotal,
        AbdomenDiluicao = modelCadVm.AbdomenDiluicao,

        BracosRadiesseDuo = modelCadVm.BracosRadiesseDuo,
        BracosDireita = modelCadVm.BracosDireita,
        BracosEsquerda = modelCadVm.BracosEsquerda,
        BracosQtdTotal = modelCadVm.BracosQtdTotal,
        BracosDiluicao = modelCadVm.BracosDiluicao,

        ColoRadiesseDuo = modelCadVm.ColoRadiesseDuo,
        ColoDireita = modelCadVm.ColoDireita,
        ColoEsquerda = modelCadVm.ColoEsquerda,
        ColoQtdTotal = modelCadVm.ColoQtdTotal,
        ColoDiluicao = modelCadVm.ColoDiluicao,

        CotovelosRadiesseDuo = modelCadVm.CotovelosRadiesseDuo,
        CotovelosDireita = modelCadVm.CotovelosDireita,
        CotovelosEsquerda = modelCadVm.CotovelosEsquerda,
        CotovelosQtdTotal = modelCadVm.CotovelosQtdTotal,
        CotovelosDiluicao = modelCadVm.CotovelosDiluicao,

        CoxasRadiesseDuo = modelCadVm.CoxasRadiesseDuo,
        CoxasDireita = modelCadVm.CoxasDireita,
        CoxasEsquerda = modelCadVm.CoxasEsquerda,
        CoxasQtdTotal = modelCadVm.CoxasQtdTotal,
        CoxasDiluicao = modelCadVm.CoxasDiluicao,

        GluteosRadiesseDuo = modelCadVm.GluteosRadiesseDuo,
        GluteosDireita = modelCadVm.GluteosDireita,
        GluteosEsquerda = modelCadVm.GluteosEsquerda,
        GluteosQtdTotal = modelCadVm.GluteosQtdTotal,
        GluteosDiluicao = modelCadVm.GluteosDiluicao,

        JoelhoRadiesseDuo = modelCadVm.JoelhoRadiesseDuo,
        JoelhoDireita = modelCadVm.JoelhoDireita,
        JoelhoEsquerda = modelCadVm.JoelhoEsquerda,
        JoelhoQtdTotal = modelCadVm.JoelhoQtdTotal,
        JoelhoDiluicao = modelCadVm.JoelhoDiluicao,

        MaosRadiesseDuo = modelCadVm.MaosRadiesseDuo,
        MaosDireita = modelCadVm.MaosDireita,
        MaosEsquerda = modelCadVm.MaosEsquerda,
        MaosQtdTotal = modelCadVm.MaosQtdTotal,
        MaosDiluicao = modelCadVm.MaosDiluicao,

        PescocoRadiesseDuo = modelCadVm.PescocoRadiesseDuo,
        PescocoDireita = modelCadVm.PescocoDireita,
        PescocoEsquerda = modelCadVm.PescocoEsquerda,
        PescocoQtdTotal = modelCadVm.PescocoQtdTotal,
        PescocoDiluicao = modelCadVm.PescocoDiluicao

      };

      return dado;
    }

    public override async Task<PtBioestimuladorCadVm> CreateAsync(PtBioestimuladorCadVm cadVm)
    {
      var vm = MapperToVm(cadVm);
      await _ptBioestimuladorService.CreateAsync(vm);

      return cadVm;
    }

    public override async Task<PtBioestimuladorCadVm> UpdateAsync(PtBioestimuladorCadVm cadVm)
    {
      var vm = MapperToVm(cadVm);
      await _ptBioestimuladorService.UpdateAsync(vm);

      return cadVm;
    }

    private PtBioestimuladorVm MapperToVm(PtBioestimuladorCadVm cadVm)
    {
      if (cadVm == null) return null;

      var vm = new PtBioestimuladorVm
      {
        Id = cadVm.Id,
        PessoaId = cadVm.PessoaId,
        PessoaNome = cadVm.PessoaNome,
        DataProcedimento = cadVm.DataProcedimento,
        PdfAssinado = cadVm.PdfAssinado,
        TratamentoFace = cadVm.TratamentoFace,

        AnguloMandibulaRadiesseLidocaina = cadVm.AnguloMandibulaRadiesseLidocaina,
        AnguloMandibulaRadiesseDuo = cadVm.AnguloMandibulaRadiesseDuo,
        AnguloMandibulaDireita = cadVm.AnguloMandibulaDireita,
        AnguloMandibulaEsquerda = cadVm.AnguloMandibulaEsquerda,
        AnguloMandibulaQtdTotal = cadVm.AnguloMandibulaQtdTotal,
        AnguloMandibulaDiluicao = cadVm.AnguloMandibulaDiluicao,

        LinhaMandibularRadiesseLidocaina = cadVm.LinhaMandibularRadiesseLidocaina,
        LinhaMandibularRadiesseDuo = cadVm.LinhaMandibularRadiesseDuo,
        LinhaMandibularDireita = cadVm.LinhaMandibularDireita,
        LinhaMandibularEsquerda = cadVm.LinhaMandibularEsquerda,
        LinhaMandibularQtdTotal = cadVm.LinhaMandibularQtdTotal,
        LinhaMandibularDiluicao = cadVm.LinhaMandibularDiluicao,

        RegiaoMentonianaRadiesseLidocaina = cadVm.RegiaoMentonianaRadiesseLidocaina,
        RegiaoMentonianaRadiesseDuo = cadVm.RegiaoMentonianaRadiesseDuo,
        RegiaoMentonianaDireita = cadVm.RegiaoMentonianaDireita,
        RegiaoMentonianaEsquerda = cadVm.RegiaoMentonianaEsquerda,
        RegiaoMentonianaQtdTotal = cadVm.RegiaoMentonianaQtdTotal,
        RegiaoMentonianaDiluicao = cadVm.RegiaoMentonianaDiluicao,

        RegiaoSubmalarRadiesseLidocaina = cadVm.RegiaoSubmalarRadiesseLidocaina,
        RegiaoSubmalarRadiesseDuo = cadVm.RegiaoSubmalarRadiesseDuo,
        RegiaoSubmalarDireita = cadVm.RegiaoSubmalarDireita,
        RegiaoSubmalarEsquerda = cadVm.RegiaoSubmalarEsquerda,
        RegiaoSubmalarQtdTotal = cadVm.RegiaoSubmalarQtdTotal,
        RegiaoSubmalarDiluicao = cadVm.RegiaoSubmalarDiluicao,

        RegiaoTemporalRadiesseLidocaina = cadVm.RegiaoTemporalRadiesseLidocaina,
        RegiaoTemporalRadiesseDuo = cadVm.RegiaoTemporalRadiesseDuo,
        RegiaoTemporalDireita = cadVm.RegiaoTemporalDireita,
        RegiaoTemporalEsquerda = cadVm.RegiaoTemporalEsquerda,
        RegiaoTemporalQtdTotal = cadVm.RegiaoTemporalQtdTotal,
        RegiaoTemporalDiluicao = cadVm.RegiaoTemporalDiluicao,

        SulcoLabiomentualRadiesseLidocaina = cadVm.SulcoLabiomentualRadiesseLidocaina,
        SulcoLabiomentualRadiesseDuo = cadVm.SulcoLabiomentualRadiesseDuo,
        SulcoLabiomentualDireita = cadVm.SulcoLabiomentualDireita,
        SulcoLabiomentualEsquerda = cadVm.SulcoLabiomentualEsquerda,
        SulcoLabiomentualQtdTotal = cadVm.SulcoLabiomentualQtdTotal,
        SulcoLabiomentualDiluicao = cadVm.SulcoLabiomentualDiluicao,

        SulcoNasolabialRadiesseLidocaina = cadVm.SulcoNasolabialRadiesseLidocaina,
        SulcoNasolabialRadiesseDuo = cadVm.SulcoNasolabialRadiesseDuo,
        SulcoNasolabialDireita = cadVm.SulcoNasolabialDireita,
        SulcoNasolabialEsquerda = cadVm.SulcoNasolabialEsquerda,
        SulcoNasolabialQtdTotal = cadVm.SulcoNasolabialQtdTotal,
        SulcoNasolabialDiluicao = cadVm.SulcoNasolabialDiluicao,

        TratamentoCorpo = cadVm.TratamentoCorpo,

        AbdomenRadiesseDuo = cadVm.AbdomenRadiesseDuo,
        AbdomenDireita = cadVm.AbdomenDireita,
        AbdomenEsquerda = cadVm.AbdomenEsquerda,
        AbdomenQtdTotal = cadVm.AbdomenQtdTotal,
        AbdomenDiluicao = cadVm.AbdomenDiluicao,

        BracosRadiesseDuo = cadVm.BracosRadiesseDuo,
        BracosDireita = cadVm.BracosDireita,
        BracosEsquerda = cadVm.BracosEsquerda,
        BracosQtdTotal = cadVm.BracosQtdTotal,
        BracosDiluicao = cadVm.BracosDiluicao,

        ColoRadiesseDuo = cadVm.ColoRadiesseDuo,
        ColoDireita = cadVm.ColoDireita,
        ColoEsquerda = cadVm.ColoEsquerda,
        ColoQtdTotal = cadVm.ColoQtdTotal,
        ColoDiluicao = cadVm.ColoDiluicao,

        CotovelosRadiesseDuo = cadVm.CotovelosRadiesseDuo,
        CotovelosDireita = cadVm.CotovelosDireita,
        CotovelosEsquerda = cadVm.CotovelosEsquerda,
        CotovelosQtdTotal = cadVm.CotovelosQtdTotal,
        CotovelosDiluicao = cadVm.CotovelosDiluicao,

        CoxasRadiesseDuo = cadVm.CoxasRadiesseDuo,
        CoxasDireita = cadVm.CoxasDireita,
        CoxasEsquerda = cadVm.CoxasEsquerda,
        CoxasQtdTotal = cadVm.CoxasQtdTotal,
        CoxasDiluicao = cadVm.CoxasDiluicao,

        GluteosRadiesseDuo = cadVm.GluteosRadiesseDuo,
        GluteosDireita = cadVm.GluteosDireita,
        GluteosEsquerda = cadVm.GluteosEsquerda,
        GluteosQtdTotal = cadVm.GluteosQtdTotal,
        GluteosDiluicao = cadVm.GluteosDiluicao,

        JoelhoRadiesseDuo = cadVm.JoelhoRadiesseDuo,
        JoelhoDireita = cadVm.JoelhoDireita,
        JoelhoEsquerda = cadVm.JoelhoEsquerda,
        JoelhoQtdTotal = cadVm.JoelhoQtdTotal,
        JoelhoDiluicao = cadVm.JoelhoDiluicao,

        MaosRadiesseDuo = cadVm.MaosRadiesseDuo,
        MaosDireita = cadVm.MaosDireita,
        MaosEsquerda = cadVm.MaosEsquerda,
        MaosQtdTotal = cadVm.MaosQtdTotal,
        MaosDiluicao = cadVm.MaosDiluicao,

        PescocoRadiesseDuo = cadVm.PescocoRadiesseDuo,
        PescocoDireita = cadVm.PescocoDireita,
        PescocoEsquerda = cadVm.PescocoEsquerda,
        PescocoQtdTotal = cadVm.PescocoQtdTotal,
        PescocoDiluicao = cadVm.PescocoDiluicao
      };

      return vm;
    }
  }
}