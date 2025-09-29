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

    [DisplayName("OrbicularBoca")]    
    public decimal? OrbicularBoca { get; set; }

    [DisplayName("DepressorAnguloBocaDireito")]    
    public decimal? DepressorAnguloBocaDireito { get; set; }

    [DisplayName("DepressorAnguloBocaEsquerdo")]    
    public decimal? DepressorAnguloBocaEsquerdo { get; set; }

    [DisplayName("CorrugadorDireito")]    
    public decimal? CorrugadorDireito { get; set; }

    [DisplayName("CorrugadorEsquerdo")]    
    public decimal? CorrugadorEsquerdo { get; set; }

    [DisplayName("LevantadorLabioSuperiorDireito")]    
    public decimal? LevantadorLabioSuperiorDireito { get; set; }

    [DisplayName("LevantadorLabioSuperiorEsquerdo")]    
    public decimal? LevantadorLabioSuperiorEsquerdo { get; set; }

    [DisplayName("LLabioSupAsaNarizDireito")]    //
    public decimal? LLabioSupAsaNarizDireito { get; set; }

    [DisplayName("LLabioSupAsaNarizEsquerdo")]    //
    public decimal? LLabioSupAsaNarizEsquerdo { get; set; }

    [DisplayName("RisorioDireito")]    
    public decimal? RisorioDireito { get; set; }

    [DisplayName("RisorioEsquerdo")]    
    public decimal? RisorioEsquerdo { get; set; }

    [DisplayName("ZigomaticoMaiorDireito")]    
    public decimal? ZigomaticoMaiorDireito { get; set; }

    [DisplayName("ZigomaticoMaiorEsquerdo")]    
    public decimal? ZigomaticoMaiorEsquerdo { get; set; }

    [DisplayName("ZigomaticoMenorDireito")]    
    public decimal? ZigomaticoMenorDireito { get; set; }

    [DisplayName("ZigomaticoMenorEsquerdo")]    
    public decimal? ZigomaticoMenorEsquerdo { get; set; }

    [DisplayName("OrbicularOlhoDireito")]    
    public decimal? OrbicularOlhoDireito { get; set; }

    [DisplayName("OrbicularOlhoEsquerdo")]    
    public decimal? OrbicularOlhoEsquerdo { get; set; }

    [DisplayName("MentonianoDireito")]    
    public decimal? MentonianoDireito { get; set; }

    [DisplayName("MentonianoEsquerdo")]    
    public decimal? MentonianoEsquerdo { get; set; }

    [DisplayName("PlatismaDireito")]    
    public decimal? PlatismaDireito { get; set; }

    [DisplayName("PlatismaEsquerdo")]    
    public decimal? PlatismaEsquerdo { get; set; }

    [DisplayName("DepressorLabioInferiorDireito")]    
    public decimal? DepressorLabioInferiorDireito { get; set; }

    [DisplayName("DepressorLabioInferiorEsquerdo")]    
    public decimal? DepressorLabioInferiorEsquerdo { get; set; }

    [DisplayName("MassesterDireito")]    
    public decimal? MassesterDireito { get; set; }

    [DisplayName("MassesterEsquerdo")]    
    public decimal? MassesterEsquerdo { get; set; }

    [DisplayName("TotalUtilizado")]
    public decimal? TotalUtilizado { get; set; }

    public byte[] PdfAssinado { get; set; }

    [DisplayName("Aceita Divulgação")]
    public bool? AceitaDivulgacao { get; set; }

    [DisplayName("Observações")]
    public string Observacoes { get; set; }
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
    [Required(ErrorMessage = "Campo obrigatório.")]
    public decimal? Frontal { get; set; }

    [DisplayName("Procero")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public decimal? Procero { get; set; }

    [DisplayName("Nasal")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public decimal? Nasal { get; set; }

    [DisplayName("Depressor septo nasal")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public decimal? DepressorSeptoNasal { get; set; }

    [DisplayName("OrbicularBoca")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public decimal? OrbicularBoca { get; set; }

    [DisplayName("DepressorAnguloBocaDireito")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public decimal? DepressorAnguloBocaDireito { get; set; }

    [DisplayName("DepressorAnguloBocaEsquerdo")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public decimal? DepressorAnguloBocaEsquerdo { get; set; }

    [DisplayName("CorrugadorDireito")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public decimal? CorrugadorDireito { get; set; }

    [DisplayName("CorrugadorEsquerdo")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public decimal? CorrugadorEsquerdo { get; set; }

    [DisplayName("LevantadorLabioSuperiorDireito")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public decimal? LevantadorLabioSuperiorDireito { get; set; }

    [DisplayName("LevantadorLabioSuperiorEsquerdo")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public decimal? LevantadorLabioSuperiorEsquerdo { get; set; }

    [DisplayName("LLabioSupAsaNarizDireito")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public decimal? LLabioSupAsaNarizDireito { get; set; }

    [DisplayName("LLabioSupAsaNarizEsquerdo")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public decimal? LLabioSupAsaNarizEsquerdo { get; set; }

    [DisplayName("RisorioDireito")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public decimal? RisorioDireito { get; set; }

    [DisplayName("RisorioEsquerdo")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public decimal? RisorioEsquerdo { get; set; }

    [DisplayName("ZigomaticoMaiorDireito")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public decimal? ZigomaticoMaiorDireito { get; set; }

    [DisplayName("ZigomaticoMaiorEsquerdo")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public decimal? ZigomaticoMaiorEsquerdo { get; set; }

    [DisplayName("ZigomaticoMenorDireito")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public decimal? ZigomaticoMenorDireito { get; set; }

    [DisplayName("ZigomaticoMenorEsquerdo")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public decimal? ZigomaticoMenorEsquerdo { get; set; }

    [DisplayName("OrbicularOlhoDireito")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public decimal? OrbicularOlhoDireito { get; set; }

    [DisplayName("OrbicularOlhoEsquerdo")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public decimal? OrbicularOlhoEsquerdo { get; set; }

    [DisplayName("MentonianoDireito")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public decimal? MentonianoDireito { get; set; }

    [DisplayName("MentonianoEsquerdo")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public decimal? MentonianoEsquerdo { get; set; }

    [DisplayName("PlatismaDireito")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public decimal? PlatismaDireito { get; set; }

    [DisplayName("PlatismaEsquerdo")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public decimal? PlatismaEsquerdo { get; set; }

    [DisplayName("DepressorLabioInferiorDireito")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public decimal? DepressorLabioInferiorDireito { get; set; }

    [DisplayName("DepressorLabioInferiorEsquerdo")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public decimal? DepressorLabioInferiorEsquerdo { get; set; }

    [DisplayName("MassesterDireito")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public decimal? MassesterDireito { get; set; }

    [DisplayName("MassesterEsquerdo")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public decimal? MassesterEsquerdo { get; set; }

    [DisplayName("TotalUtilizado")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public decimal? TotalUtilizado { get; set; }

    public byte[] PdfAssinado { get; set; }
    public bool? AceitaDivulgacao { get; set; }
    public string Observacoes { get; set; }
  }

  public class AssinaturaBotoxVm
  {
    public Guid Id { get; set; }
    public byte[] PdfAssinado { get; set; }
    public bool? AceitaDivulgacao { get; set; }
    public string Observacoes { get; set; }

  }
}
