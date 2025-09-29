using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using Services.Prontuarios;
using System.Threading.Tasks;

namespace ProntuarioOnline.Areas.Prontuarios.Pages
{
  public class GerarTermoBotoxPdfModel : PageModel
  {
    private readonly IPtBotoxCadService _ptBotoxCadService;

    public GerarTermoBotoxPdfModel(IPtBotoxCadService ptBotoxCadService)
    {
      _ptBotoxCadService = ptBotoxCadService;
    }

    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
      var dados = await _ptBotoxCadService.GetByIdAsync(id);
      if (dados == null) return NotFound();

      var pdf = Document.Create(container =>
      {
        container.Page(page =>
        {
          page.Margin(25); // margem um pouco menor
          page.PageColor(Colors.White); // fundo branco

          // 🔹 Cabeçalho
          page.Header().Column(headerCol =>
          {
            headerCol.Item().Row(row =>
            {
              row.RelativeColumn().Column(col =>
              {
                col.Item().Text("Dr. Kamila Friedrich").Bold().FontSize(15);
                col.Item().Text("Especialista em Harmonização Facial e Intercorrências").FontSize(11);
                col.Item().Text("Tel: (27) 99743-2716").FontSize(11);
              });

              row.ConstantColumn(60).Height(60)
                 .Background(Colors.Grey.Lighten3)
                 .AlignCenter().AlignMiddle().Text("LOGO").FontSize(9);
            });

            headerCol.Item().PaddingTop(5).Text("Termo de Consentimento")
                .Bold().FontSize(17).AlignCenter();
          });

          // 🔹 Conteúdo
          page.Content().Column(col =>
          {
            void AddSection(string titulo, Action<IContainer> content)
            {
              col.Item().PaddingBottom(10).Column(c =>
              {
                c.Spacing(3);
                c.Item().Text(titulo).Bold().FontSize(12);
                c.Item().Element(content);
              });
            }

            AddSection("Toxina Botulínica", c =>
            {
              c.Column(col =>
              {
                col.Item().Text("Declaro estar ciente e concordo em realizar o procedimento de aplicação de toxina botulínica conforme orientação e esclarecimentos prestados pelo(a) profissional responsável.")
                    .FontSize(10);

                col.Item().Text("Declaro, também, que recebi informações adequadas sobre a aplicação da toxina botulínica e suas possíveis complicações, riscos e benefícios.")
                    .FontSize(10);

                col.Item().Text("Declaro que fui informado de que a fraqueza muscular começa após 24 horas da aplicação, clinicamente sendo observada entre 2 a 7 dias da aplicação, completando o efeito máximo em 15 dias. Estou ciente de que a duração do efeito é de 2 a 6 meses, com média de 4 meses.")
                    .FontSize(10).Bold();

                col.Item().Text("Entendo que a toxina botulínica é um medicamento injetável usado para tratar determinadas condições médicas, tais como rugas faciais, distúrbios neurológicos e hiperidrose, entre outras.")
                    .FontSize(10);
              });
            });

            AddSection("Ao assinar esse termo reconheço e concordo com os seguintes pontos:", c =>
            {
              c.Column(col =>
              {
                col.Spacing(8); // espaço maior entre os itens

                col.Item().Text(t =>
                {
                  t.Span("Natureza do procedimento: ").Bold();
                  t.Span("Compreendo que a aplicação de toxina botulínica será feita através de injeções nas áreas específicadas acordadas com o(a) profissional responsável, com o objetivo de melhorar ou tratar a condição mencionada.").FontSize(10);
                });

                col.Item().Text(t =>
                {
                  t.Span("Benefícios e resultado esperados: ").Bold();
                  t.Span("Fui informado de que os benefícios da aplicação de toxina botulínica podem incluir a redução das rugas e linhas de expressão, melhora dos sintomas de distúrbios neurológicos, redução da sudorese excessiva entre outros tratamentos discutidos com o(a) profissional. No entanto, entendo que os resultados podem variar de pessoa para pessoa, e não há garantia de resultados completos ou permanentes.").FontSize(10);
                });

                col.Item().Text(t =>
                {
                  t.Span("Reconheço que existem fatores que interferem na duração da toxina, como: ").Bold();
                  t.Span("A prática de atividade física, ser uma pessoa muito expressiva, uso de corticóides e antibióticos, tabagismo e exposição solar.").FontSize(10);
                });

                col.Item().Text(t =>
                {
                  t.Span("Esclarecimentos: ").Bold();
                  t.Span("Recebi a oportunidade de fazer perguntas sobre o procedimento, seus riscos e benefícios e todas as minhas dúvidas foram respondidas satisfatoriamente.").FontSize(10);
                });
              });
            });

            AddSection("Riscos e complicações", c =>
            {
              c.Column(col =>
              {
                col.Item().Text("Fui devidamente informado sobre os riscos associados à aplicação de toxina botulínica, que pode incluir, mas não se limitam a:").FontSize(10);
                col.Item().Text("· Reações alérgicas, como coceira, vermelhidão, inchaço ou erupções cutâneas;").FontSize(10);
                col.Item().Text("· Hematomas, dor ou desconforto no local da injeção;").FontSize(10);
                col.Item().Text("· Fraqueza muscular temporária na área tratada;").FontSize(10);
                col.Item().Text("· Assimetria facial ou alterações na expressão facial;").FontSize(10);
                col.Item().Text("· Infecção no local da injeção;").FontSize(10);
                col.Item().Text("· Outras complicações possíveis que me foram explicadas pelo(a) profissional;").FontSize(10);
              });
            });

            AddSection("Observações", c =>
            {
              c.Text(string.IsNullOrWhiteSpace(dados.Observacoes) ? "Nenhuma" : dados.Observacoes).FontSize(10);
            });

            AddSection("Aceita Divulgação", c =>
            {
              c.Text(dados.AceitaDivulgacao == true ? "Sim" : "Não").FontSize(10);
            });

            AddSection("Assinatura do Cliente", container =>
            {
              if (dados.PdfAssinado != null && dados.PdfAssinado.Length > 0)
              {
                container.AlignCenter().Width(150).Image(dados.PdfAssinado).FitWidth();
              }
              else
              {
                container.Text("Sem assinatura registrada.").FontSize(10);
              }
            });
          });

          // 🔹 Rodapé
          page.Footer().AlignCenter().Text($"Gerado em {DateTime.Now:dd/MM/yyyy HH:mm}").FontSize(9);
        });
      });

      var bytes = pdf.GeneratePdf();
      return File(bytes, "application/pdf", "TermoBotox.pdf");
    }
  }
}