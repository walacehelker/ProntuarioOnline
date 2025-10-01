using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Configuration.Migrations
{
    /// <inheritdoc />
    public partial class adicionandoUsuarioProprietario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsuarioProprietarioId",
                table: "pt_botox",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioProprietarioId",
                table: "pt_bioestimulador",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioProprietarioId",
                table: "cad_pessoas_historicos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioProprietarioId",
                table: "cad_pessoas",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuarioProprietarioId",
                table: "pt_botox");

            migrationBuilder.DropColumn(
                name: "UsuarioProprietarioId",
                table: "pt_bioestimulador");

            migrationBuilder.DropColumn(
                name: "UsuarioProprietarioId",
                table: "cad_pessoas_historicos");

            migrationBuilder.DropColumn(
                name: "UsuarioProprietarioId",
                table: "cad_pessoas");
        }
    }
}
