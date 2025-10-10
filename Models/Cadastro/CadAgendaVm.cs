using Domain.Identity;
using Enuns;
using Models.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models.Cadastro
{
  public class CadAgendaVm : BaseVmEntity
  {
    [Display(Name = "Paciente")]
    public string Nome { get; set; }

    [Display(Name = "Data")]
    public DateTime Data { get; set; }

    [Display(Name = "Procedimento Agendado")]
    public string ProcedimentoAgendado { get; set; }

    [Display(Name = "Contato")]
    public string Telefone { get; set; }
  }

  public class CadAgendaCadVm : BaseVmEntity
  {

    [Display(Name = "Paciente")]
    [Required(ErrorMessage = "O nome é obrigatório")]
    public string Nome { get; set; }

    [DisplayName("Data")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime Data { get; set; }

    [DisplayName("Procedimento Agendado")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    [StringLength(100, ErrorMessage = "O nome deve ter no máximo {1} caracteres.")]
    public string ProcedimentoAgendado { get; set; }

    [DisplayName("Telefone")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    [StringLength(200, ErrorMessage = "O nome deve ter no máximo {1} caracteres.")]
    public string Telefone { get; set; }
  }
}
