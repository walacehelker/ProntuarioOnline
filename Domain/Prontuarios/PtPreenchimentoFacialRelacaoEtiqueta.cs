using Domain.Base;

namespace Domain.Prontuarios
{
  public class PtPreenchimentoFacialRelacaoEtiqueta : BaseDomainEntity
  {
    public Guid PreenchimentoFacialId { get; set; }
    public byte[] EtiquetaPreenchedor { get; set; }
    public virtual PtPreenchimentoFacial PtPreenchimentoFacial { get; set; }
  }
}
