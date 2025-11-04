using AutoMapper.Configuration.Annotations;
using Models.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Prontuarios
{
  public class PtPreenchimentoFacialVm : BaseVmEntity
  {
    public Guid PessoaId { get; set; }
    public string PessoaNome { get; set; }

    [DisplayName("Data do procedimento")]
    public DateTime? DataProcedimento { get; set; }
    public string Observacoes { get; set; }
    public byte[] AssinaturaTermoConsentimento { get; set; }
    public DateTime? DataAssinatura { get; set; }

    public string AplicacoesJson { get; set; }
    public string EtiquetasJson { get; set; }
  }

  public class PtPreenchimentoFacialCadVm : BaseVmEntity
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

    public List<PtPreenchimentoFacialRelacaoAplicacaoVm> Aplicacoes { get; set; }
    public List<PtPreenchimentoFacialRelacaoEtiquetaVm> Etiquetas { get; set; }

    public string AplicacoesJson { get; set; }
    public string EtiquetasJson { get; set; }
    public string Observacoes { get; set; }
    public byte[] AssinaturaTermoConsentimento { get; set; }
    public DateTime? DataAssinatura { get; set; }

  }

  public class AssinaturaPreenchimentoFacialVm
  {
    public Guid Id { get; set; }
    public byte[] PdfAssinado { get; set; }
    public string Observacoes { get; set; }

  }
}
