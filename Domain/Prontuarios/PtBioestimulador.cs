using Domain.Base;
using Domain.Cadastro;

namespace Domain.Prontuarios
{
  public class PtBioestimulador : BaseDomainEntity
  {
    public Guid PessoaId { get; set; }
    public DateTime DataProcedimento { get; set; }
    
    public byte[] PdfAssinado { get; set; }
    public CadPessoa CadPessoa { get; set; }
  }
}
