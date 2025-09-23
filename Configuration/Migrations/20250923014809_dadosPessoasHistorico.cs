using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Configuration.Migrations
{
    /// <inheritdoc />
    public partial class dadosPessoasHistorico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cad_pessoas_historicos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    queixa = table.Column<string>(type: "varchar(max)", nullable: false),
                    diagnostico_clinico = table.Column<string>(type: "varchar(max)", nullable: false),
                    antecedentes_patologicos = table.Column<string>(type: "varchar(max)", nullable: false),
                    antecedentes_familiares = table.Column<string>(type: "varchar(max)", nullable: false),
                    id_pessoa = table.Column<string>(type: "varchar(50)", nullable: false),
                    DataInsercao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Excluido = table.Column<bool>(type: "bit", nullable: false),
                    ExcluidoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cad_pessoas_historicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cad_pessoas_historicos_cad_pessoas_id_pessoa",
                        column: x => x.id_pessoa,
                        principalTable: "cad_pessoas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cad_pessoas_historicos_id_pessoa",
                table: "cad_pessoas_historicos",
                column: "id_pessoa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cad_pessoas_historicos");
        }
    }
}
