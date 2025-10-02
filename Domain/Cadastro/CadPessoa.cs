using Domain.Base;
using Domain.Prontuarios;

namespace Domain.Cadastro
{
  public class CadPessoa : BaseDomainEntity
  {
    public string Nome { get; set; }
    public string NomeSocial { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Cpf { get; set; }
    public string Rua { get; set; }
    public int? Numero { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public string Cep { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public byte[] PdfAssinado { get; set; }
    public virtual List<CadPessoaHistorico> CadPessoaHistoricoList { get; set; }
    public virtual List<PtBotox> PtBotoxList { get; set; }
    public virtual List<PtBioestimulador> PtBioestimuladorList { get; set; }
    public virtual List<PtPreenchimentoFacial> PtPreenchimentoFacialList { get; set; }
  }
}
