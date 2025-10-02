using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Configuration.Migrations
{
    /// <inheritdoc />
    public partial class preenchimentoFacial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pt_preenchimentos_faciais",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(50)", nullable: false),
                    id_pessoa = table.Column<string>(type: "varchar(50)", nullable: false),
                    data_procedimento = table.Column<DateTime>(type: "datetime", nullable: false),
                    observacoes = table.Column<string>(type: "varchar(500)", nullable: true),
                    assinatura_termo_consentimento = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    data_insercao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    excluido = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    excluido_em = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioProprietarioId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pt_preenchimentos_faciais", x => x.id);
                    table.ForeignKey(
                        name: "FK_pt_preenchimentos_faciais_cad_pessoas_id_pessoa",
                        column: x => x.id_pessoa,
                        principalTable: "cad_pessoas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pt_preenchimentos_faciais_relacao_aplicacao",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(50)", nullable: false),
                    id_preenchimento_facial = table.Column<string>(type: "varchar(50)", nullable: false),
                    data = table.Column<DateTime>(type: "datetime", nullable: false),
                    area_aplicacao = table.Column<string>(type: "varchar(250)", nullable: false),
                    quantidade = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    marca = table.Column<string>(type: "varchar(250)", nullable: false),
                    produto = table.Column<string>(type: "varchar(250)", nullable: false),
                    lote = table.Column<string>(type: "varchar(250)", nullable: false),
                    validade = table.Column<DateTime>(type: "datetime", nullable: false),
                    data_insercao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    excluido = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    excluido_em = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioProprietarioId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pt_preenchimentos_faciais_relacao_aplicacao", x => x.id);
                    table.ForeignKey(
                        name: "FK_pt_preenchimentos_faciais_relacao_aplicacao_pt_preenchimentos_faciais_id_preenchimento_facial",
                        column: x => x.id_preenchimento_facial,
                        principalTable: "pt_preenchimentos_faciais",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pt_preenchimentos_faciais_relacao_etiquetas",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(50)", nullable: false),
                    id_preenchimento_facial = table.Column<string>(type: "varchar(50)", nullable: false),
                    etiqueta_preenchedor = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    data_insercao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    excluido = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    excluido_em = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioProprietarioId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pt_preenchimentos_faciais_relacao_etiquetas", x => x.id);
                    table.ForeignKey(
                        name: "FK_pt_preenchimentos_faciais_relacao_etiquetas_pt_preenchimentos_faciais_id_preenchimento_facial",
                        column: x => x.id_preenchimento_facial,
                        principalTable: "pt_preenchimentos_faciais",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pt_preenchimentos_faciais_id_pessoa",
                table: "pt_preenchimentos_faciais",
                column: "id_pessoa");

            migrationBuilder.CreateIndex(
                name: "IX_pt_preenchimentos_faciais_relacao_aplicacao_id_preenchimento_facial",
                table: "pt_preenchimentos_faciais_relacao_aplicacao",
                column: "id_preenchimento_facial");

            migrationBuilder.CreateIndex(
                name: "IX_pt_preenchimentos_faciais_relacao_etiquetas_id_preenchimento_facial",
                table: "pt_preenchimentos_faciais_relacao_etiquetas",
                column: "id_preenchimento_facial");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pt_preenchimentos_faciais_relacao_aplicacao");

            migrationBuilder.DropTable(
                name: "pt_preenchimentos_faciais_relacao_etiquetas");

            migrationBuilder.DropTable(
                name: "pt_preenchimentos_faciais");
        }
    }
}
