using Domain.Base;
using Domain.Prontuarios;

namespace Domain.Cadastro
{
  public class CadAgenda : BaseDomainEntity
  {
    public string Nome { get; set; }
    public DateTime Data { get; set; }
    public string ProcedimentoAgendado { get; set; }
    public string Telefone { get; set; }

  }
}
