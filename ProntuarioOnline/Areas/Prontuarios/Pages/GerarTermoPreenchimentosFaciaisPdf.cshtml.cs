using Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using Services.Cadastro;
using Services.Prontuarios;

namespace ProntuarioOnline.Areas.Prontuarios.Pages
{
  public class GerarTermoPreenchimentoFacialPdfModel : PageModel
  {
    private readonly IPtPreenchimentoFacialCadService _ptPreenchimentoFacialCadService;
    private readonly IPessoaService _pessoaService;
    private readonly UserManager<ApplicationUser> _userManager;


    public GerarTermoPreenchimentoFacialPdfModel(IPtPreenchimentoFacialCadService ptPreenchimentoFacialCadService,
      IPessoaService pessoaService,
      UserManager<ApplicationUser> userManager)
    {
      _ptPreenchimentoFacialCadService = ptPreenchimentoFacialCadService;
      _pessoaService = pessoaService;
      _userManager = userManager;

    }

    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
      var dados = await _ptPreenchimentoFacialCadService.GetByIdAsync(id);
      if (dados == null) return NotFound();
      var pessoa = _pessoaService.GetById(dados.PessoaId);
      int? idade = null;

      if (pessoa.DataNascimento.HasValue)
      {
        var hoje = DateTime.Today;
        idade = hoje.Year - pessoa.DataNascimento.Value.Year;

        if (pessoa.DataNascimento.Value.Date > hoje.AddYears(-idade.Value))
          idade--;
      }
      var endereco = pessoa.Rua + ", " + pessoa.Numero + ", " + pessoa.Bairro;
      var user = await _userManager.GetUserAsync(User);
      var UsuarioLogado = user?.NomeCompleto;
      var assinaturaUsuario = user?.Assinatura;

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

            AddSection("TERMO DE CONSENTIMENTO LIVRE E ESCLARECIDO - PREENCHEDORES", c =>
            {
              c.Text(text =>
              {
                text.Span("Eu, ").FontSize(10);
                text.Span(pessoa.Nome).Bold().FontSize(10);
                text.Span($", portador do CPF {pessoa.Cpf}, em pleno gozo de minhas faculdades mentais, ").FontSize(10);
                text.Span("livre e voluntariamente, aceito o tratamento com preenchedores faciais ").FontSize(10);
                text.Span("a ser realizado pela profissional habilitada para tal procedimento.").FontSize(10);
              });
            });

            col.Item().PaddingBottom(10).Column(c =>
            {
              c.Item().Text("Declaro que recebi esclarecimentos quanto ao uso de preenchedores e estou ciente de que a mesma tem ação temporária e que cada pessoa apresenta uma resposta individual ao efeito do produto.")
                  .FontSize(10);
            });

            // 1. Transtornos possíveis
            col.Item().PaddingBottom(10).Column(c =>
            {
              c.Item().Text("Declaro que estou ciente dos transtornos possíveis tais como: reação alérgica, hipoestesia transitória (estímulos táteis abaixo do normal), dor e edema no local da aplicação, eritema (vermelhidão na pele), hematomas, entorpecimento temporário (fraqueza), náusea, dor de cabeça, extensão no local, paralisação indesejada de músculos adjacentes, xerostomia (secura excessiva da boca e alteração da voz), o que em sua maioria são transitórios e reversíveis.")
                  .FontSize(10);
            });

            // 2. Alternativas de tratamento
            col.Item().PaddingBottom(10).Column(c =>
            {
              c.Item().Text("É de meu conhecimento também que posso não fazer uso de preenchedores e optar por outro tipo de tratamento, como fui orientado(a) pela profissional.")
                  .FontSize(10);
            });

            // 3. Orientações pós-procedimento
            col.Item().PaddingBottom(10).Column(c =>
            {
              c.Item().Text("Declaro que recebi explicações verbais sobre a natureza e propósitos do procedimento, assim como benefícios, riscos, alternativas e meios de tratamento. Estou ciente de que, para obter o melhor resultado, devo ficar sem abaixar a cabeça e sem realizar qualquer esforço físico durante quatro horas, assim como evitar apoiar as mãos sobre o rosto ou coçar as regiões que passaram por aplicações, pelo mesmo período de tempo e ainda, evitar atividades que possam provocar aquecimento (aplicar calor na face, consumo de álcool, exercício físico por 24h e exposição ao sol).")
                  .FontSize(10);
            });

            // 4. Anamnese
            col.Item().PaddingBottom(10).Column(c =>
            {
              c.Item().Text("Declaro que respondi à anamnese (exame clínico e questionamentos de saúde), e não apresento alergia a ovo (albumina), problemas de miastenia grave (esclerose múltipla), acne, depressão, dismorfofobia, bem como nenhuma enfermidade descompensatória ou descompensada.")
                  .FontSize(10);
            });

            // 5. Esclarecimentos recebidos
            col.Item().PaddingBottom(10).Column(c =>
            {
              c.Item().Text("Declaro que entendi e estou satisfeito(a) com todas as explicações e esclarecimentos fornecidos pela profissional sobre o procedimento mencionado e que posso desistir a qualquer momento antes do início do procedimento.")
                  .FontSize(10);
            });

            // 6. Ciência sobre prognóstico
            col.Item().PaddingBottom(10).Column(c =>
            {
              c.Item().Text("É de meu conhecimento que a prática das ciências médicas não é uma ciência exata e reconheço que o prognóstico é apenas de ordem estatística, não significando necessariamente o resultado.")
                  .FontSize(10);
            });


            col.Item().PaddingBottom(10).Column(c =>
            {
              c.Item().Text("Assim sendo, reafirmo o meu consentimento para que seja realizado o procedimento:")
                  .FontSize(10);

              // Mostra o valor vindo do objeto
              if (!string.IsNullOrWhiteSpace(dados.Observacoes))
              {
                c.Item().PaddingTop(5).Text(dados.Observacoes).FontSize(10);
              }
              else
              {
                // Caso não tenha observações, mantém um espaço em branco
                c.Item().PaddingTop(5).Border(1).Height(60);
              }
            });

            AddSection("Assinatura do porfissional de sáude responsável", container =>
            {
              if (assinaturaUsuario != null)
              {
                container.AlignCenter().Width(150).Image(assinaturaUsuario).FitWidth();
              }
              else
              {
                container.Text("Sem assinatura registrada.").FontSize(10);
              }
            });

            AddSection("Assinatura do Cliente", container =>
            {
              if (dados.AssinaturaTermoConsentimento != null && dados.AssinaturaTermoConsentimento.Length > 0)
              {
                container.AlignCenter().Width(150).Image(dados.AssinaturaTermoConsentimento).FitWidth();
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
      return File(bytes, "application/pdf", "TermoPreenchimentoFacial.pdf");
    }
  }
}