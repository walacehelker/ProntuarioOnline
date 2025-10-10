using Domain.Cadastro;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Configuration
{
  public class CadAgendaConfiguration : BaseConfiguration<CadAgenda>
  {
    public override void Configure(EntityTypeBuilder<CadAgenda> builder)
    {

      // Configurações da classe base
      base.Configure(builder);

      // Nome da tabela
      builder.ToTable("cad_agenda");


      builder.Property(e => e.Nome)
             .HasColumnName("nome")
             .HasColumnType("varchar(200)")
             .IsRequired();

      builder.Property(e => e.Data)
             .HasColumnName("data")
             .HasColumnType("datetime2")
             .IsRequired();

      builder.Property(e => e.ProcedimentoAgendado)
             .HasColumnName("procedimento_agendado")
             .HasColumnType("varchar(100)")
             .IsRequired(false);

      builder.Property(e => e.Telefone)
             .HasColumnName("telefone")
             .HasColumnType("varchar(200)")
             .IsRequired();
    }
  }
}
