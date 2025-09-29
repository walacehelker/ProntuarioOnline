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
          page.Margin(30);
          page.PageColor(Colors.Grey.Lighten5);

          // Cabe�alho
          page.Header().Column(headerCol =>
          {
            // Linha com informa��es e logo
            headerCol.Item().Row(row =>
            {
              row.RelativeColumn().Column(col =>
              {
                col.Item().Text("Dr. Kamila Friedrich").Bold().FontSize(18);
                col.Item().Text("Especialista em Harmoniza��o Facial e Intercorr�ncias");
                col.Item().Text("Tel: (27) 99743-2716");
              });

              row.ConstantColumn(80).Height(80)
                 .Background(Colors.Grey.Lighten3)
                 .AlignCenter().AlignMiddle().Text("LOGO");
            });

            // Logo abaixo, o t�tulo do termo
            headerCol.Item().PaddingTop(10).Text("Termo de Consentimento")
                .Bold().FontSize(20).AlignCenter();
          });


          // Conte�do
          page.Content().Column(col =>
          {
            void AddSection(string titulo, Action<IContainer> content)
            {
              col.Item().PaddingBottom(18).Element(section =>
              {
                section
                    .Background("#FFDAD1")
                    .Border(1).BorderColor(Colors.Grey.Lighten2)
                    .Padding(16)
                    .Column(c =>
                    {
                      c.Spacing(10);
                      c.Item().Text(titulo).Bold().FontSize(14).FontColor(Colors.Blue.Medium);
                      c.Item().Element(content);
                    });
              });
            }

            AddSection("Toxina Botul�nica", c =>
            {
              c.Column(col =>
              {
                col.Item().Text("Declaro estar ciente e concordo em realizar o procedimento de aplica��o de toxina botul�nica conforme orienta��o e esclarecimentos prestados pelo(a) profissional respons�vel.")
                    .FontSize(12);

                col.Item().Text("Declaro, tamb�m, que recebi informa��es adequadas sobre a aplica��o da toxina botul�nica e suas poss�veis complica��es, riscos e benef�cios.")
                    .FontSize(12);

                col.Item().Text("Declaro que fui informado de que a fraqueza muscular come�a ap�s 24 horas da aplica��o, clinicamente sendo observada entre 2 a 7 dias da aplica��o, completando o efeito m�ximo em 15 dias. Estou ciente de que a dura��o do efeito � de 2 a 6 meses, com m�dia de 4 meses.")
                    .FontSize(12).Bold();

                col.Item().Text("Entendo que a toxina botul�nica � um medicamento injet�vel usado para tratar determinadas condi��es m�dicas, tais como rugas faciais, dist�rbios neurol�gicos e hiperidrose, entre outras.")
                    .FontSize(12);
              });
            });

            AddSection("Ao assinar esse termo reconhe�o e concordo com os seguintes pontos:", c =>
            {
              c.Column(col =>
              {
                col.Item().Text(text =>
                {
                  text.Span("Natureza do procedimento: ").Bold();
                  text.Span("Compreendo que a aplica��o de toxina botul�nica ser� feita atrav�s de inje��es nas �reas espec�ficadas acordadas com o(a) profissional respons�vel, com o objetivo de melhorar ou tratar a condi��o mencionada.").FontSize(12);
                });

                col.Item().Text(text =>
                {
                  text.Span("Benef�cios e resultado esperados: ").Bold();
                  text.Span("Fui informado de que os benef�cios da aplica��o de toxina botul�nica podem incluir a redu��o das rugas e linhas de express�o, melhora dos sintomas de dist�rbios neurol�gicos, redu��o da sudorese excessiva entre outros tratamentos discutidos com o(a) profissional. No entanto, entendo que os resultados podem variar de pessoa para pessoa, e n�o h� garantia de resultados completos ou permanentes.").FontSize(12);
                });

                col.Item().Text(text =>
                {
                  text.Span("Reconhe�o que existem fatores que interferem na dura��o da toxina, como: ").Bold();
                  text.Span("A pr�tica de atividade f�sica, ser uma pessoa muito expressiva, uso de cortic�ides e antibi�ticos, tabagismo e exposi��o solar.").FontSize(12);
                });

                col.Item().Text(text =>
                {
                  text.Span("Esclarecimentos: ").Bold();
                  text.Span("Recebi a oportunidade de fazer perguntas sobre o procedimento, seus riscos e benef�cios e todas as minhas d�vidas foram respondidas satisfatoriamente.").FontSize(12);
                });
              });
            });

            AddSection("Riscos e complica��es", c =>
            {
              c.Column(col =>
              {
                col.Item().Text("Fui devidamente informado sobre os riscos associados � aplica��o de toxina botul�nica, que pode incluir, mas n�o se limitam a:")
                    .FontSize(12);

                col.Item().Text("� Rea��es al�rgicas, como coceira, vermelhid�o, incha�o ou erup��es cut�neas;")
                    .FontSize(12);

                col.Item().Text("� Hematomas, dor ou desconforto no local da inje��o;")
                    .FontSize(12);

                col.Item().Text("� Fraqueza muscular tempor�ria na �rea tratada;")
                    .FontSize(12);

                col.Item().Text("� Assimetria facial ou altera��es na express�o facial;")
                    .FontSize(12);

                col.Item().Text("� Infec��o no local da inje��o;")
                    .FontSize(12);

                col.Item().Text("� Outras complica��es poss�veis que me foram explicadas pelo(a) profissional;")
                    .FontSize(12);
              });
            });

            AddSection("Observa��es", c =>
            {
              c.Text(string.IsNullOrWhiteSpace(dados.Observacoes) ? "Nenhuma" : dados.Observacoes);
            });

            AddSection("Aceita Divulga��o", c =>
            {
              c.Text(dados.AceitaDivulgacao == true ? "Sim" : "N�o");
            });

            AddSection("Assinatura do Cliente", container =>
            {
              if (dados.PdfAssinado != null && dados.PdfAssinado.Length > 0)
              {
                container.AlignCenter().Width(200).Image(dados.PdfAssinado).FitWidth();
              }
              else
              {
                container.Text("Sem assinatura registrada.");
              }
            });
          });

          // Rodap�
          page.Footer().AlignCenter().Text($"Gerado em {DateTime.Now:dd/MM/yyyy HH:mm}");
        });
      });

      var bytes = pdf.GeneratePdf();
      return File(bytes, "application/pdf", "TermoBotox.pdf");
    }
  }
}