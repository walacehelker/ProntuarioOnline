using AutoMapper.Configuration.Annotations;
using Models.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Prontuarios
{
  public class PtPreenchimentoFacialRelacaoEtiquetaVm : BaseVmEntity
  {
    public Guid PreenchimentoFacialId { get; set; }
    public byte[] EtiquetaPreenchedor { get; set; }
  }

  public class PtPreenchimentoFacialRelacaoEtiquetaCadVm : BaseVmEntity
  {
    public Guid PreenchimentoFacialId { get; set; }
    public byte[] EtiquetaPreenchedor { get; set; }
  }
}
