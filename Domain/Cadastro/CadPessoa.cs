using Domain.Base;

namespace Domain.Cadastro
{
  public class CadPessoa : BaseDomainEntity
  {
    public string Nome { get; set; }
    public string NomeSocial { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Cpf { get; set; }
  }
}
