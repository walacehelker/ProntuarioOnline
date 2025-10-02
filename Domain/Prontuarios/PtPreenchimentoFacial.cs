using Domain.Base;
using Domain.Cadastro;

namespace Domain.Prontuarios
{
  public class PtPreenchimentoFacial : BaseDomainEntity
  {
    public Guid PessoaId { get; set; }
    public DateTime? DataProcedimento { get; set; }
    public string Observacoes { get; set; }
    public byte[] AssinaturaTermoConsentimento { get; set; }
    public virtual CadPessoa CadPessoa { get; set; }  
    public virtual List<PtPreenchimentoFacialRelacaoAplicacao> PtPreenchimentoFacialRelacaoAplicacaoList { get; set; }
    public virtual List<PtPreenchimentoFacialRelacaoEtiqueta> PtPreenchimentoFacialRelacaoEtiquetaList { get; set; }
  }
}
