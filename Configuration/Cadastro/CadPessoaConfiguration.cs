using Domain.Cadastro;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Configuration
{
  public class CadPessoaConfiguration : BaseConfiguration<CadPessoa>
  {
    public override void Configure(EntityTypeBuilder<CadPessoa> builder)
    {

      // Configurações da classe base
      base.Configure(builder);

      // Nome da tabela
      builder.ToTable("cad_pessoas");


      builder.Property(e => e.Nome)         
             .HasColumnName("nome")
             .HasColumnType("varchar(200)")
             .IsRequired();

      builder.Property(e => e.NomeSocial)
             .HasColumnName("nome_social")
             .HasColumnType("varchar(200)")
             .IsRequired(false);

      builder.Property(e => e.DataNascimento)
             .HasColumnName("data_nascimento")
             .HasColumnType("datetime2")
             .IsRequired();

      builder.Property(e => e.Cpf)
             .HasColumnName("cpf")
             .HasColumnType("varchar(20)")
             .IsRequired();
    }
  }
}
