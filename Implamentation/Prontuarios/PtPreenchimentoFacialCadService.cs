using AutoMapper;
using Configuration;
using Domain.Prontuarios;
using Implementations.Base;
using Newtonsoft.Json;
using Services.Prontuarios;

namespace Implementations.Prontuarios
{
  public class PtPreenchimentoFacialCadService : BaseService<PtPreenchimentoFacial, PtPreenchimentoFacialCadVm>, IPtPreenchimentoFacialCadService
  {
    private readonly IMapper _mapper;
    private readonly IPtPreenchimentoFacialService _ptPreenchimentoFacialService;
    private readonly IPtPreenchimentoFacialRelacaoEtiquetaService _ptPreenchimentoFacialRelacaoEtiquetaService;
    private readonly IPtPreenchimentoFacialRelacaoAplicacaoService _ptPreenchimentoFacialRelacaoAplicacaoService;
    public PtPreenchimentoFacialCadService(AppDbContext context,
      IMapper mapper,
      IPtPreenchimentoFacialService ptPreenchimentoFacialService,
      IPtPreenchimentoFacialRelacaoEtiquetaService ptPreenchimentoFacialRelacaoEtiquetaService,
      IPtPreenchimentoFacialRelacaoAplicacaoService ptPreenchimentoFacialRelacaoAplicacaoService)
        : base(context, mapper)
    {
      _mapper = mapper;
      _ptPreenchimentoFacialService = ptPreenchimentoFacialService;
      _ptPreenchimentoFacialRelacaoEtiquetaService = ptPreenchimentoFacialRelacaoEtiquetaService;
      _ptPreenchimentoFacialRelacaoAplicacaoService = ptPreenchimentoFacialRelacaoAplicacaoService;
    }

    public override async Task<PtPreenchimentoFacialCadVm> GetByIdAsync(Guid id)
    {
      var pessoaVm = await _ptPreenchimentoFacialService.GetByIdAsync(id);
      var pessoaCadVm = MapperToCadVm(pessoaVm);

      var aplicacoes = await _ptPreenchimentoFacialRelacaoAplicacaoService.FindAsync(x => x.PreenchimentoFacialId == id);
      var etiquetas = await _ptPreenchimentoFacialRelacaoEtiquetaService.FindAsync(x => x.PreenchimentoFacialId == id);

      pessoaCadVm.Aplicacoes = aplicacoes.ToList();
      pessoaCadVm.Etiquetas = etiquetas.ToList();


      return pessoaCadVm;
    }

    private PtPreenchimentoFacialCadVm MapperToCadVm(PtPreenchimentoFacialVm modelCadVm)
    {
      if (modelCadVm == null) return null;

      var dado = new PtPreenchimentoFacialCadVm
      {
        Id = modelCadVm.Id,
        PessoaId = modelCadVm.PessoaId,
        PessoaNome = modelCadVm.PessoaNome,
        DataProcedimento = modelCadVm.DataProcedimento,
      };

      return dado;
    }

    public override async Task<PtPreenchimentoFacialCadVm> CreateAsync(PtPreenchimentoFacialCadVm cadVm)
    {
      var vm = MapperToVm(cadVm);
      await _ptPreenchimentoFacialService.CreateAsync(vm);

      await MapAplicacoes(cadVm, vm.Id);
      await MapEtiquetas(cadVm, vm.Id);


      return cadVm;
    }

    public override async Task<PtPreenchimentoFacialCadVm> UpdateAsync(PtPreenchimentoFacialCadVm cadVm)
    {
      var vm = MapperToVm(cadVm);
      await _ptPreenchimentoFacialService.UpdateAsync(vm);

      await MapAplicacoes(cadVm, vm.Id);
      await MapEtiquetas(cadVm, vm.Id);


      return cadVm;
    }

    private PtPreenchimentoFacialVm MapperToVm(PtPreenchimentoFacialCadVm cadVm)
    {
      if (cadVm == null) return null;

      var vm = new PtPreenchimentoFacialVm
      {
        Id = cadVm.Id,
        PessoaId = cadVm.PessoaId,
        PessoaNome = cadVm.PessoaNome,
        DataProcedimento = cadVm.DataProcedimento,
      };

      return vm;
    }

    private async Task<bool> MapAplicacoes(PtPreenchimentoFacialCadVm cadVm, Guid preenchimentoId)
    {
      // Remove todos os registros antigos
      await _ptPreenchimentoFacialRelacaoAplicacaoService
          .DeleteByPredicateAsync(c => c.PreenchimentoFacialId == preenchimentoId);

      if (string.IsNullOrWhiteSpace(cadVm?.AplicacoesJson))
        return true; // nada a salvar, mas operação concluída

      // Desserializa o JSON em lista tipada
      var aplicacoes = JsonConvert.DeserializeObject<List<PtPreenchimentoFacialRelacaoAplicacaoVm>>(cadVm.AplicacoesJson)
                       ?? new List<PtPreenchimentoFacialRelacaoAplicacaoVm>();

      foreach (var app in aplicacoes)
      {
        app.Id = Guid.NewGuid();
        app.PreenchimentoFacialId = preenchimentoId;
        await _ptPreenchimentoFacialRelacaoAplicacaoService.CreateAsync(app);
      }

      return true;
    }

    private async Task<bool> MapEtiquetas(PtPreenchimentoFacialCadVm cadVm, Guid preenchimentoId)
    {
      // Remove todos os registros antigos
      await _ptPreenchimentoFacialRelacaoEtiquetaService
          .DeleteByPredicateAsync(c => c.PreenchimentoFacialId == preenchimentoId);

      if (string.IsNullOrWhiteSpace(cadVm?.EtiquetasJson))
        return true; // nada a salvar, mas operação concluída

      // Desserializa o JSON em lista tipada
      var etiquetas = JsonConvert.DeserializeObject<List<PtPreenchimentoFacialRelacaoEtiquetaVm>>(cadVm.EtiquetasJson)
                      ?? new List<PtPreenchimentoFacialRelacaoEtiquetaVm>();

      foreach (var etq in etiquetas)
      {
        etq.Id = Guid.NewGuid();
        etq.PreenchimentoFacialId = preenchimentoId;
        await _ptPreenchimentoFacialRelacaoEtiquetaService.CreateAsync(etq);
      }

      return true;
    }

  }
}