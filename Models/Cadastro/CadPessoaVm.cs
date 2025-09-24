using Models.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Cadastro
{
  public class CadPessoaVm : BaseVmEntity
  {
    [DisplayName("Nome")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    [StringLength(200, ErrorMessage = "O nome deve ter no máximo {1} caracteres.")]
    public string Nome { get; set; }

    [DisplayName("Nome social")]
    [StringLength(200, ErrorMessage = "O nome social deve ter no máximo {1} caracteres.")]
    public string NomeSocial { get; set; }

    [DisplayName("Data de nascimento")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    [DataType(DataType.Date)]
    public DateTime? DataNascimento { get; set; }

    [DisplayName("CPF")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter exatamente 11 dígitos.")]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF deve conter apenas números.")]
    public string Cpf { get; set; }

    [DisplayName("Rua")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    [StringLength(200, ErrorMessage = "O nome deve ter no máximo {1} caracteres.")]
    public string Rua { get; set; }

    [DisplayName("Número")]
    public int? Numero { get; set; }

    [DisplayName("Bairro")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    [StringLength(200, ErrorMessage = "O nome deve ter no máximo {1} caracteres.")]
    public string Bairro { get; set; }

    [DisplayName("Cidade")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    [StringLength(200, ErrorMessage = "O nome deve ter no máximo {1} caracteres.")]
    public string Cidade { get; set; }

    [DisplayName("Estado")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    [StringLength(200, ErrorMessage = "O nome deve ter no máximo {1} caracteres.")]
    public string Estado { get; set; }

    [DisplayName("Cep")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    [StringLength(200, ErrorMessage = "O nome deve ter no máximo {1} caracteres.")]
    public string Cep { get; set; }

    [DisplayName("Telefone")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    [StringLength(200, ErrorMessage = "O nome deve ter no máximo {1} caracteres.")]
    public string Telefone { get; set; }

    [DisplayName("Email")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    [StringLength(200, ErrorMessage = "O nome deve ter no máximo {1} caracteres.")]
    public string Email { get; set; }
  }

  public class CadPessoaCadVm : BaseVmEntity
  {
    [DisplayName("Nome")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    [StringLength(200, ErrorMessage = "O nome deve ter no máximo {1} caracteres.")]
    public string Nome { get; set; }

    [DisplayName("Nome social")]
    [StringLength(200, ErrorMessage = "O nome social deve ter no máximo {1} caracteres.")]
    public string NomeSocial { get; set; }

    [DisplayName("Data de nascimento")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    [DataType(DataType.Date)]
    public DateTime? DataNascimento { get; set; }

    [DisplayName("CPF")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    [StringLength(14, MinimumLength = 11, ErrorMessage = "O CPF deve ter exatamente 11 dígitos.")]
    public string Cpf { get; set; }

    [DisplayName("Rua")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    [StringLength(200, ErrorMessage = "O nome deve ter no máximo {1} caracteres.")]
    public string Rua { get; set; }

    [DisplayName("Número")]
    public int? Numero { get; set; }

    [DisplayName("Bairro")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    [StringLength(200, ErrorMessage = "O nome deve ter no máximo {1} caracteres.")]
    public string Bairro { get; set; }

    [DisplayName("Cidade")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    [StringLength(200, ErrorMessage = "O nome deve ter no máximo {1} caracteres.")]
    public string Cidade { get; set; }

    [DisplayName("Estado")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    [StringLength(200, ErrorMessage = "O nome deve ter no máximo {1} caracteres.")]
    public string Estado { get; set; }

    [DisplayName("Cep")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    [StringLength(200, ErrorMessage = "O nome deve ter no máximo {1} caracteres.")]
    public string Cep { get; set; }

    [DisplayName("Telefone")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    [StringLength(200, ErrorMessage = "O nome deve ter no máximo {1} caracteres.")]
    public string Telefone { get; set; }

    [DisplayName("Email")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    [StringLength(200, ErrorMessage = "O nome deve ter no máximo {1} caracteres.")]
    public string Email { get; set; }

    [DisplayName("Queixa")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public string Queixa { get; set; }

    [DisplayName("Diagnostico cliníco")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public string DiagnosticoClinico { get; set; }

    [DisplayName("Antecedentes patologicos")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public string AntecedentesPatologicos { get; set; }

    [DisplayName("Antecedentes familíares")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public string AntecedentesFamiliares { get; set; }

    [DisplayName("Possuí tratamento estético anterior?")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public bool PossuiTratamentoEsteticoAnterior { get; set; }

    [DisplayName("Toxina botulínica")]
    public bool ToxinixaBotulinica { get; set; }

    [DisplayName("Preenchedores")]
    public bool Preenchedores { get; set; }

    [DisplayName("Outras")]
    [StringLength(200, ErrorMessage = "O nome deve ter no máximo {1} caracteres.")]
    public string TratamentoEsteticoAnterior { get; set; }

    [DisplayName("Informações sobre a aplicação:")]
    public string InformacoesSobreAplicacao { get; set; }

    [DisplayName("Informações pós aplicação:")]
    public string InformacoesPosAplicacao { get; set; }

    //Medicamentos

    [DisplayName("Atualmente toma algum medicamento?")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public bool Medicamentos { get; set; }

    [DisplayName("Anti-inflamatório")]
    public bool AntiInfamatorio { get; set; }

    [DisplayName("Analgésico")]
    public bool Analgesico { get; set; }

    [DisplayName("Relaxante muscular")]
    public bool RelaxanteMuscular { get; set; }

    [DisplayName("Antibiótico")]
    public bool Antibiotico { get; set; }

    [DisplayName("Aminoglicosideos")]
    public bool Aminoglicosideos { get; set; }

    [DisplayName("Penicilaminas")]
    public bool Penicilaminas { get; set; }

    [DisplayName("Quinolonas")]
    public bool Quinolonas { get; set; }

    [DisplayName("Repositores hormonais")]
    public bool RepositoresHormonais { get; set; }

    [DisplayName("Succinilcolina")]
    public bool Succinilcolina { get; set; }

    [DisplayName("Bloqueadores de canais de cálcio")]
    public bool BloqueadorCanalCalcio { get; set; }

    [DisplayName("Outros medicamentos:")]
    public string OutrosMedicamentos { get; set; }



    [DisplayName("Costuma tomar sol?")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public bool TomaSol { get; set; }

    [DisplayName("Pratica algum esporte?")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public bool PraticaEsporte { get; set; }

    [DisplayName("Qual(ais) esporte(s)?")]
    public string Esportes { get; set; }

    [DisplayName("Antecedentes alérgicos?")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public bool AntecedentesAlergicos { get; set; }

    [DisplayName("Qual(ais) alegia(s)?")]
    public string Alergias { get; set; }

    [DisplayName("Stresse?")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public bool Stresse { get; set; }

    [DisplayName("Ansiedade?")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public bool Ansiedade { get; set; }

    [DisplayName("Outros distúrbios emocionais?")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public string OutrosDisturbiosEmocionais { get; set; }

    [DisplayName("Já fez tratamento ortomolecular?")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public bool TratamentoOrtomolecular { get; set; }

    [DisplayName("Qual tratamento ortomolecular?")]
    public string DescricaoTratamentosortomolecular { get; set; }

    [DisplayName("É fumante?")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public bool Fumante { get; set; }

    [DisplayName("Cuidados estéticos?")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public bool CuidadosEstéticos { get; set; }

    [DisplayName("Quais cuidados estéticos?")]
    public string DescricaoCuidadosEsteticos { get; set; }

    [DisplayName("Fez algum tratamento médico?")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public bool TratamentoMedico { get; set; }

    [DisplayName("Qual(ais) tratamento(s) médico?")]
    public string DescricaoTratamentoMedico { get; set; }

    [DisplayName("Usa ou já usou ácido na pele?")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public bool UsoAcidoPele { get; set; }

    [DisplayName("Qual ácido?")]
    public string QualAcido { get; set; }

    [DisplayName("É gestante ou está amamentando?")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public bool GestanteOuAmamentando { get; set; }

    [DisplayName("Possuí algum problema cardíaco?")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public bool ProblemaCardiaco { get; set; }

    [DisplayName("Qual problema cardíaco?")]
    public string QualProblemaCardiaco { get; set; }

    [DisplayName("Possuí intolerância a lactose?")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public bool IntoleranciaLactose { get; set; }

    [DisplayName("Tem diabetes?")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public bool Diabetes { get; set; }

    [DisplayName("Possuí alergia a proteína do ovo (Albumina)?")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public bool AlergiaOvo { get; set; }

    [DisplayName("Outras informações?")]
    public string InformacoesComplementares { get; set; }
  }
}
