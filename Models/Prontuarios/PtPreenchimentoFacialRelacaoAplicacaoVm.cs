using AutoMapper.Configuration.Annotations;
using Models.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Prontuarios
{
  public class PtPreenchimentoFacialRelacaoAplicacaoVm : BaseVmEntity
  {
    public Guid PreenchimentoFacialId { get; set; }

    [DisplayName("Data do procedimento")]
    public DateTime? Data { get; set; }

    [DisplayName("Área da aplicação")]
    public string AreaAplicacao { get; set; }

    [DisplayName("Quantidade")]
    public double? Quantidade { get; set; }

    [DisplayName("Marca")]
    public string Marca { get; set; }

    [DisplayName("Produto")]
    public string Produto { get; set; }

    [DisplayName("Lote")]
    public string Lote { get; set; }

    [DisplayName("Validade")]
    public DateTime? Validade { get; set; }
  }

  public class PtPreenchimentoFacialRelacaoAplicacaoCadVm : BaseVmEntity
  {
    [DisplayName("Pessoa")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public Guid PreenchimentoFacialId { get; set; }

    [DisplayName("Data do procedimento")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    [DataType(DataType.Date)]
    public DateTime? Data { get; set; }

    [DisplayName("Área da aplicação")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    [StringLength(250, ErrorMessage = "O nome social deve ter no máximo {1} caracteres.")]
    public string AreaAplicacao { get; set; }

    [DisplayName("Quantidade")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public double Quantidade { get; set; }

    [DisplayName("Marca")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    [StringLength(250, ErrorMessage = "O nome social deve ter no máximo {1} caracteres.")]
    public string Marca { get; set; }

    [DisplayName("Produto")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    [StringLength(250, ErrorMessage = "O nome social deve ter no máximo {1} caracteres.")]
    public string Produto { get; set; }

    [DisplayName("Lote")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    [StringLength(250, ErrorMessage = "O nome social deve ter no máximo {1} caracteres.")]
    public string Lote { get; set; }

    [DisplayName("Validade")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    [DataType(DataType.Date)]
    public DateTime? Validade { get; set; }
  }
}
