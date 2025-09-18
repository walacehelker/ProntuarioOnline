using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Configuration.Migrations
{
    /// <inheritdoc />
    public partial class migrationInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cad_pessoas",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(50)", nullable: false),
                    nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    nome_social = table.Column<string>(type: "varchar(200)", nullable: true),
                    data_nascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cpf = table.Column<string>(type: "varchar(20)", nullable: false),
                    data_insercao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    excluido = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    excluido_em = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cad_pessoas", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cad_pessoas");
        }
    }
}
