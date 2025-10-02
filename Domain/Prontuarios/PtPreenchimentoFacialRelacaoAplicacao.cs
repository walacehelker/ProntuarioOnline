using Domain.Base;

namespace Domain.Prontuarios
{
  public class PtPreenchimentoFacialRelacaoAplicacao : BaseDomainEntity
  {
    public Guid PreenchimentoFacialId { get; set; }
    public DateTime? Data { get; set; }
    public string AreaAplicacao { get; set; }
    public double Quantidade { get; set; }
    public string Marca { get; set; }
    public string Produto { get; set; }
    public string Lote { get; set; }
    public DateTime? Validade { get; set; }
    public virtual PtPreenchimentoFacial PtPreenchimentoFacial { get; set; }
  }
}
