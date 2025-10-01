using Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProntuarioOnline.Data.Configurations
{
  public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
  {
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
      // Nome da tabela (Identity já usa AspNetUsers por padrão)
      builder.ToTable("AspNetUsers");

      builder.Property(u => u.NomeCompleto)
             .HasColumnType("varchar(200)")
             .IsRequired();

      builder.Property(u => u.TipoUsuario)
             .HasConversion<int>() 
             .IsRequired();

      builder.Property(e => e.Assinatura)
             .HasColumnName("assinatura")
             .HasColumnType("varbinary(max)")
             .IsRequired(false);

      builder.Property(u => u.UsuarioProprietarioId)
             .HasColumnType("varchar(50)")
             .IsRequired();
    }
  }
}