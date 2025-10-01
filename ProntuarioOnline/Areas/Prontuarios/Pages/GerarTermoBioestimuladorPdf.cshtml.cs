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
  public class GerarTermoBioestimuladorPdfModel : PageModel
  {
    private readonly IPtBioestimuladorCadService _ptBioestimuladorCadService;
    private readonly IPessoaService _pessoaService;
    private readonly UserManager<ApplicationUser> _userManager;


    public GerarTermoBioestimuladorPdfModel(IPtBioestimuladorCadService ptBioestimuladorCadService,
      IPessoaService pessoaService,
      UserManager<ApplicationUser> userManager)
    {
      _ptBioestimuladorCadService = ptBioestimuladorCadService;
      _pessoaService = pessoaService;
      _userManager = userManager;

    }

    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
      var dados = await _ptBioestimuladorCadService.GetByIdAsync(id);
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

            AddSection("Termo de Consentimento", c =>
            {
              c.Text(text =>
              {
                text.Span("Pelo presente termo, eu ").FontSize(10);
                text.Span(pessoa.Nome).Bold().FontSize(10);
                text.Span($", portador(a) do CPF: {pessoa.Cpf}, idade: {idade}, telefone: {pessoa.Telefone}, endereço: {endereco}, ").FontSize(10);
                text.Span("declaro estar informado sobre os possíveis riscos e efeitos esperados, e autorizo o(a) Dr.(a): ").FontSize(10);
                text.Span(UsuarioLogado).Bold().FontSize(10);
                text.Span(", Conselho de Classe: ------, a realizar o(s) procedimento(s) com ").FontSize(10);
                text.Span("RADIESSE® Duo e/ou RADIESSE® (+) Lidocaíne.").Bold().FontSize(10);
              });
            });

            col.Item().PaddingBottom(10).Column(c =>
            {
              c.Item().Text("Declaro estar ciente de que o uso de ácido acetilsalicílico ou outros medicamentos pode inibir o processo de cicatrização. " +
                            "Declaro estar ciente também de que, logo após a aplicação do produto acima mencionado, posso apresentar dor, eritema (coloração avermelhada na pele), " +
                            "edema (inchaço) e prurido (coceira) nos locais de aplicação. Esses sintomas desaparecem espontaneamente em um ou dois dias após a injeção.")
                .FontSize(10);
            });

            // Compromissos e Possíveis Complicações
            col.Item().PaddingBottom(10).Column(c =>
            {
              c.Item().Text("Enquanto os eventos adversos estiverem presentes, comprometo-me a usar protetor solar, de maneira a evitar que minha pele possa sofrer " +
                            "hiperpigmentação (manchar). Declaro ainda estar ciente da possibilidade dos seguintes riscos e complicações: inchaço, reações alérgicas, infecção " +
                            "local, necrose, estrusão (rejeição) do material e formação de nódulos. Estou ciente de que o resultado estético depende também da minha resposta ao " +
                            "tratamento, podendo ser insuficiente, com a persistência de linhas ou dobras e necessidade de um possível tratamento complementar.")
                .FontSize(10);
            });

            // Condições de Contraindicação
            col.Item().PaddingBottom(10).Column(c =>
            {
              c.Item().Text("Afirmo saber que esse procedimento pode ser contraindicado para mim, caso possua distúrbios de coagulação (afinamento do sangue) ou da " +
                            "cicatrização (cicatriz com qualidade ruim), se possuir implantes definitivos no local (prótese ou injeção de materiais não absorvíveis) " +
                            "e se estiver grávida ou amamentando. Declaro que comuniquei ao(s) profissional(is) de saúde injetor(es) das condições acima e qualquer " +
                            "medicamento que esteja em uso no momento.")
                .FontSize(10);
            });

            // Observações
            col.Item().PaddingBottom(10).Column(c =>
            {
              // Label
              c.Item().Text("Outros riscos específicos, caso ocorram, associados à minha condição física:")
                  .FontSize(10)
                  .Bold();

              // Conteúdo das observações
              c.Item().Text(string.IsNullOrWhiteSpace(dados.Observacoes) ? "Nenhuma" : dados.Observacoes)
                  .FontSize(10);
            });

            // Autorização do Procedimento
            col.Item().PaddingBottom(10).Column(c =>
            {
              c.Item().Text("Autorizo o(s) profissional(is) de saúde acima descrito(s) a realizar(em) a bioestimulação de colágeno da pele da face e/ou corpo com o produto da " +
                            "linha RADIESSE Collection, que é um bioestimulador de colágeno de longa duração e não permanente.")
                .FontSize(10);
            });

            // Declaração de Ciência
            col.Item().PaddingBottom(10).Column(c =>
            {
              c.Item().Text("Declaro que li e entendi as informações contidas nesse formulário para a autorização do procedimento. Declaro que tive oportunidade de fazer qualquer " +
                            "pergunta sobre o tratamento, riscos de eventos adversos e/ou necessidade de tratamentos complementares e todas as minhas dúvidas foram " +
                            "satisfatoriamente respondidas.")
                .FontSize(10);
            });

            // Isenção de Responsabilidade
            col.Item().PaddingBottom(10).Column(c =>
            {
              c.Item().Text("Estando, pois, ciente dos riscos e dos eventos adversos presentes com a utilização do produto da linha RADIESSE Collection, em relação aos quais " +
                            "fui e estou suficientemente informado(a) e, sobretudo, tendo em vista a minha autorização em forma livre, consciente e voluntária em submeter-me ao " +
                            "tratamento com o produto da linha RADIESSE Collection, isento, para todos os fins de direito, empresa e/ou profissional(is) responsável(is) pela " +
                            "avaliação e tratamento injetável com o produto da linha RADIESSE Collection, de qualquer responsabilidade civil, incluindo, mas não se limitando aos " +
                            "danos físicos/estéticos, lucros cessantes ou outra responsabilidade de qualquer natureza.")
                .FontSize(10);
            });

            // Consentimento de Uso de Imagem
            col.Item().PaddingBottom(10).Column(c =>
            {
              c.Item().Text("Dou o meu consentimento para ser fotografado(a) e/ou filmado(a) antes, durante e depois do procedimento, autorizo o(s) profissional(is) " +
                            "interventor(es) a utilizar(em) a minha imagem pessoal, de forma gratuita, em revistas científicas e/ou congressos médicos com propósito " +
                            "médico educacional.")
                .FontSize(10);
            });

            // Consentimento de Compartilhamento de Dados (checkbox estilo [x])
            col.Item().PaddingBottom(10).Column(c =>
            {
              c.Item().Text(dados.AceitaCompartilhamentoDados == true
                  ? "[x] Ao consentir a realização do procedimento acima descrito, autorizo expressamente que o(s) profissional(is) de saúde acima mencionado(s) realize o tratamento de meus dados pessoais, livremente fornecidos por mim neste documento, para a finalidade específica de atendimento à legislação sanitária aplicável e de proteção à vida. Autorizo ainda, a transferência de meus dados pessoais contidos neste termo com o fabricante/distribuidor do equipamento/produto, para a finalidade específica de atendimento à legislação sanitária aplicável e de proteção à vida."
                  : "[ ] Ao consentir a realização do procedimento acima descrito, autorizo expressamente que o(s) profissional(is) de saúde acima mencionado(s) realize o tratamento de meus dados pessoais, livremente fornecidos por mim neste documento, para a finalidade específica de atendimento à legislação sanitária aplicável e de proteção à vida. Autorizo ainda, a transferência de meus dados pessoais contidos neste termo com o fabricante/distribuidor do equipamento/produto, para a finalidade específica de atendimento à legislação sanitária aplicável e de proteção à vida.")
                .FontSize(10);
            });

            // Autorização de Imagem em Redes
            col.Item().PaddingBottom(10).Column(c =>
            {
              c.Item().Text(dados.AceitaDivulgacao == true ? "[x] Autorizo o uso de minha imagem pessoal em revistas científicas, redes sociais e websites."
                                                           : "[ ] Autorizo o uso de minha imagem pessoal em revistas científicas, redes sociais e websites.")
                .FontSize(10);
            });

            // Autorização de Imagem em Congressos
            col.Item().PaddingBottom(10).Column(c =>
            {
              c.Item().Text(dados.AceitaDivulgacaoCongresso == true ? "[x] Autorizo o uso de minha imagem pessoal em congressos."
                                                                    : "[ ] Autorizo o uso de minha imagem pessoal em congressos.")
                .FontSize(10);
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

            // Encerramento
            col.Item().PaddingBottom(10).Column(c =>
            {
              c.Item().Text("Por ser expressão da verdade, firmo o presente \"Termo de Consentimento.\"")
                .FontSize(10)
                .Bold();
            });

            // Informações sobre o Produto
            col.Item().PaddingBottom(10).Column(c =>
            {
              c.Item().Text("RADIESSE® Duo (Reg. MS. n° 80829430004) e RADIESSE® Lidocaíne (Reg. MS. n° 80829430003) são produtos para a saúde, que consistem em aproximadamente 30% de hidroxiapatita de cálcio e 70% de gel como veículo por volume, sendo totalmente biodegradáveis, de aplicação subdérmica e profunda. RADIESSE® Lidocaíne contém ainda 0,3% de cloridrato de lidocaína em sua formulação. Precauções: Reações, incluindo eritema, edema, dor, prurido, descoloração ou sensibilidade, podem ocorrer no local da injeção. Esses sintomas normalmente desaparecem espontaneamente em um ou dois dias após a aplicação.")
                .FontSize(9);
            });


            col.Item().PaddingBottom(10).Column(c =>
            {
              c.Item().Text("CONTRAINDICAÇÕES: EM CASOS DE PRESENÇA DE INFLAMAÇÃO OU INFECÇÃO AGUDA E/OU CRÔNICA NA ÁREA A SER TRATADA, RADIESSE® (+) LIDOCAINE É CONTRAINDICADO EM CASOS DE HIPERSENSIBILIDADE CONHECIDA À LIDOCAÍNA OU ANESTÉSICOS DO TIPO AMIDA.")
                  .FontSize(10)
                  .Bold();
            });

            col.Item().PaddingBottom(10).Column(c =>
            {
              c.Item().Text("Radiesse Collection refere-se à família de produtos RADIESSE® Duo (Reg. MS. n° 80829430004) e RADIESSE® Lidocaíne (Reg. MS. n° 80829430003).")
                  .FontSize(10)
                  .Bold();
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
      return File(bytes, "application/pdf", "TermoBioestimulador.pdf");
    }
  }
}