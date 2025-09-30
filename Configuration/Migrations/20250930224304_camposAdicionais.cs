using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Configuration.Migrations
{
    /// <inheritdoc />
    public partial class camposAdicionais : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PdfAssinado",
                table: "pt_bioestimulador",
                newName: "pdf_assinado");

            migrationBuilder.AddColumn<bool>(
                name: "aceita_compartilhamento_dados",
                table: "pt_bioestimulador",
                type: "bit",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "aceita_divulgacao",
                table: "pt_bioestimulador",
                type: "bit",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "aceita_divulgacao_congresso",
                table: "pt_bioestimulador",
                type: "bit",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "observacoes",
                table: "pt_bioestimulador",
                type: "varchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "aceita_compartilhamento_dados",
                table: "pt_bioestimulador");

            migrationBuilder.DropColumn(
                name: "aceita_divulgacao",
                table: "pt_bioestimulador");

            migrationBuilder.DropColumn(
                name: "aceita_divulgacao_congresso",
                table: "pt_bioestimulador");

            migrationBuilder.DropColumn(
                name: "observacoes",
                table: "pt_bioestimulador");

            migrationBuilder.RenameColumn(
                name: "pdf_assinado",
                table: "pt_bioestimulador",
                newName: "PdfAssinado");
        }
    }
}
