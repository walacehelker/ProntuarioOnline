using AutoMapper.Configuration.Annotations;
using Models.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Prontuarios
{
  public class PtBotoxVm : BaseVmEntity
  {
    public Guid PessoaId { get; set; }
    public string PessoaNome { get; set; }

    [DisplayName("Data de nascimento")]
    public DateTime? DataProcedimento { get; set; }

    [DisplayName("Marca do Produto")]
    public string MarcaProduto { get; set; }

    [DisplayName("Data da diluição")]
    public DateTime? DataDiluicao { get; set; }

    [DisplayName("Volume da diluição")]
    public decimal? VolumeDiluicao { get; set; }

    [DisplayName("Número do lote")]
    public string NumeroLote { get; set; }

    [DisplayName("Data de validade")]
    public DateTime? DataValidade { get; set; }

    //Pontos de aplicação

    [DisplayName("Frontal")]
    public decimal? Frontal { get; set; }

    [DisplayName("Procero")]
    public decimal? Procero { get; set; }

    [DisplayName("Nasal")]
    public decimal? Nasal { get; set; }

    [DisplayName("Depressor septo nasal")]
    public decimal? DepressorSeptoNasal { get; set; }

    [DisplayName("Orbicular boca")]
    public decimal? OrbicularBoca { get; set; }

    [DisplayName("Depressor do ângulo da boca direito")]
    public decimal? DepressorAnguloBocaDireito { get; set; }

    [DisplayName("Depressor do ângulo da boca esquerdo")]
    public decimal? DepressorAnguloBocaEsquerdo { get; set; }

    [DisplayName("Corrugador direito")]
    public decimal? CorrugadorDireito { get; set; }

    [DisplayName("Corrugador esquerdo")]
    public decimal? CorrugadorEsquerdo { get; set; }

    [DisplayName("Levantador do lábio superior direito")]
    public decimal? LevantadorLabioSuperiorDireito { get; set; }

    [DisplayName("Levantador do lábio superior esquerdo")]
    public decimal? LevantadorLabioSuperiorEsquerdo { get; set; }

    [DisplayName("L. do lábio sup. asa do nariz direito")]
    public decimal? LLabioSupAsaNarizDireito { get; set; }

    [DisplayName("L. do lábio sup. asa do nariz esquerdo")]
    public decimal? LLabioSupAsaNarizEsquerdo { get; set; }

    [DisplayName("Risório direito")]
    public decimal? RisorioDireito { get; set; }

    [DisplayName("Risório esquerdo")]
    public decimal? RisorioEsquerdo { get; set; }

    [DisplayName("Zigomático maior direito")]
    public decimal? ZigomaticoMaiorDireito { get; set; }

    [DisplayName("Zigomático maior esquerdo")]
    public decimal? ZigomaticoMaiorEsquerdo { get; set; }

    [DisplayName("Zigomático menor direito")]
    public decimal? ZigomaticoMenorDireito { get; set; }

    [DisplayName("Zigomático menor esquerdo")]
    public decimal? ZigomaticoMenorEsquerdo { get; set; }

    [DisplayName("Orbicular do olho direito")]
    public decimal? OrbicularOlhoDireito { get; set; }

    [DisplayName("Orbicular do olho esquerdo")]
    public decimal? OrbicularOlhoEsquerdo { get; set; }

    [DisplayName("Mentoniano direito")]
    public decimal? MentonianoDireito { get; set; }

    [DisplayName("Mentoniano esquerdo")]
    public decimal? MentonianoEsquerdo { get; set; }

    [DisplayName("Platisma direito")]
    public decimal? PlatismaDireito { get; set; }

    [DisplayName("Platisma esquerdo")]
    public decimal? PlatismaEsquerdo { get; set; }

    [DisplayName("Depressor do lábio inferior direito")]
    public decimal? DepressorLabioInferiorDireito { get; set; }

    [DisplayName("Depressor do lábio inferior esquerdo")]
    public decimal? DepressorLabioInferiorEsquerdo { get; set; }

    [DisplayName("Massester direito")]
    public decimal? MassesterDireito { get; set; }

    [DisplayName("Massester esquerdo")]
    public decimal? MassesterEsquerdo { get; set; }

    [DisplayName("Total utilizado")]
    public decimal? TotalUtilizado { get; set; }

    public byte[] PdfAssinado { get; set; }

    [DisplayName("Aceita Divulgação")]
    public bool? AceitaDivulgacao { get; set; }

    [DisplayName("Observações")]
    public string Observacoes { get; set; }
    public DateTime? DataAssinatura { get; set; }
  }

  public class PtBotoxCadVm : BaseVmEntity
  {
    [DisplayName("Pessoa")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public Guid PessoaId { get; set; }

    [DisplayName("Pessoa")]
    [Ignore]
    public string PessoaNome { get; set; }

    [DisplayName("Data do procedimento")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    [DataType(DataType.Date)]
    public DateTime? DataProcedimento { get; set; }

    [DisplayName("Marca do Produto")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    [StringLength(200, ErrorMessage = "O nome deve ter no máximo {1} caracteres.")]
    public string MarcaProduto { get; set; }

    [DisplayName("Data da diluição")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    [DataType(DataType.Date)]
    public DateTime? DataDiluicao { get; set; }

    [DisplayName("Volume da diluição")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public decimal? VolumeDiluicao { get; set; }

    [DisplayName("Número do lote")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    [StringLength(200, ErrorMessage = "O nome deve ter no máximo {1} caracteres.")]
    public string NumeroLote { get; set; }

    [DisplayName("Data de validade")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    [DataType(DataType.Date)]
    public DateTime? DataValidade { get; set; }

    //Pontos de aplicação

    [DisplayName("Frontal")]
    public decimal? Frontal { get; set; }

    [DisplayName("Procero")]
    public decimal? Procero { get; set; }

    [DisplayName("Nasal")]
    public decimal? Nasal { get; set; }

    [DisplayName("Depressor septo nasal")]
    public decimal? DepressorSeptoNasal { get; set; }

    [DisplayName("Orbicular boca")]
    public decimal? OrbicularBoca { get; set; }

    [DisplayName("Depressor do ângulo da boca direito")]
    public decimal? DepressorAnguloBocaDireito { get; set; }

    [DisplayName("Depressor do ângulo da boca esquerdo")]
    public decimal? DepressorAnguloBocaEsquerdo { get; set; }

    [DisplayName("Corrugador direito")]
    public decimal? CorrugadorDireito { get; set; }

    [DisplayName("Corrugador esquerdo")]
    public decimal? CorrugadorEsquerdo { get; set; }

    [DisplayName("Levantador do lábio superior direito")]
    public decimal? LevantadorLabioSuperiorDireito { get; set; }

    [DisplayName("Levantador do lábio superior esquerdo")]
    public decimal? LevantadorLabioSuperiorEsquerdo { get; set; }

    [DisplayName("L. do lábio sup. asa do nariz direito")]
    public decimal? LLabioSupAsaNarizDireito { get; set; }

    [DisplayName("L. do lábio sup. asa do nariz esquerdo")]
    public decimal? LLabioSupAsaNarizEsquerdo { get; set; }

    [DisplayName("Risório direito")]
    public decimal? RisorioDireito { get; set; }

    [DisplayName("Risório esquerdo")]
    public decimal? RisorioEsquerdo { get; set; }

    [DisplayName("Zigomático maior direito")]
    public decimal? ZigomaticoMaiorDireito { get; set; }

    [DisplayName("Zigomático maior esquerdo")]
    public decimal? ZigomaticoMaiorEsquerdo { get; set; }

    [DisplayName("Zigomático menor direito")]
    public decimal? ZigomaticoMenorDireito { get; set; }

    [DisplayName("Zigomático menor esquerdo")]
    public decimal? ZigomaticoMenorEsquerdo { get; set; }

    [DisplayName("Orbicular do olho direito")]
    public decimal? OrbicularOlhoDireito { get; set; }

    [DisplayName("Orbicular do olho esquerdo")]
    public decimal? OrbicularOlhoEsquerdo { get; set; }

    [DisplayName("Mentoniano direito")]
    public decimal? MentonianoDireito { get; set; }

    [DisplayName("Mentoniano esquerdo")]
    public decimal? MentonianoEsquerdo { get; set; }

    [DisplayName("Platisma direito")]
    public decimal? PlatismaDireito { get; set; }

    [DisplayName("Platisma esquerdo")]
    public decimal? PlatismaEsquerdo { get; set; }

    [DisplayName("Depressor do lábio inferior direito")]
    public decimal? DepressorLabioInferiorDireito { get; set; }

    [DisplayName("Depressor do lábio inferior esquerdo")]
    public decimal? DepressorLabioInferiorEsquerdo { get; set; }

    [DisplayName("Massester direito")]
    public decimal? MassesterDireito { get; set; }

    [DisplayName("Massester esquerdo")]
    public decimal? MassesterEsquerdo { get; set; }

    [DisplayName("Total utilizado")]
    public decimal? TotalUtilizado { get; set; }

    public byte[] PdfAssinado { get; set; }
    public bool? AceitaDivulgacao { get; set; }
    public string Observacoes { get; set; }
    public DateTime? DataAssinatura { get; set; }
  }

  public class AssinaturaBotoxVm
  {
    public Guid Id { get; set; }
    public byte[] PdfAssinado { get; set; }
    public bool? AceitaDivulgacao { get; set; }
    public string Observacoes { get; set; }

  }
}
