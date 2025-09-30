using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Configuration.Migrations
{
    /// <inheritdoc />
    public partial class bioestimuladores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pt_bioestimulador",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(50)", nullable: false),
                    id_pessoa = table.Column<string>(type: "varchar(50)", nullable: false),
                    data_procedimento = table.Column<DateTime>(type: "datetime", nullable: false),
                    tratamento_face = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    angulo_mandibula_radiesse_lidocaina = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    angulo_mandibula_radiesse_duo = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    angulo_mandibula_direita = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    angulo_mandibula_esquerda = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    angulo_mandibula_quantidade_total = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    angulo_mandibula_diluicao = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    linha_mandibular_radiesse_lidocaina = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    linha_mandibular_radiesse_duo = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    linha_mandibular_direita = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    linha_mandibular_esquerda = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    linha_mandibular_quantidade_total = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    linha_mandibular_diluicao = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    regiao_mentoniana_radiesse_lidocaina = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    regiao_mentoniana_radiesse_duo = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    regiao_mentoniana_direita = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    regiao_mentoniana_esquerda = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    regiao_mentoniana_quantidade_total = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    regiao_mentoniana_diluicao = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    regiao_submalar_radiesse_lidocaina = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    regiao_submalar_radiesse_duo = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    regiao_submalar_direita = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    regiao_submalar_esquerda = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    regiao_submalar_quantidade_total = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    regiao_submalar_diluicao = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    regiao_temporal_radiesse_lidocaina = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    regiao_temporal_radiesse_duo = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    regiao_temporal_direita = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    regiao_temporal_esquerda = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    regiao_temporal_quantidade_total = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    regiao_temporal_diluicao = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    sulco_labiomentual_radiesse_lidocaina = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    sulco_labiomentual_radiesse_duo = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    sulco_labiomentual_direita = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    sulco_labiomentual_esquerda = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    sulco_labiomentual_quantidade_total = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    sulco_labiomentual_diluicao = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    sulca_nasolabial_radiesse_lidocaina = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    sulca_nasolabial_radiesse_duo = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    sulca_nasolabial_direita = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    sulca_nasolabial_esquerda = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    sulca_nasolabial_quantidade_total = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    sulca_nasolabial_diluicao = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    tratamento_corpo = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    abdomen_radiesse_lidocaina = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    abdomen_direita = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    abdomen_esquerda = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    abdomen_quantidade_total = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    abdomen_diluicao = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    bracos_radiesse_lidocaina = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    bracos_direita = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    bracos_esquerda = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    bracos_quantidade_total = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    bracos_diluicao = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    colo_radiesse_lidocaina = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    colo_direita = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    colo_esquerda = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    colo_quantidade_total = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    colo_diluicao = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    cotovelos_radiesse_lidocaina = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    cotovelos_direita = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    cotovelos_esquerda = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    cotovelos_quantidade_total = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    cotovelos_diluicao = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    coxas_radiesse_lidocaina = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    coxas_direita = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    coxas_esquerda = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    coxas_quantidade_total = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    coxas_diluicao = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    gluteos_radiesse_lidocaina = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    gluteos_direita = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    gluteos_esquerda = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    gluteos_quantidade_total = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    gluteos_diluicao = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    joelho_radiesse_lidocaina = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    joelho_direita = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    joelho_esquerda = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    joelho_quantidade_total = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    joelho_diluicao = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    maos_radiesse_lidocaina = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    maos_direita = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    maos_esquerda = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    maos_quantidade_total = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    maos_diluicao = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    pescoco_radiesse_lidocaina = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    pescoco_direita = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    pescoco_esquerda = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    pescoco_quantidade_total = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    pescoco_diluicao = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    PdfAssinado = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    data_insercao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    excluido = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    excluido_em = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pt_bioestimulador", x => x.id);
                    table.ForeignKey(
                        name: "FK_pt_bioestimulador_cad_pessoas_id_pessoa",
                        column: x => x.id_pessoa,
                        principalTable: "cad_pessoas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pt_bioestimulador_id_pessoa",
                table: "pt_bioestimulador",
                column: "id_pessoa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pt_bioestimulador");
        }
    }
}
