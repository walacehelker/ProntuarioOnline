using Domain.Cadastro;
using Domain.Prontuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Configuration.Prontuarios
{
  public class PtPreenchimentoFacialRelacaoEtiquetaConfiguration : BaseConfiguration<PtPreenchimentoFacialRelacaoEtiqueta>
  {
    public override void Configure(EntityTypeBuilder<PtPreenchimentoFacialRelacaoEtiqueta> builder)
    {

      // Configurações da classe base
      base.Configure(builder);

      // Nome da tabela
      builder.ToTable("pt_preenchimentos_faciais_relacao_etiquetas");


      // Chave estrangeira
      builder.Property(e => e.PreenchimentoFacialId)
             .HasColumnName("id_preenchimento_facial")
             .HasColumnType("varchar(50)")
             .IsRequired();

      builder.Property(e => e.EtiquetaPreenchedor)
             .HasColumnName("etiqueta_preenchedor")
             .HasColumnType("varbinary(max)")
             .IsRequired(false);



      builder.HasOne(h => h.PtPreenchimentoFacial)
          .WithMany(p => p.PtPreenchimentoFacialRelacaoEtiquetaList)
          .HasForeignKey(h => h.PreenchimentoFacialId)
          .OnDelete(DeleteBehavior.Cascade);
    }
  }
}
