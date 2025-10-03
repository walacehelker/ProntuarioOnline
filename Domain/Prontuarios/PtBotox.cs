using Domain.Base;
using Domain.Cadastro;

namespace Domain.Prontuarios
{
  public class PtBotox : BaseDomainEntity
  {
    public Guid PessoaId { get; set; }
    public DateTime DataProcedimento { get; set; }
    public string MarcaProduto { get; set; }
    public DateTime? DataDiluicao { get; set; }
    public decimal? VolumeDiluicao { get; set; }
    public string NumeroLote { get; set; }
    public DateTime? DataValidade { get; set; }

    //Pontos de aplicação
    public decimal? Frontal { get; set; }
    public decimal? Procero { get; set; }
    public decimal? Nasal { get; set; }
    public decimal? DepressorSeptoNasal { get; set; }
    public decimal? OrbicularBoca { get; set; }
    public decimal? DepressorAnguloBocaDireito { get; set; }
    public decimal? DepressorAnguloBocaEsquerdo { get; set; }
    public decimal? CorrugadorDireito { get; set; }
    public decimal? CorrugadorEsquerdo { get; set; }
    public decimal? LevantadorLabioSuperiorDireito { get; set; }
    public decimal? LevantadorLabioSuperiorEsquerdo { get; set; }
    public decimal? LLabioSupAsaNarizDireito { get; set; }
    public decimal? LLabioSupAsaNarizEsquerdo { get; set; }
    public decimal? RisorioDireito { get; set; }
    public decimal? RisorioEsquerdo { get; set; }
    public decimal? ZigomaticoMaiorDireito { get; set; }
    public decimal? ZigomaticoMaiorEsquerdo { get; set; }
    public decimal? ZigomaticoMenorDireito { get; set; }
    public decimal? ZigomaticoMenorEsquerdo { get; set; }
    public decimal? OrbicularOlhoDireito { get; set; }
    public decimal? OrbicularOlhoEsquerdo { get; set; }
    public decimal? MentonianoDireito { get; set; }
    public decimal? MentonianoEsquerdo { get; set; }
    public decimal? PlatismaDireito { get; set; }
    public decimal? PlatismaEsquerdo { get; set; }
    public decimal? DepressorLabioInferiorDireito { get; set; }
    public decimal? DepressorLabioInferiorEsquerdo { get; set; }
    public decimal? MassesterDireito { get; set; }
    public decimal? MassesterEsquerdo { get; set; }

    public decimal? TotalUtilizado { get; set; }
    public byte[] PdfAssinado { get; set; }
    public string Observacoes { get; set; }
    public bool? AceitaDivulgacao { get; set; }
    public DateTime? DataAssinatura { get; set; }

    public CadPessoa CadPessoa { get; set; }
  }
}
