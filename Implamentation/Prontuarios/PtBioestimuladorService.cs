using AutoMapper;
using Configuration;
using Domain.Prontuarios;
using Implementations.Base;
using Microsoft.EntityFrameworkCore;
using Services.Cadastro;
using Services.Prontuarios;

namespace Implementations.Prontuarios
{
  public class PtBioestimuladorService : BaseService<PtBioestimulador, PtBioestimuladorVm>, IPtBioestimuladorService
  {
    private readonly IMapper _mapper;
    private readonly IPessoaService _pessoaService;
    public PtBioestimuladorService(AppDbContext context, 
      IMapper mapper,
      IPessoaService pessoaService)
        : base(context, mapper)
    {
      _mapper = mapper;
      _pessoaService = pessoaService;
    }

    public override async Task<IEnumerable<PtBioestimuladorVm>> GetAllAsync()
    {
      var entities = await _context.Set<PtBioestimulador>().Include(c => c.CadPessoa)
        .Select(c => new PtBioestimuladorVm
        {
          Id = c.Id,
          PessoaId = c.PessoaId,
          PessoaNome = c.CadPessoa.Nome, 
          DataProcedimento = c.DataProcedimento,
          TratamentoFace = c.TratamentoFace,
          TratamentoCorpo = c.TratamentoCorpo,
          PdfAssinado = c.PdfAssinado,
        }).ToListAsync();

      return entities;
    }

    public override async Task<PtBioestimuladorVm> GetByIdAsync(Guid id)
    {
      var retorno = await _context.Set<PtBioestimulador>().Include(c => c.CadPessoa).Where(c => c.Id == id).FirstOrDefaultAsync();

      if (retorno == null) return null;

      var vm = new PtBioestimuladorVm
      {
        Id = retorno.Id,
        PessoaId = retorno.PessoaId,
        PessoaNome = retorno.CadPessoa?.Nome,
        DataProcedimento = retorno.DataProcedimento,      
        PdfAssinado = retorno.PdfAssinado,
        TratamentoFace = retorno.TratamentoFace,

        AnguloMandibulaRadiesseLidocaina = retorno.AnguloMandibulaRadiesseLidocaina,
        AnguloMandibulaRadiesseDuo = retorno.AnguloMandibulaRadiesseDuo,
        AnguloMandibulaDireita = retorno.AnguloMandibulaDireita,
        AnguloMandibulaEsquerda = retorno.AnguloMandibulaEsquerda,
        AnguloMandibulaQtdTotal = retorno.AnguloMandibulaQtdTotal,
        AnguloMandibulaDiluicao = retorno.AnguloMandibulaDiluicao,

        LinhaMandibularRadiesseLidocaina = retorno.LinhaMandibularRadiesseLidocaina,
        LinhaMandibularRadiesseDuo = retorno.LinhaMandibularRadiesseDuo,
        LinhaMandibularDireita = retorno.LinhaMandibularDireita,
        LinhaMandibularEsquerda = retorno.LinhaMandibularEsquerda,
        LinhaMandibularQtdTotal = retorno.LinhaMandibularQtdTotal,
        LinhaMandibularDiluicao = retorno.LinhaMandibularDiluicao,

        RegiaoMentonianaRadiesseLidocaina = retorno.RegiaoMentonianaRadiesseLidocaina,
        RegiaoMentonianaRadiesseDuo = retorno.RegiaoMentonianaRadiesseDuo,
        RegiaoMentonianaDireita = retorno.RegiaoMentonianaDireita,
        RegiaoMentonianaEsquerda = retorno.RegiaoMentonianaEsquerda,
        RegiaoMentonianaQtdTotal = retorno.RegiaoMentonianaQtdTotal,
        RegiaoMentonianaDiluicao = retorno.RegiaoMentonianaDiluicao,

        RegiaoSubmalarRadiesseLidocaina = retorno.RegiaoSubmalarRadiesseLidocaina,
        RegiaoSubmalarRadiesseDuo = retorno.RegiaoSubmalarRadiesseDuo,
        RegiaoSubmalarDireita = retorno.RegiaoSubmalarDireita,
        RegiaoSubmalarEsquerda = retorno.RegiaoSubmalarEsquerda,
        RegiaoSubmalarQtdTotal = retorno.RegiaoSubmalarQtdTotal,
        RegiaoSubmalarDiluicao = retorno.RegiaoSubmalarDiluicao,

        RegiaoTemporalRadiesseLidocaina = retorno.RegiaoTemporalRadiesseLidocaina,
        RegiaoTemporalRadiesseDuo = retorno.RegiaoTemporalRadiesseDuo,
        RegiaoTemporalDireita = retorno.RegiaoTemporalDireita,
        RegiaoTemporalEsquerda = retorno.RegiaoTemporalEsquerda,
        RegiaoTemporalQtdTotal = retorno.RegiaoTemporalQtdTotal,
        RegiaoTemporalDiluicao = retorno.RegiaoTemporalDiluicao,

        SulcoLabiomentualRadiesseLidocaina = retorno.SulcoLabiomentualRadiesseLidocaina,
        SulcoLabiomentualRadiesseDuo = retorno.SulcoLabiomentualRadiesseDuo,
        SulcoLabiomentualDireita = retorno.SulcoLabiomentualDireita,
        SulcoLabiomentualEsquerda = retorno.SulcoLabiomentualEsquerda,
        SulcoLabiomentualQtdTotal = retorno.SulcoLabiomentualQtdTotal,
        SulcoLabiomentualDiluicao = retorno.SulcoLabiomentualDiluicao,

        SulcoNasolabialRadiesseLidocaina = retorno.SulcoNasolabialRadiesseLidocaina,
        SulcoNasolabialRadiesseDuo = retorno.SulcoNasolabialRadiesseDuo,
        SulcoNasolabialDireita = retorno.SulcoNasolabialDireita,
        SulcoNasolabialEsquerda = retorno.SulcoNasolabialEsquerda,
        SulcoNasolabialQtdTotal = retorno.SulcoNasolabialQtdTotal,
        SulcoNasolabialDiluicao = retorno.SulcoNasolabialDiluicao,

        TratamentoCorpo = retorno.TratamentoCorpo,

        AbdomenRadiesseDuo = retorno.AbdomenRadiesseDuo,
        AbdomenDireita = retorno.AbdomenDireita,
        AbdomenEsquerda = retorno.AbdomenEsquerda,
        AbdomenQtdTotal = retorno.AbdomenQtdTotal,
        AbdomenDiluicao = retorno.AbdomenDiluicao,

        BracosRadiesseDuo = retorno.BracosRadiesseDuo,
        BracosDireita = retorno.BracosDireita,
        BracosEsquerda = retorno.BracosEsquerda,
        BracosQtdTotal = retorno.BracosQtdTotal,
        BracosDiluicao = retorno.BracosDiluicao,

        ColoRadiesseDuo = retorno.ColoRadiesseDuo,
        ColoDireita = retorno.ColoDireita,
        ColoEsquerda = retorno.ColoEsquerda,
        ColoQtdTotal = retorno.ColoQtdTotal,
        ColoDiluicao = retorno.ColoDiluicao,

        CotovelosRadiesseDuo = retorno.CotovelosRadiesseDuo,
        CotovelosDireita = retorno.CotovelosDireita,
        CotovelosEsquerda = retorno.CotovelosEsquerda,
        CotovelosQtdTotal = retorno.CotovelosQtdTotal,
        CotovelosDiluicao = retorno.CotovelosDiluicao,

        CoxasRadiesseDuo = retorno.CoxasRadiesseDuo,
        CoxasDireita = retorno.CoxasDireita,
        CoxasEsquerda = retorno.CoxasEsquerda,
        CoxasQtdTotal = retorno.CoxasQtdTotal,
        CoxasDiluicao = retorno.CoxasDiluicao,

        GluteosRadiesseDuo = retorno.GluteosRadiesseDuo,
        GluteosDireita = retorno.GluteosDireita,
        GluteosEsquerda = retorno.GluteosEsquerda,
        GluteosQtdTotal = retorno.GluteosQtdTotal,
        GluteosDiluicao = retorno.GluteosDiluicao,

        JoelhoRadiesseDuo = retorno.JoelhoRadiesseDuo,
        JoelhoDireita = retorno.JoelhoDireita,
        JoelhoEsquerda = retorno.JoelhoEsquerda,
        JoelhoQtdTotal = retorno.JoelhoQtdTotal,
        JoelhoDiluicao = retorno.JoelhoDiluicao,

        MaosRadiesseDuo = retorno.MaosRadiesseDuo,
        MaosDireita = retorno.MaosDireita,
        MaosEsquerda = retorno.MaosEsquerda,
        MaosQtdTotal = retorno.MaosQtdTotal,
        MaosDiluicao = retorno.MaosDiluicao,

        PescocoRadiesseDuo = retorno.PescocoRadiesseDuo,
        PescocoDireita = retorno.PescocoDireita,
        PescocoEsquerda = retorno.PescocoEsquerda,
        PescocoQtdTotal = retorno.PescocoQtdTotal,
        PescocoDiluicao = retorno.PescocoDiluicao

      };

      return vm;
    }

  }
}