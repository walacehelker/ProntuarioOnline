using Domain.Cadastro;
using Domain.Prontuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Configuration.Prontuarios
{
  public class PtPreenchimentoFacialRelacaoAplicacaoConfiguration : BaseConfiguration<PtPreenchimentoFacialRelacaoAplicacao>
  {
    public override void Configure(EntityTypeBuilder<PtPreenchimentoFacialRelacaoAplicacao> builder)
    {

      // Configurações da classe base
      base.Configure(builder);

      // Nome da tabela
      builder.ToTable("pt_preenchimentos_faciais_relacao_aplicacao");


      // Chave estrangeira
      builder.Property(e => e.PreenchimentoFacialId)
             .HasColumnName("id_preenchimento_facial")
             .HasColumnType("varchar(50)")
             .IsRequired();

      builder.Property(e => e.Data)
             .HasColumnName("data")
             .HasColumnType("datetime")
             .IsRequired();

      builder.Property(e => e.AreaAplicacao)
             .HasColumnName("area_aplicacao")
             .HasColumnType("varchar(250)")
             .IsRequired();

      builder.Property(e => e.Quantidade)
             .HasColumnName("quantidade")
             .HasColumnType("decimal(10,2)")
             .IsRequired();

      builder.Property(e => e.Marca)
             .HasColumnName("marca")
             .HasColumnType("varchar(250)")
             .IsRequired();

      builder.Property(e => e.Produto)
             .HasColumnName("produto")
             .HasColumnType("varchar(250)")
             .IsRequired();

      builder.Property(e => e.Lote)
             .HasColumnName("lote")
             .HasColumnType("varchar(250)")
             .IsRequired();

      builder.Property(e => e.Validade)
             .HasColumnName("validade")
             .HasColumnType("datetime")
             .IsRequired();

      builder.HasOne(h => h.PtPreenchimentoFacial)
          .WithMany(p => p.PtPreenchimentoFacialRelacaoAplicacaoList)
          .HasForeignKey(h => h.PreenchimentoFacialId)
          .OnDelete(DeleteBehavior.Cascade);
    }
  }
}
