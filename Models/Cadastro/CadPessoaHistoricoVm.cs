using Models.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Cadastro
{
  public class CadPessoaHistoricoVm : BaseVmEntity
  {
    [DisplayName("Queixa")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public string Queixa { get; set; }

    [DisplayName("Diagnostico Cliníco")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public string DiagnosticoClinico { get; set; }

    [DisplayName("Antecedentes Patologicos")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public string AntecedentesPatologicos { get; set; }

    [DisplayName("Antecedentes Familiares")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public string AntecedentesFamiliares { get; set; }

    public Guid PessoaId { get; set; }

  }
}
