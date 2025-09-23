using AutoMapper;
using Domain.Cadastro;
using Implementations.Base;
using Configuration;
using Services.Cadastro;

namespace Implementations.Cadastro
{
  public class PessoaCadService : BaseService<CadPessoa, CadPessoaCadVm>, IPessoaCadService
  {
    private readonly IPessoaService _pessoaService;
    private readonly IPessoaHistoricoService _pessoaHistoricoService;
    private readonly IMapper _mapper;
    public PessoaCadService(AppDbContext context, 
      IMapper mapper,
      IPessoaHistoricoService pessoaHistoricoService,
      IPessoaService pessoaService)
        : base(context, mapper)
    {
      _pessoaHistoricoService = pessoaHistoricoService;
      _mapper = mapper;
      _pessoaService = pessoaService;
    }

    public async Task<bool> CreatePessoaComHistoricoAsync(CadPessoaCadVm model)
    {
      var dado = MapperToVm(model);

      var pessoaSalva = await _pessoaService.CreateAsync(dado);
      var historicoVm = new CadPessoaHistoricoVm
      {
        PessoaId = pessoaSalva.Id,
        Queixa = model.Queixa,
        DiagnosticoClinico = model.DiagnosticoClinico,
        AntecedentesPatologicos = model.AntecedentesPatologicos,
        AntecedentesFamiliares = model.AntecedentesFamiliares
      };

      await _pessoaHistoricoService.CreateAsync(historicoVm);

      return true;
    }

    private CadPessoaVm MapperToVm(CadPessoaCadVm modelCadVm)
    {
      if (modelCadVm == null) return null;

      var dado = new CadPessoaVm
      {
        Id = modelCadVm.Id,
        Nome = modelCadVm.Nome,
        NomeSocial = modelCadVm.NomeSocial,
        DataNascimento = modelCadVm.DataNascimento,
        Cpf = modelCadVm.Cpf,
        Rua = modelCadVm.Rua,
        Numero = modelCadVm.Numero,
        Bairro = modelCadVm.Bairro,
        Cidade = modelCadVm.Cidade,
        Estado = modelCadVm.Estado,
        Cep = modelCadVm.Cep,
        Telefone = modelCadVm.Telefone,
        Email = modelCadVm.Email
      };
      return dado;
    }

    public override async Task<CadPessoaCadVm> GetByIdAsync(Guid id)
    {
      var pessoaVm = await _pessoaService.GetByIdAsync(id);
      var pessoaCadVm = MapperToCadVm(pessoaVm);

      return pessoaCadVm;
    }

    private CadPessoaCadVm MapperToCadVm(CadPessoaVm modelCadVm)
    {
      if (modelCadVm == null) return null;

      var dado = new CadPessoaCadVm
      {
        Id = modelCadVm.Id,
        Nome = modelCadVm.Nome,
        NomeSocial = modelCadVm.NomeSocial,
        DataNascimento = modelCadVm.DataNascimento,
        Cpf = modelCadVm.Cpf,
        Rua = modelCadVm.Rua,
        Numero = modelCadVm.Numero,
        Bairro = modelCadVm.Bairro,
        Cidade = modelCadVm.Cidade,
        Estado = modelCadVm.Estado,
        Cep = modelCadVm.Cep,
        Telefone = modelCadVm.Telefone,
        Email = modelCadVm.Email
      };
      return dado;
    }
  }
}