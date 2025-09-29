using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Configuration.Migrations
{
    /// <inheritdoc />
    public partial class prontuarioDoBotox : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pt_botox",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(50)", nullable: false),
                    id_pessoa = table.Column<string>(type: "varchar(50)", nullable: false),
                    data_procedimento = table.Column<DateTime>(type: "datetime", nullable: false),
                    marca_produto = table.Column<string>(type: "varchar(200)", nullable: true),
                    data_diluicao = table.Column<DateTime>(type: "datetime", nullable: true),
                    volume_diluicao = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    numero_lote = table.Column<string>(type: "varchar(100)", nullable: true),
                    data_validade = table.Column<DateTime>(type: "datetime", nullable: true),
                    frontal = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    procero = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    nasal = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    depressor_septo_nasal = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    orbicular_boca = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    depressor_angulo_boca_direito = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    depressor_angulo_boca_esquerdo = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    corrugador_direito = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    corrugador_esquerdo = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    levantador_labio_superior_direito = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    levantador_labio_superior_esquerdo = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    levantador_labio_superior_asa_nariz_direita = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    levantador_labio_superior_asa_nariz_esquerdo = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    risorio_direito = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    risorio_esquerdo = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    zigomatico_maior_direito = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    zigomatico_maior_esquerdo = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    zigomatico_menor_direito = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    zigomatico_menor_esquerdo = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    orbicular_olho_direito = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    orbicular_olho_esquerdo = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    mentoniano_direito = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    mentoniano_esquerdo = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    platisma_direito = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    platisma_esquerdo = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    depressor_labio_inferior_direito = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    depressor_labio_inferior_esquerdo = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    masseter_direito = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    masseter_esquerdo = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    total_utilizado = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    data_insercao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    excluido = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    excluido_em = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pt_botox", x => x.id);
                    table.ForeignKey(
                        name: "FK_pt_botox_cad_pessoas_id_pessoa",
                        column: x => x.id_pessoa,
                        principalTable: "cad_pessoas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pt_botox_id_pessoa",
                table: "pt_botox",
                column: "id_pessoa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pt_botox");
        }
    }
}
