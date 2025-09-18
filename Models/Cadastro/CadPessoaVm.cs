using Models.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Cadastro
{
  public class CadPessoaVm : BaseVmEntity
  {
    [DisplayName("Nome")]
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [StringLength(200, ErrorMessage = "O nome deve ter no máximo {1} caracteres.")]
    public string Nome { get; set; }

    [DisplayName("Nome Social")]
    [StringLength(200, ErrorMessage = "O nome social deve ter no máximo {1} caracteres.")]
    public string NomeSocial { get; set; }

    [DisplayName("Data de Nascimento")]
    [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
    [DataType(DataType.Date)]
    public DateTime DataNascimento { get; set; }

    [DisplayName("CPF")]
    [Required(ErrorMessage = "O CPF é obrigatório.")]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter exatamente 11 dígitos.")]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF deve conter apenas números.")]
    public string Cpf { get; set; }

  }
}
