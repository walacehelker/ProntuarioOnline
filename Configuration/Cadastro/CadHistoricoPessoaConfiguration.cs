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


      builder.Property(h => h.PessoaId)
       .HasColumnName("id_pessoa")
       .HasColumnType("varchar(50)")
       .IsRequired();

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

      builder.Property(h => h.AntecedentesFamiliares)
       .HasColumnName("antecedentes_familiares")
       .HasColumnType("varchar(max)")
       .IsRequired();

      builder.Property(h => h.PossuiTratamentoEsteticoAnterior)
       .HasColumnName("possui_tratamento_estetico_anterior")
       .HasDefaultValue(false)
       .IsRequired();

      builder.Property(h => h.ToxinixaBotulinica)
       .HasColumnName("toxinia_botulinica")
       .HasDefaultValue(false)
       .IsRequired();

      builder.Property(h => h.Preenchedores)
       .HasColumnName("preenchedores")
       .HasDefaultValue(false)
       .IsRequired();

      builder.Property(h => h.TratamentoEsteticoAnterior)
       .HasColumnName("tratamento_estetico_anterior")
       .HasColumnType("varchar(max)")
       .IsRequired(false);

      builder.Property(h => h.InformacoesSobreAplicacao)
       .HasColumnName("informacoes_sobre_aplicacao")
       .HasColumnType("varchar(max)")
       .IsRequired(false);

      builder.Property(h => h.InformacoesPosAplicacao)
       .HasColumnName("informacoes_pos_aplicacao")
       .HasColumnType("varchar(max)")
       .IsRequired(false);

      //Medicamentos

      builder.Property(h => h.Medicamentos)
       .HasColumnName("medicamentos")
       .HasDefaultValue(false)
       .IsRequired();

      builder.Property(h => h.AntiInfamatorio)
       .HasColumnName("anti_inflamatorio")
       .HasDefaultValue(false)
       .IsRequired();

      builder.Property(h => h.Analgesico)
       .HasColumnName("analgesico")
       .HasDefaultValue(false)
       .IsRequired();

      builder.Property(h => h.RelaxanteMuscular)
       .HasColumnName("relaxante_muscular")
       .HasDefaultValue(false)
       .IsRequired();

      builder.Property(h => h.Antibiotico)
       .HasColumnName("antibiotico")
       .HasDefaultValue(false)
       .IsRequired();

      builder.Property(h => h.Aminoglicosideos)
       .HasColumnName("aminoglicosideos")
       .HasDefaultValue(false)
       .IsRequired();

      builder.Property(h => h.Penicilaminas)
       .HasColumnName("penicilaminas")
       .HasDefaultValue(false)
       .IsRequired();

      builder.Property(h => h.Quinolonas)
       .HasColumnName("quinolonas")
       .HasDefaultValue(false)
       .IsRequired();

      builder.Property(h => h.RepositoresHormonais)
       .HasColumnName("repositores_hormonais")
       .HasDefaultValue(false)
       .IsRequired();

      builder.Property(h => h.Succinilcolina)
       .HasColumnName("succinilcolina")
       .HasDefaultValue(false)
       .IsRequired();

      builder.Property(h => h.BloqueadorCanalCalcio)
       .HasColumnName("bloqueador_canal_cacio")
       .HasDefaultValue(false)
       .IsRequired();

      builder.Property(h => h.OutrosMedicamentos)
       .HasColumnName("outros_medicamentos")
       .HasColumnType("varchar(300)")
       .IsRequired(false);



      builder.Property(h => h.TomaSol)
       .HasColumnName("toma_sol")
       .HasDefaultValue(false)
       .IsRequired();

      builder.Property(h => h.PraticaEsporte)
       .HasColumnName("pratica_esporte")
       .HasDefaultValue(false)
       .IsRequired();

      builder.Property(h => h.Esportes)
       .HasColumnName("esportes")
       .HasColumnType("varchar(300)")
       .IsRequired(false);

      builder.Property(h => h.AntecedentesAlergicos)
       .HasColumnName("antecedentes_alergicos")
       .HasDefaultValue(false)
       .IsRequired();

      builder.Property(h => h.Alergias)
       .HasColumnName("alergias")
       .HasColumnType("varchar(300)")
       .IsRequired(false);

      builder.Property(h => h.Stresse)
       .HasColumnName("stresse")
       .HasDefaultValue(false)
       .IsRequired();

      builder.Property(h => h.Ansiedade)
       .HasColumnName("ansiedade")
       .HasDefaultValue(false)
       .IsRequired();

      builder.Property(h => h.OutrosDisturbiosEmocionais)
       .HasColumnName("outros_disturbios_emocionais")
       .HasColumnType("varchar(300)")
       .IsRequired(false);

      builder.Property(h => h.TratamentoOrtomolecular)
       .HasColumnName("tratamento_ortomolecular")
       .HasDefaultValue(false)
       .IsRequired();

      builder.Property(h => h.DescricaoTratamentosortomolecular)
       .HasColumnName("descricao_tratamentos_ortomolecular")
       .HasColumnType("varchar(300)")
       .IsRequired(false);

      builder.Property(h => h.Fumante)
       .HasColumnName("fumante")
       .HasDefaultValue(false)
       .IsRequired();

      builder.Property(h => h.CuidadosEstéticos)
       .HasColumnName("cuidados_esteticos")
       .HasDefaultValue(false)
       .IsRequired();

      builder.Property(h => h.DescricaoCuidadosEsteticos)
       .HasColumnName("descricao_cuidados_esteticos")
       .HasColumnType("varchar(300)")
       .IsRequired(false);

      builder.Property(h => h.TratamentoMedico)
       .HasColumnName("tratamento_medico")
       .HasDefaultValue(false)
       .IsRequired();

      builder.Property(h => h.DescricaoTratamentoMedico)
       .HasColumnName("descricao_tratamento_medico")
       .HasColumnType("varchar(300)")
       .IsRequired(false);

      builder.Property(h => h.UsoAcidoPele)
       .HasColumnName("uso_acido_pele")
       .HasDefaultValue(false)
       .IsRequired();

      builder.Property(h => h.QualAcido)
       .HasColumnName("qual_acido")
       .HasColumnType("varchar(300)")
       .IsRequired(false);

      builder.Property(h => h.GestanteOuAmamentando)
       .HasColumnName("gestante_ou_amamentando")
       .HasDefaultValue(false)
       .IsRequired();

      builder.Property(h => h.ProblemaCardiaco)
       .HasColumnName("problema_cardiaco")
       .HasDefaultValue(false)
       .IsRequired();

      builder.Property(h => h.QualProblemaCardiaco)
       .HasColumnName("qual_problema_cardiaco")
       .HasColumnType("varchar(300)")
       .IsRequired(false);

      builder.Property(h => h.IntoleranciaLactose)
       .HasColumnName("intolerante_lactose")
       .HasDefaultValue(false)
       .IsRequired();

      builder.Property(h => h.Diabetes)
       .HasColumnName("diabetes")
       .HasDefaultValue(false)
       .IsRequired();

      builder.Property(h => h.AlergiaOvo)
       .HasColumnName("alergia_ovo")
       .HasDefaultValue(false)
       .IsRequired();

      builder.Property(h => h.InformacoesComplementares)
       .HasColumnName("informacoes_complementares")
       .HasColumnType("varchar(max)")
       .IsRequired(false);





      // 🔗 Relacionamento: cada histórico pertence a uma pessoa
      builder.HasOne(h => h.CadPessoa)
          .WithMany(p => p.CadPessoaHistoricoList)
          .HasForeignKey(h => h.PessoaId) // cria a FK no banco
          .OnDelete(DeleteBehavior.Cascade); // opcional: exclui históricos ao excluir pessoa
    }
  }
}