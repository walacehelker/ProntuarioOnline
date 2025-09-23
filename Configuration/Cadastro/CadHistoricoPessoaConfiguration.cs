using Domain.Cadastro;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Configuration.Cadastro
{
  public class CadHistoricoPessoaConfiguration : IEntityTypeConfiguration<CadPessoaHistorico>
  {
    public void Configure(EntityTypeBuilder<CadPessoaHistorico> builder)
    {
      builder.ToTable("cad_pessoas_historicos");

      builder.HasKey(h => h.Id);

      builder.Property(e => e.Queixa)
       .HasColumnName("queixa")
       .HasColumnType("varchar(max)")
       .IsRequired();

      builder.Property(h => h.DiagnosticoClinico)
       .HasColumnName("diagnostico_clinico")
       .HasColumnType("varchar(max)")
       .IsRequired();

      builder.Property(h => h.AntecedentesPatologicos)
       .HasColumnName("antecedentes_patologicos")
       .HasColumnType("varchar(max)")
       .IsRequired();

      builder.Property(h => h.AntecedentesFamiliares)
       .HasColumnName("antecedentes_familiares")
       .HasColumnType("varchar(max)")
       .IsRequired();

      builder.Property(h => h.PessoaId)
       .HasColumnName("id_pessoa")
       .HasColumnType("varchar(50)")
       .IsRequired();

      // 🔗 Relacionamento: cada histórico pertence a uma pessoa
      builder.HasOne(h => h.CadPessoa)
          .WithMany(p => p.CadPessoaHistoricoList)
          .HasForeignKey(h => h.PessoaId) // cria a FK no banco
          .OnDelete(DeleteBehavior.Cascade); // opcional: exclui históricos ao excluir pessoa
    }
  }
}