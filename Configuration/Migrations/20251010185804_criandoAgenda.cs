using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Configuration.Migrations
{
    /// <inheritdoc />
    public partial class criandoAgenda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cad_agenda",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(50)", nullable: false),
                    nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    procedimento_agendado = table.Column<string>(type: "varchar(100)", nullable: true),
                    telefone = table.Column<string>(type: "varchar(200)", nullable: false),
                    data_insercao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    excluido = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    excluido_em = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioProprietarioId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cad_agenda", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cad_agenda");
        }
    }
}
