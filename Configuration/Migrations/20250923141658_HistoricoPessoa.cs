using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Configuration.Migrations
{
    /// <inheritdoc />
    public partial class HistoricoPessoa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "alergia_ovo",
                table: "cad_pessoas_historicos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "alergias",
                table: "cad_pessoas_historicos",
                type: "varchar(300)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "aminoglicosideos",
                table: "cad_pessoas_historicos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "analgesico",
                table: "cad_pessoas_historicos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ansiedade",
                table: "cad_pessoas_historicos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "antecedentes_alergicos",
                table: "cad_pessoas_historicos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "anti_inflamatorio",
                table: "cad_pessoas_historicos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "antibiotico",
                table: "cad_pessoas_historicos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "bloqueador_canal_cacio",
                table: "cad_pessoas_historicos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "cuidados_esteticos",
                table: "cad_pessoas_historicos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "descricao_cuidados_esteticos",
                table: "cad_pessoas_historicos",
                type: "varchar(300)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "descricao_tratamento_medico",
                table: "cad_pessoas_historicos",
                type: "varchar(300)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "descricao_tratamentos_ortomolecular",
                table: "cad_pessoas_historicos",
                type: "varchar(300)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "diabetes",
                table: "cad_pessoas_historicos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "esportes",
                table: "cad_pessoas_historicos",
                type: "varchar(300)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "fumante",
                table: "cad_pessoas_historicos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "gestante_ou_amamentando",
                table: "cad_pessoas_historicos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "informacoes_complementares",
                table: "cad_pessoas_historicos",
                type: "varchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "informacoes_pos_aplicacao",
                table: "cad_pessoas_historicos",
                type: "varchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "informacoes_sobre_aplicacao",
                table: "cad_pessoas_historicos",
                type: "varchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "intolerante_lactose",
                table: "cad_pessoas_historicos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "medicamentos",
                table: "cad_pessoas_historicos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "outros_disturbios_emocionais",
                table: "cad_pessoas_historicos",
                type: "varchar(300)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "outros_medicamentos",
                table: "cad_pessoas_historicos",
                type: "varchar(300)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "penicilaminas",
                table: "cad_pessoas_historicos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "possui_tratamento_estetico_anterior",
                table: "cad_pessoas_historicos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "pratica_esporte",
                table: "cad_pessoas_historicos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "preenchedores",
                table: "cad_pessoas_historicos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "problema_cardiaco",
                table: "cad_pessoas_historicos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "qual_acido",
                table: "cad_pessoas_historicos",
                type: "varchar(300)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "qual_problema_cardiaco",
                table: "cad_pessoas_historicos",
                type: "varchar(300)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "quinolonas",
                table: "cad_pessoas_historicos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "relaxante_muscular",
                table: "cad_pessoas_historicos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "repositores_hormonais",
                table: "cad_pessoas_historicos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "stresse",
                table: "cad_pessoas_historicos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "succinilcolina",
                table: "cad_pessoas_historicos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "toma_sol",
                table: "cad_pessoas_historicos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "toxinia_botulinica",
                table: "cad_pessoas_historicos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "tratamento_estetico_anterior",
                table: "cad_pessoas_historicos",
                type: "varchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "tratamento_medico",
                table: "cad_pessoas_historicos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "tratamento_ortomolecular",
                table: "cad_pessoas_historicos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "uso_acido_pele",
                table: "cad_pessoas_historicos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "alergia_ovo",
                table: "cad_pessoas_historicos");

            migrationBuilder.DropColumn(
                name: "alergias",
                table: "cad_pessoas_historicos");

            migrationBuilder.DropColumn(
                name: "aminoglicosideos",
                table: "cad_pessoas_historicos");

            migrationBuilder.DropColumn(
                name: "analgesico",
                table: "cad_pessoas_historicos");

            migrationBuilder.DropColumn(
                name: "ansiedade",
                table: "cad_pessoas_historicos");

            migrationBuilder.DropColumn(
                name: "antecedentes_alergicos",
                table: "cad_pessoas_historicos");

            migrationBuilder.DropColumn(
                name: "anti_inflamatorio",
                table: "cad_pessoas_historicos");

            migrationBuilder.DropColumn(
                name: "antibiotico",
                table: "cad_pessoas_historicos");

            migrationBuilder.DropColumn(
                name: "bloqueador_canal_cacio",
                table: "cad_pessoas_historicos");

            migrationBuilder.DropColumn(
                name: "cuidados_esteticos",
                table: "cad_pessoas_historicos");

            migrationBuilder.DropColumn(
                name: "descricao_cuidados_esteticos",
                table: "cad_pessoas_historicos");

            migrationBuilder.DropColumn(
                name: "descricao_tratamento_medico",
                table: "cad_pessoas_historicos");

            migrationBuilder.DropColumn(
                name: "descricao_tratamentos_ortomolecular",
                table: "cad_pessoas_historicos");

            migrationBuilder.DropColumn(
                name: "diabetes",
                table: "cad_pessoas_historicos");

            migrationBuilder.DropColumn(
                name: "esportes",
                table: "cad_pessoas_historicos");

            migrationBuilder.DropColumn(
                name: "fumante",
                table: "cad_pessoas_historicos");

            migrationBuilder.DropColumn(
                name: "gestante_ou_amamentando",
                table: "cad_pessoas_historicos");

            migrationBuilder.DropColumn(
                name: "informacoes_complementares",
                table: "cad_pessoas_historicos");

            migrationBuilder.DropColumn(
                name: "informacoes_pos_aplicacao",
                table: "cad_pessoas_historicos");

            migrationBuilder.DropColumn(
                name: "informacoes_sobre_aplicacao",
                table: "cad_pessoas_historicos");

            migrationBuilder.DropColumn(
                name: "intolerante_lactose",
                table: "cad_pessoas_historicos");

            migrationBuilder.DropColumn(
                name: "medicamentos",
                table: "cad_pessoas_historicos");

            migrationBuilder.DropColumn(
                name: "outros_disturbios_emocionais",
                table: "cad_pessoas_historicos");

            migrationBuilder.DropColumn(
                name: "outros_medicamentos",
                table: "cad_pessoas_historicos");

            migrationBuilder.DropColumn(
                name: "penicilaminas",
                table: "cad_pessoas_historicos");

            migrationBuilder.DropColumn(
                name: "possui_tratamento_estetico_anterior",
                table: "cad_pessoas_historicos");

            migrationBuilder.DropColumn(
                name: "pratica_esporte",
                table: "cad_pessoas_historicos");

            migrationBuilder.DropColumn(
                name: "preenchedores",
                table: "cad_pessoas_historicos");

            migrationBuilder.DropColumn(
                name: "problema_cardiaco",
                table: "cad_pessoas_historicos");

            migrationBuilder.DropColumn(
                name: "qual_acido",
                table: "cad_pessoas_historicos");

            migrationBuilder.DropColumn(
                name: "qual_problema_cardiaco",
                table: "cad_pessoas_historicos");

            migrationBuilder.DropColumn(
                name: "quinolonas",
                table: "cad_pessoas_historicos");

            migrationBuilder.DropColumn(
                name: "relaxante_muscular",
                table: "cad_pessoas_historicos");

            migrationBuilder.DropColumn(
                name: "repositores_hormonais",
                table: "cad_pessoas_historicos");

            migrationBuilder.DropColumn(
                name: "stresse",
                table: "cad_pessoas_historicos");

            migrationBuilder.DropColumn(
                name: "succinilcolina",
                table: "cad_pessoas_historicos");

            migrationBuilder.DropColumn(
                name: "toma_sol",
                table: "cad_pessoas_historicos");

            migrationBuilder.DropColumn(
                name: "toxinia_botulinica",
                table: "cad_pessoas_historicos");

            migrationBuilder.DropColumn(
                name: "tratamento_estetico_anterior",
                table: "cad_pessoas_historicos");

            migrationBuilder.DropColumn(
                name: "tratamento_medico",
                table: "cad_pessoas_historicos");

            migrationBuilder.DropColumn(
                name: "tratamento_ortomolecular",
                table: "cad_pessoas_historicos");

            migrationBuilder.DropColumn(
                name: "uso_acido_pele",
                table: "cad_pessoas_historicos");
        }
    }
}
