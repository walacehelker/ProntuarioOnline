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
        PessoaId = pessoaSalva.Id
      };

      MapPessoaHistorico(model, historicoVm);

      await _pessoaHistoricoService.CreateAsync(historicoVm);

      return true;
    }

    public async Task<bool> UpdatePessoaComHistoricoAsync(Guid id, CadPessoaCadVm model)
    {
      // Atualiza a pessoa
      var dado = MapperToVm(model);
      var pessoaAtualizada = await _pessoaService.UpdateAsync(dado);

      if (pessoaAtualizada == null)
        return false; // não encontrou a pessoa

      // Busca o histórico existente
      var historicoExistente = (await _pessoaHistoricoService.FindAsync(h => h.PessoaId == id))
                                  .FirstOrDefault();

      if (historicoExistente != null)
      {
        // Atualiza os dados do histórico
        MapPessoaHistorico(model, historicoExistente);

        await _pessoaHistoricoService.UpdateAsync(historicoExistente);
      }
      else
      {
        // Se não existir histórico, cria um novo
        var historicoVm = new CadPessoaHistoricoVm
        {
          PessoaId = pessoaAtualizada.Id
        };

        MapPessoaHistorico(model, historicoVm);

        await _pessoaHistoricoService.CreateAsync(historicoVm);
      }

      return true;
    }


    private void MapPessoaHistorico(CadPessoaCadVm model, CadPessoaHistoricoVm historico)
    {
      historico.Queixa = model.Queixa;
      historico.DiagnosticoClinico = model.DiagnosticoClinico;
      historico.AntecedentesPatologicos = model.AntecedentesPatologicos;
      historico.AntecedentesFamiliares = model.AntecedentesFamiliares;

      historico.PossuiTratamentoEsteticoAnterior = model.PossuiTratamentoEsteticoAnterior;
      historico.ToxinixaBotulinica = model.ToxinixaBotulinica;
      historico.Preenchedores = model.Preenchedores;
      historico.TratamentoEsteticoAnterior = model.TratamentoEsteticoAnterior;
      historico.InformacoesSobreAplicacao = model.InformacoesSobreAplicacao;
      historico.InformacoesPosAplicacao = model.InformacoesPosAplicacao;

      historico.Medicamentos = model.Medicamentos;
      historico.AntiInfamatorio = model.AntiInfamatorio;
      historico.Analgesico = model.Analgesico;
      historico.RelaxanteMuscular = model.RelaxanteMuscular;
      historico.Antibiotico = model.Antibiotico;
      historico.Aminoglicosideos = model.Aminoglicosideos;
      historico.Penicilaminas = model.Penicilaminas;
      historico.Quinolonas = model.Quinolonas;
      historico.RepositoresHormonais = model.RepositoresHormonais;
      historico.Succinilcolina = model.Succinilcolina;
      historico.BloqueadorCanalCalcio = model.BloqueadorCanalCalcio;
      historico.OutrosMedicamentos = model.OutrosMedicamentos;

      historico.TomaSol = model.TomaSol;
      historico.PraticaEsporte = model.PraticaEsporte;
      historico.Esportes = model.Esportes;
      historico.AntecedentesAlergicos = model.AntecedentesAlergicos;
      historico.Alergias = model.Alergias;
      historico.Stresse = model.Stresse;
      historico.Ansiedade = model.Ansiedade;
      historico.OutrosDisturbiosEmocionais = model.OutrosDisturbiosEmocionais;
      historico.TratamentoOrtomolecular = model.TratamentoOrtomolecular;
      historico.DescricaoTratamentosortomolecular = model.DescricaoTratamentosortomolecular;
      historico.Fumante = model.Fumante;
      historico.CuidadosEstéticos = model.CuidadosEstéticos;
      historico.DescricaoCuidadosEsteticos = model.DescricaoCuidadosEsteticos;
      historico.TratamentoMedico = model.TratamentoMedico;
      historico.DescricaoTratamentoMedico = model.DescricaoTratamentoMedico;
      historico.UsoAcidoPele = model.UsoAcidoPele;
      historico.QualAcido = model.QualAcido;
      historico.GestanteOuAmamentando = model.GestanteOuAmamentando;
      historico.ProblemaCardiaco = model.ProblemaCardiaco;
      historico.QualProblemaCardiaco = model.QualProblemaCardiaco;
      historico.IntoleranciaLactose = model.IntoleranciaLactose;
      historico.Diabetes = model.Diabetes;
      historico.AlergiaOvo = model.AlergiaOvo;
      historico.InformacoesComplementares = model.InformacoesComplementares;
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
        Email = modelCadVm.Email,
        PdfAssinado = modelCadVm.PdfAssinado
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

      // Busca o histórico da pessoa
      var dadosHistorico = _pessoaHistoricoService.FindOne(c => c.PessoaId == modelCadVm.Id);

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
        Email = modelCadVm.Email,

        // Campos de histórico
        Queixa = dadosHistorico?.Queixa,
        DiagnosticoClinico = dadosHistorico?.DiagnosticoClinico,
        AntecedentesPatologicos = dadosHistorico?.AntecedentesPatologicos,
        AntecedentesFamiliares = dadosHistorico?.AntecedentesFamiliares,
        PossuiTratamentoEsteticoAnterior = dadosHistorico?.PossuiTratamentoEsteticoAnterior ?? false,
        ToxinixaBotulinica = dadosHistorico?.ToxinixaBotulinica ?? false,
        Preenchedores = dadosHistorico?.Preenchedores ?? false,
        TratamentoEsteticoAnterior = dadosHistorico?.TratamentoEsteticoAnterior,
        InformacoesSobreAplicacao = dadosHistorico?.InformacoesSobreAplicacao,
        InformacoesPosAplicacao = dadosHistorico?.InformacoesPosAplicacao,

        Medicamentos = dadosHistorico?.Medicamentos ?? false,
        AntiInfamatorio = dadosHistorico?.AntiInfamatorio ?? false,
        Analgesico = dadosHistorico?.Analgesico ?? false,
        RelaxanteMuscular = dadosHistorico?.RelaxanteMuscular ?? false,
        Antibiotico = dadosHistorico?.Antibiotico ?? false,
        Aminoglicosideos = dadosHistorico?.Aminoglicosideos ?? false,
        Penicilaminas = dadosHistorico?.Penicilaminas ?? false,
        Quinolonas = dadosHistorico?.Quinolonas ?? false,
        RepositoresHormonais = dadosHistorico?.RepositoresHormonais ?? false,
        Succinilcolina = dadosHistorico?.Succinilcolina ?? false,
        BloqueadorCanalCalcio = dadosHistorico?.BloqueadorCanalCalcio ?? false,
        OutrosMedicamentos = dadosHistorico?.OutrosMedicamentos,

        TomaSol = dadosHistorico?.TomaSol ?? false,
        PraticaEsporte = dadosHistorico?.PraticaEsporte ?? false,
        Esportes = dadosHistorico?.Esportes,
        AntecedentesAlergicos = dadosHistorico?.AntecedentesAlergicos ?? false,
        Alergias = dadosHistorico?.Alergias,
        Stresse = dadosHistorico?.Stresse ?? false,
        Ansiedade = dadosHistorico?.Ansiedade ?? false,
        OutrosDisturbiosEmocionais = dadosHistorico?.OutrosDisturbiosEmocionais,
        TratamentoOrtomolecular = dadosHistorico?.TratamentoOrtomolecular ?? false,
        DescricaoTratamentosortomolecular = dadosHistorico?.DescricaoTratamentosortomolecular,
        Fumante = dadosHistorico?.Fumante ?? false,
        CuidadosEstéticos = dadosHistorico?.CuidadosEstéticos ?? false,
        DescricaoCuidadosEsteticos = dadosHistorico?.DescricaoCuidadosEsteticos,
        TratamentoMedico = dadosHistorico?.TratamentoMedico ?? false,
        DescricaoTratamentoMedico = dadosHistorico?.DescricaoTratamentoMedico,
        UsoAcidoPele = dadosHistorico?.UsoAcidoPele ?? false,
        QualAcido = dadosHistorico?.QualAcido,
        GestanteOuAmamentando = dadosHistorico?.GestanteOuAmamentando ?? false,
        ProblemaCardiaco = dadosHistorico?.ProblemaCardiaco ?? false,
        QualProblemaCardiaco = dadosHistorico?.QualProblemaCardiaco,
        IntoleranciaLactose = dadosHistorico?.IntoleranciaLactose ?? false,
        Diabetes = dadosHistorico?.Diabetes ?? false,
        AlergiaOvo = dadosHistorico?.AlergiaOvo ?? false,
        InformacoesComplementares = dadosHistorico?.InformacoesComplementares
      };

      return dado;
    }

    public async Task SalvarAssinaturaAsync(CadPessoaCadVm assinaturaVm)
    {
      var pessoa = await GetByIdAsync(assinaturaVm.Id);

      if (pessoa == null)
        throw new Exception("Pessoa não encontrada.");

      // Vincula o PDF assinado
      pessoa.PdfAssinado = assinaturaVm.PdfAssinado;

      await UpdateAsync(pessoa);
    }
  }
}