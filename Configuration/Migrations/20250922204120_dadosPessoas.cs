using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Configuration.Migrations
{
    /// <inheritdoc />
    public partial class dadosPessoas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "bairro",
                table: "cad_pessoas",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "cep",
                table: "cad_pessoas",
                type: "varchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "cidade",
                table: "cad_pessoas",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "cad_pessoas",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "estado",
                table: "cad_pessoas",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "numero",
                table: "cad_pessoas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "rua",
                table: "cad_pessoas",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "telefone",
                table: "cad_pessoas",
                type: "varchar(20)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bairro",
                table: "cad_pessoas");

            migrationBuilder.DropColumn(
                name: "cep",
                table: "cad_pessoas");

            migrationBuilder.DropColumn(
                name: "cidade",
                table: "cad_pessoas");

            migrationBuilder.DropColumn(
                name: "email",
                table: "cad_pessoas");

            migrationBuilder.DropColumn(
                name: "estado",
                table: "cad_pessoas");

            migrationBuilder.DropColumn(
                name: "numero",
                table: "cad_pessoas");

            migrationBuilder.DropColumn(
                name: "rua",
                table: "cad_pessoas");

            migrationBuilder.DropColumn(
                name: "telefone",
                table: "cad_pessoas");
        }
    }
}
