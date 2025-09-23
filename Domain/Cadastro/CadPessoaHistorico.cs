using Domain.Base;

namespace Domain.Cadastro
{
  public class CadPessoaHistorico : BaseDomainEntity
  {
    public string Queixa { get; set; }
    public string DiagnosticoClinico { get; set; }
    public string AntecedentesPatologicos { get; set; }
    public string AntecedentesFamiliares { get; set; }
    public Guid PessoaId { get; set; }
    public virtual CadPessoa CadPessoa { get; set; }
  }
}
