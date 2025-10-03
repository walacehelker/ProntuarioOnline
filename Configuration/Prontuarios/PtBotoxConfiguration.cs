using Domain.Cadastro;
using Domain.Prontuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Configuration.Prontuarios
{
  public class PtBotoxConfiguration : BaseConfiguration<PtBotox>
  {
    public override void Configure(EntityTypeBuilder<PtBotox> builder)
    {

      // Configurações da classe base
      base.Configure(builder);

      // Nome da tabela
      builder.ToTable("pt_botox");


      // Chave estrangeira
      builder.Property(e => e.PessoaId)
             .HasColumnName("id_pessoa")
             .HasColumnType("varchar(50)")
             .IsRequired();

      builder.Property(e => e.DataProcedimento)
             .HasColumnName("data_procedimento")
             .HasColumnType("datetime2")
             .IsRequired();

      builder.Property(e => e.MarcaProduto)
             .HasColumnName("marca_produto")
             .HasColumnType("varchar(200)")
             .IsRequired(false);

      builder.Property(e => e.DataDiluicao)
             .HasColumnName("data_diluicao")
             .HasColumnType("datetime2")
             .IsRequired(false);

      builder.Property(e => e.VolumeDiluicao)
             .HasColumnName("volume_diluicao")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.NumeroLote)
             .HasColumnName("numero_lote")
             .HasColumnType("varchar(100)")
             .IsRequired(false);

      builder.Property(e => e.DataValidade)
             .HasColumnName("data_validade")
             .HasColumnType("datetime2")
             .IsRequired(false);

      // 🔹 Pontos de aplicação
      builder.Property(e => e.Frontal)
             .HasColumnName("frontal")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.Procero)
             .HasColumnName("procero")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.Nasal)
             .HasColumnName("nasal")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.DepressorSeptoNasal)
             .HasColumnName("depressor_septo_nasal")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.OrbicularBoca)
             .HasColumnName("orbicular_boca")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.DepressorAnguloBocaDireito)
             .HasColumnName("depressor_angulo_boca_direito")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.DepressorAnguloBocaEsquerdo)
             .HasColumnName("depressor_angulo_boca_esquerdo")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.CorrugadorDireito)
             .HasColumnName("corrugador_direito")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.CorrugadorEsquerdo)
             .HasColumnName("corrugador_esquerdo")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.LevantadorLabioSuperiorDireito)
             .HasColumnName("levantador_labio_superior_direito")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.LevantadorLabioSuperiorEsquerdo)
             .HasColumnName("levantador_labio_superior_esquerdo")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.LLabioSupAsaNarizDireito)
             .HasColumnName("levantador_labio_superior_asa_nariz_direita")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.LLabioSupAsaNarizEsquerdo)
             .HasColumnName("levantador_labio_superior_asa_nariz_esquerdo")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      // 🔹 Pontos de aplicação adicionais
      builder.Property(e => e.RisorioDireito)
             .HasColumnName("risorio_direito")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.RisorioEsquerdo)
             .HasColumnName("risorio_esquerdo")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.ZigomaticoMaiorDireito)
             .HasColumnName("zigomatico_maior_direito")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.ZigomaticoMaiorEsquerdo)
             .HasColumnName("zigomatico_maior_esquerdo")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.ZigomaticoMenorDireito)
             .HasColumnName("zigomatico_menor_direito")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.ZigomaticoMenorEsquerdo)
             .HasColumnName("zigomatico_menor_esquerdo")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.OrbicularOlhoDireito)
             .HasColumnName("orbicular_olho_direito")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.OrbicularOlhoEsquerdo)
             .HasColumnName("orbicular_olho_esquerdo")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.MentonianoDireito)
             .HasColumnName("mentoniano_direito")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.MentonianoEsquerdo)
             .HasColumnName("mentoniano_esquerdo")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.PlatismaDireito)
             .HasColumnName("platisma_direito")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.PlatismaEsquerdo)
             .HasColumnName("platisma_esquerdo")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.DepressorLabioInferiorDireito)
             .HasColumnName("depressor_labio_inferior_direito")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.DepressorLabioInferiorEsquerdo)
             .HasColumnName("depressor_labio_inferior_esquerdo")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.MassesterDireito)
             .HasColumnName("masseter_direito")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.MassesterEsquerdo)
             .HasColumnName("masseter_esquerdo")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      // 🔹 Total utilizado
      builder.Property(e => e.TotalUtilizado)
             .HasColumnName("total_utilizado")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.PdfAssinado)
             .HasColumnName("pdf_assinado")
             .HasColumnType("varbinary(max)")
             .IsRequired(false);


      builder.Property(h => h.Observacoes)
             .HasColumnName("observacoes")
             .HasColumnType("varchar(max)")
             .IsRequired(false);

      builder.Property(h => h.AceitaDivulgacao)
             .HasColumnName("aceita_divulgacao")
             .HasDefaultValue(false)
             .IsRequired(false);

      builder.Property(e => e.DataAssinatura)
             .HasColumnName("data_assinatura")
             .HasColumnType("datetime2")
             .IsRequired(false);


      builder.HasOne(h => h.CadPessoa)
          .WithMany(p => p.PtBotoxList)
          .HasForeignKey(h => h.PessoaId)
          .OnDelete(DeleteBehavior.Cascade);
    }
  }
}
