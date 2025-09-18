using Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Configuration
{
  public abstract class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseDomainEntity
  {
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
      // Nome da chave primária
      builder.HasKey(e => e.Id);

      builder.Property(e => e.Id)         
             .HasColumnName("id")
             .HasColumnType("varchar(50)")
             .IsRequired();

      builder.Property(e => e.DataInsercao)
             .HasColumnName("data_insercao")
             .HasColumnType("datetime2")
             .IsRequired();

      builder.Property(e => e.Excluido)
             .HasColumnName("excluido")
             .HasDefaultValue(false)
             .IsRequired();

      builder.Property(e => e.ExcluidoEm)
             .HasColumnName("excluido_em")
             .HasColumnType("datetime2")
             .IsRequired(false);
    }
  }
}
