using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using Services.Cadastro;

namespace ProntuarioOnline.Areas.Cadastral.Pages
{
  public class CadPessoasGerarPdfModel : PageModel
  {
    private readonly IPessoaCadService _pessoaCadService;

    public CadPessoasGerarPdfModel(IPessoaCadService pessoaCadService)
    {
      _pessoaCadService = pessoaCadService;
    }

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
      var pessoa = await _pessoaCadService.GetByIdAsync(id);
      if (pessoa == null) return NotFound();

      var pdf = Document.Create(container =>
      {
        container.Page(page =>
        {
          page.Margin(30);

          // 🔹 Cabeçalho
          page.Header().Row(row =>
          {
            row.RelativeColumn().Column(col =>
            {
              col.Item().Text("Dr. Kamila Friedrich").Bold().FontSize(18);
              col.Item().Text("Especialista em Harmonização Facial e Intercorrências");
              col.Item().Text("Tel: (27) 99743-2716");
            });
            row.ConstantColumn(80).Height(80).Background(Colors.Grey.Lighten3)
               .AlignCenter().AlignMiddle().Text("LOGO");
          });

          // 🔹 Conteúdo
          page.Content().Column(col =>
          {
            // 🔹 Dados do paciente
            col.Item().PaddingVertical(15).Text("Dados do Paciente")
                .Bold().FontSize(14).FontColor(Colors.Blue.Medium);

            col.Item().Table(table =>
            {
              table.ColumnsDefinition(c =>
              {
                c.RelativeColumn();
                c.RelativeColumn();
              });

              void AddRow(string label, string value)
              {
                table.Cell().Element(CellStyle).Text(label).SemiBold();
                table.Cell().Element(CellStyle).Text(value ?? "-");
              }

              AddRow("Nome:", pessoa.Nome);
              AddRow("Data de Nascimento:", pessoa.DataNascimento?.ToString("dd/MM/yyyy"));
              AddRow("CPF:", pessoa.Cpf);
              AddRow("Telefone:", pessoa.Telefone);
              AddRow("Email:", pessoa.Email);
              AddRow("Cidade:", pessoa.Cidade);

              static IContainer CellStyle(IContainer container) =>
                  container.PaddingVertical(3).PaddingHorizontal(5);
            });

            col.Item()
   .PaddingVertical(10)
   .Element(e => e.BorderBottom(1).BorderColor(Colors.Grey.Lighten2));


            // 🔹 Histórico
            col.Item().PaddingVertical(15).Text("Histórico / Hábitos de Vida")
                .Bold().FontSize(14).FontColor(Colors.Blue.Medium);

            col.Item().Column(hist =>
            {
              hist.Item().PaddingBottom(5).Text($"Queixa: {pessoa.Queixa}");
              hist.Item().PaddingBottom(5).Text($"Diagnóstico Clínico: {pessoa.DiagnosticoClinico}");
              hist.Item().PaddingBottom(5).Text($"Antecedentes Patológicos: {pessoa.AntecedentesPatologicos}");
              hist.Item().PaddingBottom(5).Text($"Antecedentes Familiares: {pessoa.AntecedentesFamiliares}");

              hist.Item().PaddingBottom(5).Text($"Possui tratamento estético anterior? {(pessoa.PossuiTratamentoEsteticoAnterior ? "Sim" : "Não")}");
              hist.Item().PaddingBottom(5).Text($"Toxina Botulínica: {(pessoa.ToxinixaBotulinica ? "Sim" : "Não")}");
              hist.Item().PaddingBottom(5).Text($"Preenchedores: {(pessoa.Preenchedores ? "Sim" : "Não")}");
              hist.Item().PaddingBottom(5).Text($"Outras: {pessoa.TratamentoEsteticoAnterior}");

              hist.Item().PaddingBottom(5).Text($"Informações sobre a aplicação: {pessoa.InformacoesSobreAplicacao}");
              hist.Item().PaddingBottom(5).Text($"Informações pós aplicação: {pessoa.InformacoesPosAplicacao}");
            });

            col.Item()
             .PaddingVertical(10)
             .Element(e => e.BorderBottom(1).BorderColor(Colors.Grey.Lighten2));


            // 🔹 Medicamentos
            col.Item().PaddingVertical(15).Text("Medicamentos")
                .Bold().FontSize(14).FontColor(Colors.Blue.Medium);

            col.Item().Column(meds =>
            {
              meds.Item().PaddingBottom(5).Text($"Atualmente toma algum medicamento? {(pessoa.Medicamentos ? "Sim" : "Não")}");

              if (pessoa.Medicamentos)
              {
                if (pessoa.AntiInfamatorio) meds.Item().PaddingBottom(5).Text("• Anti-inflamatório");
                if (pessoa.Analgesico) meds.Item().PaddingBottom(5).Text("• Analgésico");
                if (pessoa.RelaxanteMuscular) meds.Item().PaddingBottom(5).Text("• Relaxante muscular");
                if (pessoa.Antibiotico) meds.Item().PaddingBottom(5).Text("• Antibiótico");
                if (pessoa.Aminoglicosideos) meds.Item().PaddingBottom(5).Text("• Aminoglicosídeos");
                if (pessoa.Penicilaminas) meds.Item().PaddingBottom(5).Text("• Penicilaminas");
                if (pessoa.Quinolonas) meds.Item().PaddingBottom(5).Text("• Quinolonas");
                if (pessoa.RepositoresHormonais) meds.Item().PaddingBottom(5).Text("• Repositores hormonais");
                if (pessoa.Succinilcolina) meds.Item().PaddingBottom(5).Text("• Succinilcolina");
                if (pessoa.BloqueadorCanalCalcio) meds.Item().PaddingBottom(5).Text("• Bloqueadores de canais de cálcio");

                if (!string.IsNullOrWhiteSpace(pessoa.OutrosMedicamentos))
                  meds.Item().PaddingBottom(5).Text($"• Outros: {pessoa.OutrosMedicamentos}");
              }
            });

            col.Item()
   .PaddingVertical(10)
   .Element(e => e.BorderBottom(1).BorderColor(Colors.Grey.Lighten2));


            // 🔹 Informações Complementares
            col.Item().ShowEntire().Column(section =>
            {
              // 🔹 Título
              section.Item().PaddingVertical(15)
                  .Text("Informações Complementares")
                  .Bold().FontSize(14).FontColor(Colors.Blue.Medium);

              // 🔹 Conteúdo
              section.Item().Column(info =>
              {
                info.Item().PaddingBottom(5).Text($"Costuma tomar sol? {(pessoa.TomaSol ? "Sim" : "Não")}");
                info.Item().PaddingBottom(5).Text($"Pratica algum esporte? {(pessoa.PraticaEsporte ? "Sim" : "Não")}");
                if (!string.IsNullOrWhiteSpace(pessoa.Esportes))
                  info.Item().PaddingBottom(5).Text($"• Esportes: {pessoa.Esportes}");

                info.Item().PaddingBottom(5).Text($"Antecedentes alérgicos? {(pessoa.AntecedentesAlergicos ? "Sim" : "Não")}");
                if (!string.IsNullOrWhiteSpace(pessoa.Alergias))
                  info.Item().PaddingBottom(5).Text($"• Alergias: {pessoa.Alergias}");

                info.Item().PaddingBottom(5).Text($"Stresse? {(pessoa.Stresse ? "Sim" : "Não")}");
                info.Item().PaddingBottom(5).Text($"Ansiedade? {(pessoa.Ansiedade ? "Sim" : "Não")}");
                if (!string.IsNullOrWhiteSpace(pessoa.OutrosDisturbiosEmocionais))
                  info.Item().PaddingBottom(5).Text($"• Outros distúrbios emocionais: {pessoa.OutrosDisturbiosEmocionais}");

                info.Item().PaddingBottom(5).Text($"Já fez tratamento ortomolecular? {(pessoa.TratamentoOrtomolecular ? "Sim" : "Não")}");
                if (!string.IsNullOrWhiteSpace(pessoa.DescricaoTratamentosortomolecular))
                  info.Item().PaddingBottom(5).Text($"• Tratamento ortomolecular: {pessoa.DescricaoTratamentosortomolecular}");

                info.Item().PaddingBottom(5).Text($"É fumante? {(pessoa.Fumante ? "Sim" : "Não")}");
                info.Item().PaddingBottom(5).Text($"Cuidados estéticos? {(pessoa.CuidadosEstéticos ? "Sim" : "Não")}");
                if (!string.IsNullOrWhiteSpace(pessoa.DescricaoCuidadosEsteticos))
                  info.Item().PaddingBottom(5).Text($"• Cuidados estéticos: {pessoa.DescricaoCuidadosEsteticos}");

                info.Item().PaddingBottom(5).Text($"Fez algum tratamento médico? {(pessoa.TratamentoMedico ? "Sim" : "Não")}");
                if (!string.IsNullOrWhiteSpace(pessoa.DescricaoTratamentoMedico))
                  info.Item().PaddingBottom(5).Text($"• Tratamento médico: {pessoa.DescricaoTratamentoMedico}");

                info.Item().PaddingBottom(5).Text($"Usa ou já usou ácido na pele? {(pessoa.UsoAcidoPele ? "Sim" : "Não")}");
                if (!string.IsNullOrWhiteSpace(pessoa.QualAcido))
                  info.Item().PaddingBottom(5).Text($"• Qual ácido: {pessoa.QualAcido}");

                info.Item().PaddingBottom(5).Text($"É gestante ou está amamentando? {(pessoa.GestanteOuAmamentando ? "Sim" : "Não")}");
                info.Item().PaddingBottom(5).Text($"Possui algum problema cardíaco? {(pessoa.ProblemaCardiaco ? "Sim" : "Não")}");
                if (!string.IsNullOrWhiteSpace(pessoa.QualProblemaCardiaco))
                  info.Item().PaddingBottom(5).Text($"• Problema cardíaco: {pessoa.QualProblemaCardiaco}");

                info.Item().PaddingBottom(5).Text($"Possui intolerância à lactose? {(pessoa.IntoleranciaLactose ? "Sim" : "Não")}");
                info.Item().PaddingBottom(5).Text($"Tem diabetes? {(pessoa.Diabetes ? "Sim" : "Não")}");
                info.Item().PaddingBottom(5).Text($"Possui alergia a proteína do ovo (Albumina)? {(pessoa.AlergiaOvo ? "Sim" : "Não")}");

                if (!string.IsNullOrWhiteSpace(pessoa.InformacoesComplementares))
                  info.Item().PaddingBottom(5).Text($"Outras informações: {pessoa.InformacoesComplementares}");
              });

              // 🔹 Linha divisória
              section.Item()
                  .PaddingVertical(10)
                  .Element(e => e.BorderBottom(1).BorderColor(Colors.Grey.Lighten2));
            });


            // 🔹 Assinatura
            col.Item().ShowEntire().Column(assin =>
            {
              // 🔹 Título
              assin.Item().PaddingTop(30)
                  .Text("Assinatura do Cliente:")
                  .Bold().FontSize(14);

              // 🔹 Conteúdo
              if (pessoa.PdfAssinado != null && pessoa.PdfAssinado.Length > 0)
              {
                assin.Item()
                    .AlignCenter()
                    .Width(200)
                    .Image(pessoa.PdfAssinado)
                    .FitWidth();
              }
              else
              {
                assin.Item().Text("Sem assinatura registrada.");
              }
            });
          });

          // 🔹 Rodapé
          page.Footer().AlignCenter().Text($"Gerado em {DateTime.Now:dd/MM/yyyy HH:mm}");
        });
      });

      var bytes = pdf.GeneratePdf();
      return File(bytes, "application/pdf", "FichaAnamnese.pdf");
    }
  }
}