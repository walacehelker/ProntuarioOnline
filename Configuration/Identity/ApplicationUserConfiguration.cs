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

      builder.Property(u => u.TipoUsuario)
             .HasConversion<int>() 
             .IsRequired();

      // Caso queira limitar tamanho de UserName, Email etc.
      //builder.Property(u => u.UserName)
      //       .HasMaxLength(256);

      //builder.Property(u => u.Email)
      //       .HasMaxLength(256);
    }
  }
}