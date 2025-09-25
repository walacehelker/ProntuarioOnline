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

          // 🔹 Fundo da página em bege claro
          page.PageColor(Colors.Grey.Lighten5); // bege bem clarinho

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
            // Função auxiliar para criar seções com fundo e bordas arredondadas
            void AddSection(string titulo, Action<IContainer> content)
            {
              col.Item().PaddingBottom(18).Element(section =>
              {
                section
                    .Background("#FFDAD1")                 // salmão pastel
                    .Border(1).BorderColor(Colors.Grey.Lighten2)
                    .Padding(16)
                    .Column(c =>
                    {
                      c.Spacing(10);                     // mais espaço entre itens
                      c.Item().Text(titulo).Bold().FontSize(14).FontColor(Colors.Blue.Medium);
                      c.Item().Element(content);
                    });
              });
            }

            // 🔹 Dados do Paciente
            AddSection("Dados do Paciente", container =>
            {
              container.Table(table =>
              {
                table.ColumnsDefinition(c =>
                {
                  c.RelativeColumn();
                  c.RelativeColumn();
                });

                void AddRow(string label, string value)
                {
                  table.Cell().Element(CellStyle).Text(label).Bold();
                  table.Cell().Element(CellStyle).Text(value ?? "-");
                }

                AddRow("Nome:", pessoa.Nome);
                AddRow("Data de Nascimento:", pessoa.DataNascimento?.ToString("dd/MM/yyyy"));
                AddRow("CPF:", pessoa.Cpf);
                AddRow("Telefone:", pessoa.Telefone);
                AddRow("Email:", pessoa.Email);
                AddRow("Cidade:", pessoa.Cidade);

                static IContainer CellStyle(IContainer container) =>
                    container.PaddingVertical(4).PaddingHorizontal(6);
              });
            });

            // 🔹 Histórico
            AddSection("Histórico / Hábitos de Vida", container =>
            {
              container.Column(hist =>
              {
                hist.Spacing(6); // mais espaço entre linhas
                hist.Item().Text(text =>{text.Span("Queixa: ").Bold();text.Span(pessoa.Queixa ?? "-");});

                hist.Item().Text(t => { t.Span("Diagnóstico Clínico: ").Bold(); t.Span(pessoa.DiagnosticoClinico ?? "-"); });
                hist.Item().Text(t => { t.Span("Antecedentes Patológicos: ").Bold(); t.Span(pessoa.AntecedentesPatologicos ?? "-"); });
                hist.Item().Text(t => { t.Span("Antecedentes Familiares: ").Bold(); t.Span(pessoa.AntecedentesFamiliares ?? "-"); });
                hist.Item().Text(t => { t.Span("Possui tratamento estético anterior? ").Bold(); t.Span(pessoa.PossuiTratamentoEsteticoAnterior ? "Sim" : "Não"); });

                if (pessoa.PossuiTratamentoEsteticoAnterior)
                {
                  hist.Item().Text(t => { t.Span("Toxina Botulínica: ").Bold(); t.Span(pessoa.ToxinixaBotulinica ? "Sim" : "Não"); });
                  hist.Item().Text(t => { t.Span("Preenchedores: ").Bold(); t.Span(pessoa.Preenchedores ? "Sim" : "Não"); });
                  hist.Item().Text(t => { t.Span("Outras: ").Bold(); t.Span(pessoa.TratamentoEsteticoAnterior ?? "-"); });
                  hist.Item().Text(t => { t.Span("Informações sobre a aplicação: ").Bold(); t.Span(pessoa.InformacoesSobreAplicacao ?? "-"); });
                  hist.Item().Text(t => { t.Span("Informações pós aplicação: ").Bold(); t.Span(pessoa.InformacoesPosAplicacao ?? "-"); });
                }

              });
            });

            // 🔹 Medicamentos
            AddSection("Medicamentos", container =>
            {
              container.Column(meds =>
              {
                meds.Spacing(6);

                // Pergunta principal
                meds.Item().Text(t =>
                {
                  t.Span("Atualmente toma algum medicamento? ").Bold();
                  t.Span(pessoa.Medicamentos ? "Sim" : "Não");
                });

                if (pessoa.Medicamentos)
                {
                  if (pessoa.AntiInfamatorio)meds.Item().Text(t => { t.Span("• ").Bold(); t.Span("Anti-inflamatório"); });
                  if (pessoa.Analgesico)meds.Item().Text(t => { t.Span("• ").Bold(); t.Span("Analgésico"); });
                  if (pessoa.RelaxanteMuscular)meds.Item().Text(t => { t.Span("• ").Bold(); t.Span("Relaxante muscular"); });
                  if (pessoa.Antibiotico)meds.Item().Text(t => { t.Span("• ").Bold(); t.Span("Antibiótico"); });
                  if (pessoa.Aminoglicosideos)meds.Item().Text(t => { t.Span("• ").Bold(); t.Span("Aminoglicosídeos"); });
                  if (pessoa.Penicilaminas)meds.Item().Text(t => { t.Span("• ").Bold(); t.Span("Penicilaminas"); });
                  if (pessoa.Quinolonas)meds.Item().Text(t => { t.Span("• ").Bold(); t.Span("Quinolonas"); });
                  if (pessoa.RepositoresHormonais)meds.Item().Text(t => { t.Span("• ").Bold(); t.Span("Repositores hormonais"); });
                  if (pessoa.Succinilcolina)meds.Item().Text(t => { t.Span("• ").Bold(); t.Span("Succinilcolina"); });
                  if (pessoa.BloqueadorCanalCalcio)meds.Item().Text(t => { t.Span("• ").Bold(); t.Span("Bloqueadores de canais de cálcio"); });
                  if (!string.IsNullOrWhiteSpace(pessoa.OutrosMedicamentos))meds.Item().Text(t => { t.Span("• Outros: ").Bold(); t.Span(pessoa.OutrosMedicamentos); });
                }
              });
            });

            // 🔹 Informações Complementares
            AddSection("Informações Complementares", container =>
            {
              container.Column(info =>
              {
                info.Spacing(6);

                // Já existentes
                info.Item().Text(t => { t.Span("Costuma tomar sol? ").Bold(); t.Span(pessoa.TomaSol ? "Sim" : "Não"); });
                info.Item().Text(t => { t.Span("Pratica algum esporte? ").Bold(); t.Span(pessoa.PraticaEsporte ? "Sim" : "Não"); });
                if (!string.IsNullOrWhiteSpace(pessoa.Esportes))
                  info.Item().Text(t => { t.Span("• Esportes: ").Bold(); t.Span(pessoa.Esportes); });

                // 🔹 Novos campos
                info.Item().Text(t => { t.Span("Antecedentes alérgicos? ").Bold(); t.Span(pessoa.AntecedentesAlergicos ? "Sim" : "Não"); });
                if (!string.IsNullOrWhiteSpace(pessoa.Alergias))
                  info.Item().Text(t => { t.Span("• Alergias: ").Bold(); t.Span(pessoa.Alergias); });

                info.Item().Text(t => { t.Span("Stresse? ").Bold(); t.Span(pessoa.Stresse ? "Sim" : "Não"); });
                info.Item().Text(t => { t.Span("Ansiedade? ").Bold(); t.Span(pessoa.Ansiedade ? "Sim" : "Não"); });
                if (!string.IsNullOrWhiteSpace(pessoa.OutrosDisturbiosEmocionais))
                  info.Item().Text(t => { t.Span("Outros distúrbios emocionais: ").Bold(); t.Span(pessoa.OutrosDisturbiosEmocionais); });

                info.Item().Text(t => { t.Span("Já fez tratamento ortomolecular? ").Bold(); t.Span(pessoa.TratamentoOrtomolecular ? "Sim" : "Não"); });
                if (!string.IsNullOrWhiteSpace(pessoa.DescricaoTratamentosortomolecular))
                  info.Item().Text(t => { t.Span("• Tratamento ortomolecular: ").Bold(); t.Span(pessoa.DescricaoTratamentosortomolecular); });

                info.Item().Text(t => { t.Span("É fumante? ").Bold(); t.Span(pessoa.Fumante ? "Sim" : "Não"); });

                info.Item().Text(t => { t.Span("Cuidados estéticos? ").Bold(); t.Span(pessoa.CuidadosEstéticos ? "Sim" : "Não"); });
                if (!string.IsNullOrWhiteSpace(pessoa.DescricaoCuidadosEsteticos))
                  info.Item().Text(t => { t.Span("• Cuidados estéticos: ").Bold(); t.Span(pessoa.DescricaoCuidadosEsteticos); });

                info.Item().Text(t => { t.Span("Fez algum tratamento médico? ").Bold(); t.Span(pessoa.TratamentoMedico ? "Sim" : "Não"); });
                if (!string.IsNullOrWhiteSpace(pessoa.DescricaoTratamentoMedico))
                  info.Item().Text(t => { t.Span("• Tratamento médico: ").Bold(); t.Span(pessoa.DescricaoTratamentoMedico); });

                info.Item().Text(t => { t.Span("Usa ou já usou ácido na pele? ").Bold(); t.Span(pessoa.UsoAcidoPele ? "Sim" : "Não"); });
                if (!string.IsNullOrWhiteSpace(pessoa.QualAcido))
                  info.Item().Text(t => { t.Span("• Qual ácido: ").Bold(); t.Span(pessoa.QualAcido); });

                info.Item().Text(t => { t.Span("É gestante ou está amamentando? ").Bold(); t.Span(pessoa.GestanteOuAmamentando ? "Sim" : "Não"); });

                info.Item().Text(t => { t.Span("Possui algum problema cardíaco? ").Bold(); t.Span(pessoa.ProblemaCardiaco ? "Sim" : "Não"); });
                if (!string.IsNullOrWhiteSpace(pessoa.QualProblemaCardiaco))
                  info.Item().Text(t => { t.Span("• Problema cardíaco: ").Bold(); t.Span(pessoa.QualProblemaCardiaco); });

                info.Item().Text(t => { t.Span("Possui intolerância à lactose? ").Bold(); t.Span(pessoa.IntoleranciaLactose ? "Sim" : "Não"); });
                info.Item().Text(t => { t.Span("Tem diabetes? ").Bold(); t.Span(pessoa.Diabetes ? "Sim" : "Não"); });
                info.Item().Text(t => { t.Span("Possui alergia a proteína do ovo (Albumina)? ").Bold(); t.Span(pessoa.AlergiaOvo ? "Sim" : "Não"); });

                if (!string.IsNullOrWhiteSpace(pessoa.InformacoesComplementares))
                  info.Item().Text(t => { t.Span("Outras informações: ").Bold(); t.Span(pessoa.InformacoesComplementares); });
              });
            });

            // 🔹 Assinatura
            AddSection("Assinatura do Cliente", container =>
            {
              if (pessoa.PdfAssinado != null && pessoa.PdfAssinado.Length > 0)
              {
                container.AlignCenter().Width(200).Image(pessoa.PdfAssinado).FitWidth();
              }
              else
              {
                container.Text("Sem assinatura registrada.");
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