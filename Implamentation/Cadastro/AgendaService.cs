using AutoMapper;
using Domain.Cadastro;
using Implementations.Base;
using Configuration;
using Services.Cadastro;
using Models.Cadastro;

namespace Implementations.Cadastro
{
  public class AgendaService : BaseService<CadAgenda, CadAgendaVm>, IAgendaService
  {
    private readonly IMapper _mapper;
    public AgendaService(AppDbContext context, 
      IMapper mapper)
        : base(context, mapper)
    {
      _mapper = mapper;
    }
  }
}