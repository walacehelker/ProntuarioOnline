using AutoMapper;
using Domain.Cadastro;
using Implementations.Base;
using Configuration;
using Services.Cadastro;
using Models.Cadastro;

namespace Implementations.Cadastro
{
  public class AgendaCadService : BaseService<CadAgenda, CadAgendaCadVm>, IAgendaCadService
  {
    private readonly IAgendaService _AgendaService;
    private readonly IMapper _mapper;
    public AgendaCadService(AppDbContext context, 
      IMapper mapper,
      IAgendaService AgendaService)
        : base(context, mapper)
    {
      _mapper = mapper;
      _AgendaService = AgendaService;
    }


    public override async Task<CadAgendaCadVm> GetByIdAsync(Guid id)
    {
      var AgendaVm = await _AgendaService.GetByIdAsync(id);
      var AgendaCadVm = MapperToCadVm(AgendaVm);


      return AgendaCadVm;
    }

    private CadAgendaCadVm MapperToCadVm(CadAgendaVm modelCadVm)
    {
      if (modelCadVm == null) return null;


      var dado = new CadAgendaCadVm
      {
        Id = modelCadVm.Id,
        Nome = modelCadVm.Nome,
        Data = modelCadVm.Data,
        ProcedimentoAgendado = modelCadVm.ProcedimentoAgendado,
        Telefone = modelCadVm.Telefone,
      };

      return dado;
    }

    private CadAgendaVm MapperToVm(CadAgendaCadVm modelCadVm)
    {
      if (modelCadVm == null) return null;


      var dado = new CadAgendaVm
      {
        Id = modelCadVm.Id,
        Nome = modelCadVm.Nome,
        Data = modelCadVm.Data,
        ProcedimentoAgendado = modelCadVm.ProcedimentoAgendado,
        Telefone = modelCadVm.Telefone,
      };

      return dado;
    }

    public override async Task<CadAgendaCadVm> CreateAsync(CadAgendaCadVm model)
    {
      var modelVm = MapperToVm(model);
      var createdVm = await _AgendaService.CreateAsync(modelVm);
      var createdCadVm = MapperToCadVm(createdVm);
      return createdCadVm;
    }

    public override async Task<CadAgendaCadVm> UpdateAsync(CadAgendaCadVm model)
    {
      var modelVm = MapperToVm(model);
      var updatedVm = await _AgendaService.UpdateAsync(modelVm);
      var updatedCadVm = MapperToCadVm(updatedVm);
      return updatedCadVm;
    }

  }
}