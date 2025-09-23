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

    [DisplayName("Nome Social")]
    [StringLength(200, ErrorMessage = "O nome social deve ter no máximo {1} caracteres.")]
    public string NomeSocial { get; set; }

    [DisplayName("Data de Nascimento")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    [DataType(DataType.Date)]
    public DateTime DataNascimento { get; set; }

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

    [DisplayName("Nome Social")]
    [StringLength(200, ErrorMessage = "O nome social deve ter no máximo {1} caracteres.")]
    public string NomeSocial { get; set; }

    [DisplayName("Data de Nascimento")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    [DataType(DataType.Date)]
    public DateTime DataNascimento { get; set; }

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
  }
}
