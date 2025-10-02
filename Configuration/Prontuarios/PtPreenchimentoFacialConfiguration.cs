using Domain.Cadastro;
using Domain.Prontuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Configuration.Prontuarios
{
  public class PtPreenchimentoFacialConfiguration : BaseConfiguration<PtPreenchimentoFacial>
  {
    public override void Configure(EntityTypeBuilder<PtPreenchimentoFacial> builder)
    {

      // Configurações da classe base
      base.Configure(builder);

      // Nome da tabela
      builder.ToTable("pt_preenchimentos_faciais");


      // Chave estrangeira
      builder.Property(e => e.PessoaId)
             .HasColumnName("id_pessoa")
             .HasColumnType("varchar(50)")
             .IsRequired();

      builder.Property(e => e.DataProcedimento)
             .HasColumnName("data_procedimento")
             .HasColumnType("datetime")
             .IsRequired();

      builder.Property(e => e.Observacoes)
             .HasColumnName("observacoes")
             .HasColumnType("varchar(500)")
             .IsRequired(false);

      builder.Property(e => e.AssinaturaTermoConsentimento)
             .HasColumnName("assinatura_termo_consentimento")
             .HasColumnType("varbinary(max)")
             .IsRequired(false);

      builder.HasOne(h => h.CadPessoa)
          .WithMany(p => p.PtPreenchimentoFacialList)
          .HasForeignKey(h => h.PessoaId)
          .OnDelete(DeleteBehavior.Cascade);
    }
  }
}
