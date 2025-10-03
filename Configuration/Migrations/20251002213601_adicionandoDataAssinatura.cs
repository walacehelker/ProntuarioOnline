using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Configuration.Migrations
{
    /// <inheritdoc />
    public partial class adicionandoDataAssinatura : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "data_procedimento",
                table: "pt_preenchimentos_faciais",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddColumn<DateTime>(
                name: "data_assinatura",
                table: "pt_preenchimentos_faciais",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_validade",
                table: "pt_botox",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_procedimento",
                table: "pt_botox",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_diluicao",
                table: "pt_botox",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "data_assinatura",
                table: "pt_botox",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_procedimento",
                table: "pt_bioestimulador",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddColumn<DateTime>(
                name: "data_assinatura",
                table: "pt_bioestimulador",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "data_assinatura",
                table: "pt_preenchimentos_faciais");

            migrationBuilder.DropColumn(
                name: "data_assinatura",
                table: "pt_botox");

            migrationBuilder.DropColumn(
                name: "data_assinatura",
                table: "pt_bioestimulador");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_procedimento",
                table: "pt_preenchimentos_faciais",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_validade",
                table: "pt_botox",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_procedimento",
                table: "pt_botox",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_diluicao",
                table: "pt_botox",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_procedimento",
                table: "pt_bioestimulador",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
