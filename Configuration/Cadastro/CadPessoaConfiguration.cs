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

      builder.Property(e => e.Rua)
             .HasColumnName("rua")
             .HasColumnType("varchar(200)")
             .IsRequired();

      builder.Property(e => e.Numero)
             .HasColumnName("numero")
             .HasColumnType("int")
             .IsRequired(false);

      builder.Property(e => e.Bairro)
             .HasColumnName("bairro")
             .HasColumnType("varchar(200)")
             .IsRequired();

      builder.Property(e => e.Cidade)
             .HasColumnName("cidade")
             .HasColumnType("varchar(200)")
             .IsRequired();

      builder.Property(e => e.Estado)
             .HasColumnName("estado")
             .HasColumnType("varchar(200)")
             .IsRequired();

      builder.Property(e => e.Cep)
             .HasColumnName("cep")
             .HasColumnType("varchar(20)")
             .IsRequired();

      builder.Property(e => e.Telefone)
             .HasColumnName("telefone")
             .HasColumnType("varchar(20)")
             .IsRequired();

      builder.Property(e => e.Email)
             .HasColumnName("email")
             .HasColumnType("varchar(200)")
             .IsRequired(false);

      builder.Property(e => e.PdfAssinado)
             .HasColumnName("pdf_assinado")
             .HasColumnType("varbinary(max)")
             .IsRequired(false);
    }
  }
}
