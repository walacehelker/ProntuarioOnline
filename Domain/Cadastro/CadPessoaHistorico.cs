using Domain.Base;

namespace Domain.Cadastro
{
  public class CadPessoaHistorico : BaseDomainEntity
  {
    public Guid PessoaId { get; set; }
    public string Queixa { get; set; }
    public string DiagnosticoClinico { get; set; }
    public string AntecedentesPatologicos { get; set; }
    public string AntecedentesFamiliares { get; set; }
    public bool PossuiTratamentoEsteticoAnterior { get; set; }
    public bool ToxinixaBotulinica { get; set; }
    public bool Preenchedores { get; set; }
    public string TratamentoEsteticoAnterior { get; set; }
    public string InformacoesSobreAplicacao { get; set; }
    public string InformacoesPosAplicacao { get; set; }

    //Medicamentos
    public bool Medicamentos { get; set; }
    public bool AntiInfamatorio { get; set; }
    public bool Analgesico { get; set; }
    public bool RelaxanteMuscular { get; set; }
    public bool Antibiotico { get; set; }
    public bool Aminoglicosideos { get; set; }
    public bool Penicilaminas { get; set; }
    public bool Quinolonas { get; set; }
    public bool RepositoresHormonais { get; set; }
    public bool Succinilcolina { get; set; }
    public bool BloqueadorCanalCalcio { get; set; }
    public string OutrosMedicamentos { get; set; }


    public bool TomaSol { get; set; }
    public bool PraticaEsporte { get; set; }
    public string Esportes { get; set; }
    public bool AntecedentesAlergicos { get; set; }
    public string Alergias { get; set; }
    public bool Stresse { get; set; }
    public bool Ansiedade { get; set; }
    public string OutrosDisturbiosEmocionais { get; set; }
    public bool TratamentoOrtomolecular { get; set; }
    public string DescricaoTratamentosortomolecular { get; set; }
    public bool Fumante { get; set; }
    public bool CuidadosEstéticos { get; set; }
    public string DescricaoCuidadosEsteticos { get; set; }
    public bool TratamentoMedico { get; set; }
    public string DescricaoTratamentoMedico { get; set; }
    public bool UsoAcidoPele { get; set; }
    public string QualAcido { get; set; }
    public bool GestanteOuAmamentando { get; set; }
    public bool ProblemaCardiaco { get; set; }
    public string QualProblemaCardiaco { get; set; }
    public bool IntoleranciaLactose { get; set; }
    public bool Diabetes { get; set; }
    public bool AlergiaOvo { get; set; }
    public string InformacoesComplementares { get; set; }
    public virtual CadPessoa CadPessoa { get; set; }
  }
}
