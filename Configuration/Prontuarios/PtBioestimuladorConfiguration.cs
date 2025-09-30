using Domain.Cadastro;
using Domain.Prontuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Configuration.Prontuarios
{
  public class PtBioestimuladorConfiguration : BaseConfiguration<PtBioestimulador>
  {
    public override void Configure(EntityTypeBuilder<PtBioestimulador> builder)
    {

      // Configurações da classe base
      base.Configure(builder);

      // Nome da tabela
      builder.ToTable("pt_bioestimulador");


      // Chave estrangeira
      builder.Property(e => e.PessoaId)
             .HasColumnName("id_pessoa")
             .HasColumnType("varchar(50)")
             .IsRequired();

      builder.Property(e => e.DataProcedimento)
             .HasColumnName("data_procedimento")
             .HasColumnType("datetime")
             .IsRequired();

      builder.Property(e => e.TratamentoFace)
             .HasColumnName("tratamento_face")
             .HasDefaultValue(false)
             .IsRequired();


      builder.Property(e => e.AnguloMandibulaRadiesseLidocaina)
             .HasColumnName("angulo_mandibula_radiesse_lidocaina")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.AnguloMandibulaRadiesseDuo)
             .HasColumnName("angulo_mandibula_radiesse_duo")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.AnguloMandibulaDireita)
             .HasColumnName("angulo_mandibula_direita")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.AnguloMandibulaEsquerda)
             .HasColumnName("angulo_mandibula_esquerda")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.AnguloMandibulaQtdTotal)
             .HasColumnName("angulo_mandibula_quantidade_total")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.AnguloMandibulaDiluicao)
             .HasColumnName("angulo_mandibula_diluicao")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);


      builder.Property(e => e.LinhaMandibularRadiesseLidocaina)
             .HasColumnName("linha_mandibular_radiesse_lidocaina")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.LinhaMandibularRadiesseDuo)
             .HasColumnName("linha_mandibular_radiesse_duo")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.LinhaMandibularDireita)
             .HasColumnName("linha_mandibular_direita")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.LinhaMandibularEsquerda)
             .HasColumnName("linha_mandibular_esquerda")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.LinhaMandibularQtdTotal)
             .HasColumnName("linha_mandibular_quantidade_total")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.LinhaMandibularDiluicao)
             .HasColumnName("linha_mandibular_diluicao")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);


      builder.Property(e => e.RegiaoMentonianaRadiesseLidocaina)
             .HasColumnName("regiao_mentoniana_radiesse_lidocaina")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.RegiaoMentonianaRadiesseDuo)
             .HasColumnName("regiao_mentoniana_radiesse_duo")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.RegiaoMentonianaDireita)
             .HasColumnName("regiao_mentoniana_direita")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.RegiaoMentonianaEsquerda)
             .HasColumnName("regiao_mentoniana_esquerda")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.RegiaoMentonianaQtdTotal)
             .HasColumnName("regiao_mentoniana_quantidade_total")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.RegiaoMentonianaDiluicao)
             .HasColumnName("regiao_mentoniana_diluicao")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);


      builder.Property(e => e.RegiaoSubmalarRadiesseLidocaina)
             .HasColumnName("regiao_submalar_radiesse_lidocaina")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.RegiaoSubmalarRadiesseDuo)
             .HasColumnName("regiao_submalar_radiesse_duo")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.RegiaoSubmalarDireita)
             .HasColumnName("regiao_submalar_direita")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.RegiaoSubmalarEsquerda)
             .HasColumnName("regiao_submalar_esquerda")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.RegiaoSubmalarQtdTotal)
             .HasColumnName("regiao_submalar_quantidade_total")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.RegiaoSubmalarDiluicao)
             .HasColumnName("regiao_submalar_diluicao")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);


      builder.Property(e => e.RegiaoTemporalRadiesseLidocaina)
             .HasColumnName("regiao_temporal_radiesse_lidocaina")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.RegiaoTemporalRadiesseDuo)
             .HasColumnName("regiao_temporal_radiesse_duo")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.RegiaoTemporalDireita)
             .HasColumnName("regiao_temporal_direita")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.RegiaoTemporalEsquerda)
             .HasColumnName("regiao_temporal_esquerda")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.RegiaoTemporalQtdTotal)
             .HasColumnName("regiao_temporal_quantidade_total")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.RegiaoTemporalDiluicao)
             .HasColumnName("regiao_temporal_diluicao")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);


      builder.Property(e => e.SulcoLabiomentualRadiesseLidocaina)
             .HasColumnName("sulco_labiomentual_radiesse_lidocaina")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.SulcoLabiomentualRadiesseDuo)
             .HasColumnName("sulco_labiomentual_radiesse_duo")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.SulcoLabiomentualDireita)
             .HasColumnName("sulco_labiomentual_direita")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.SulcoLabiomentualEsquerda)
             .HasColumnName("sulco_labiomentual_esquerda")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.SulcoLabiomentualQtdTotal)
             .HasColumnName("sulco_labiomentual_quantidade_total")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.SulcoLabiomentualDiluicao)
             .HasColumnName("sulco_labiomentual_diluicao")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);


      builder.Property(e => e.SulcoNasolabialRadiesseLidocaina)
             .HasColumnName("sulca_nasolabial_radiesse_lidocaina")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.SulcoNasolabialRadiesseDuo)
             .HasColumnName("sulca_nasolabial_radiesse_duo")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.SulcoNasolabialDireita)
             .HasColumnName("sulca_nasolabial_direita")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.SulcoNasolabialEsquerda)
             .HasColumnName("sulca_nasolabial_esquerda")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.SulcoNasolabialQtdTotal)
             .HasColumnName("sulca_nasolabial_quantidade_total")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.SulcoNasolabialDiluicao)
             .HasColumnName("sulca_nasolabial_diluicao")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);



      builder.Property(e => e.TratamentoCorpo)
             .HasColumnName("tratamento_corpo")
             .HasDefaultValue(false)
             .IsRequired();


      builder.Property(e => e.AbdomenRadiesseDuo)
             .HasColumnName("abdomen_radiesse_lidocaina")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.AbdomenDireita)
             .HasColumnName("abdomen_direita")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.AbdomenEsquerda)
             .HasColumnName("abdomen_esquerda")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.AbdomenQtdTotal)
             .HasColumnName("abdomen_quantidade_total")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.AbdomenDiluicao)
             .HasColumnName("abdomen_diluicao")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);


      builder.Property(e => e.BracosRadiesseDuo)
             .HasColumnName("bracos_radiesse_lidocaina")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.BracosDireita)
             .HasColumnName("bracos_direita")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.BracosEsquerda)
             .HasColumnName("bracos_esquerda")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.BracosQtdTotal)
             .HasColumnName("bracos_quantidade_total")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.BracosDiluicao)
             .HasColumnName("bracos_diluicao")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);


      builder.Property(e => e.ColoRadiesseDuo)
             .HasColumnName("colo_radiesse_lidocaina")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.ColoDireita)
             .HasColumnName("colo_direita")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.ColoEsquerda)
             .HasColumnName("colo_esquerda")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.ColoQtdTotal)
             .HasColumnName("colo_quantidade_total")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.ColoDiluicao)
             .HasColumnName("colo_diluicao")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);


      builder.Property(e => e.CotovelosRadiesseDuo)
             .HasColumnName("cotovelos_radiesse_lidocaina")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.CotovelosDireita)
             .HasColumnName("cotovelos_direita")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.CotovelosEsquerda)
             .HasColumnName("cotovelos_esquerda")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.CotovelosQtdTotal)
             .HasColumnName("cotovelos_quantidade_total")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.CotovelosDiluicao)
             .HasColumnName("cotovelos_diluicao")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);


      builder.Property(e => e.CoxasRadiesseDuo)
             .HasColumnName("coxas_radiesse_lidocaina")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.CoxasDireita)
             .HasColumnName("coxas_direita")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.CoxasEsquerda)
             .HasColumnName("coxas_esquerda")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.CoxasQtdTotal)
             .HasColumnName("coxas_quantidade_total")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.CoxasDiluicao)
             .HasColumnName("coxas_diluicao")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);


      builder.Property(e => e.GluteosRadiesseDuo)
             .HasColumnName("gluteos_radiesse_lidocaina")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.GluteosDireita)
             .HasColumnName("gluteos_direita")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.GluteosEsquerda)
             .HasColumnName("gluteos_esquerda")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.GluteosQtdTotal)
             .HasColumnName("gluteos_quantidade_total")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.GluteosDiluicao)
             .HasColumnName("gluteos_diluicao")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);


      builder.Property(e => e.JoelhoRadiesseDuo)
             .HasColumnName("joelho_radiesse_lidocaina")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.JoelhoDireita)
             .HasColumnName("joelho_direita")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.JoelhoEsquerda)
             .HasColumnName("joelho_esquerda")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.JoelhoQtdTotal)
             .HasColumnName("joelho_quantidade_total")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.JoelhoDiluicao)
             .HasColumnName("joelho_diluicao")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);


      builder.Property(e => e.MaosRadiesseDuo)
             .HasColumnName("maos_radiesse_lidocaina")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.MaosDireita)
             .HasColumnName("maos_direita")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.MaosEsquerda)
             .HasColumnName("maos_esquerda")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.MaosQtdTotal)
             .HasColumnName("maos_quantidade_total")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.MaosDiluicao)
             .HasColumnName("maos_diluicao")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);


      builder.Property(e => e.PescocoRadiesseDuo)
             .HasColumnName("pescoco_radiesse_lidocaina")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.PescocoDireita)
             .HasColumnName("pescoco_direita")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.PescocoEsquerda)
             .HasColumnName("pescoco_esquerda")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.PescocoQtdTotal)
             .HasColumnName("pescoco_quantidade_total")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);

      builder.Property(e => e.PescocoDiluicao)
             .HasColumnName("pescoco_diluicao")
             .HasColumnType("decimal(10,2)")
             .IsRequired(false);


      builder.HasOne(h => h.CadPessoa)
          .WithMany(p => p.PtBioestimuladorList)
          .HasForeignKey(h => h.PessoaId)
          .OnDelete(DeleteBehavior.Cascade);
    }
  }
}
