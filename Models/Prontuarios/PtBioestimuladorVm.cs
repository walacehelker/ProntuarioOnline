using AutoMapper.Configuration.Annotations;
using Models.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Prontuarios
{
  public class PtBioestimuladorVm : BaseVmEntity
  {
    public Guid PessoaId { get; set; }
    public string PessoaNome { get; set; }
    public DateTime? DataProcedimento { get; set; }

    public bool TratamentoFace { get; set; }

    public decimal? AnguloMandibulaRadiesseLidocaina { get; set; }
    public decimal? AnguloMandibulaRadiesseDuo { get; set; }
    public decimal? AnguloMandibulaDireita { get; set; }
    public decimal? AnguloMandibulaEsquerda { get; set; }
    public decimal? AnguloMandibulaQtdTotal { get; set; }
    public decimal? AnguloMandibulaDiluicao { get; set; }

    public decimal? LinhaMandibularRadiesseLidocaina { get; set; }
    public decimal? LinhaMandibularRadiesseDuo { get; set; }
    public decimal? LinhaMandibularDireita { get; set; }
    public decimal? LinhaMandibularEsquerda { get; set; }
    public decimal? LinhaMandibularQtdTotal { get; set; }
    public decimal? LinhaMandibularDiluicao { get; set; }

    public decimal? RegiaoMentonianaRadiesseLidocaina { get; set; }
    public decimal? RegiaoMentonianaRadiesseDuo { get; set; }
    public decimal? RegiaoMentonianaDireita { get; set; }
    public decimal? RegiaoMentonianaEsquerda { get; set; }
    public decimal? RegiaoMentonianaQtdTotal { get; set; }
    public decimal? RegiaoMentonianaDiluicao { get; set; }

    public decimal? RegiaoSubmalarRadiesseLidocaina { get; set; }
    public decimal? RegiaoSubmalarRadiesseDuo { get; set; }
    public decimal? RegiaoSubmalarDireita { get; set; }
    public decimal? RegiaoSubmalarEsquerda { get; set; }
    public decimal? RegiaoSubmalarQtdTotal { get; set; }
    public decimal? RegiaoSubmalarDiluicao { get; set; }

    public decimal? RegiaoTemporalRadiesseLidocaina { get; set; }
    public decimal? RegiaoTemporalRadiesseDuo { get; set; }
    public decimal? RegiaoTemporalDireita { get; set; }
    public decimal? RegiaoTemporalEsquerda { get; set; }
    public decimal? RegiaoTemporalQtdTotal { get; set; }
    public decimal? RegiaoTemporalDiluicao { get; set; }

    public decimal? SulcoLabiomentualRadiesseLidocaina { get; set; }
    public decimal? SulcoLabiomentualRadiesseDuo { get; set; }
    public decimal? SulcoLabiomentualDireita { get; set; }
    public decimal? SulcoLabiomentualEsquerda { get; set; }
    public decimal? SulcoLabiomentualQtdTotal { get; set; }
    public decimal? SulcoLabiomentualDiluicao { get; set; }

    public decimal? SulcoNasolabialRadiesseLidocaina { get; set; }
    public decimal? SulcoNasolabialRadiesseDuo { get; set; }
    public decimal? SulcoNasolabialDireita { get; set; }
    public decimal? SulcoNasolabialEsquerda { get; set; }
    public decimal? SulcoNasolabialQtdTotal { get; set; }
    public decimal? SulcoNasolabialDiluicao { get; set; }

    public bool TratamentoCorpo { get; set; }

    public decimal? AbdomenRadiesseDuo { get; set; }
    public decimal? AbdomenDireita { get; set; }
    public decimal? AbdomenEsquerda { get; set; }
    public decimal? AbdomenQtdTotal { get; set; }
    public decimal? AbdomenDiluicao { get; set; }

    public decimal? BracosRadiesseDuo { get; set; }
    public decimal? BracosDireita { get; set; }
    public decimal? BracosEsquerda { get; set; }
    public decimal? BracosQtdTotal { get; set; }
    public decimal? BracosDiluicao { get; set; }

    public decimal? ColoRadiesseDuo { get; set; }
    public decimal? ColoDireita { get; set; }
    public decimal? ColoEsquerda { get; set; }
    public decimal? ColoQtdTotal { get; set; }
    public decimal? ColoDiluicao { get; set; }

    public decimal? CotovelosRadiesseDuo { get; set; }
    public decimal? CotovelosDireita { get; set; }
    public decimal? CotovelosEsquerda { get; set; }
    public decimal? CotovelosQtdTotal { get; set; }
    public decimal? CotovelosDiluicao { get; set; }

    public decimal? CoxasRadiesseDuo { get; set; }
    public decimal? CoxasDireita { get; set; }
    public decimal? CoxasEsquerda { get; set; }
    public decimal? CoxasQtdTotal { get; set; }
    public decimal? CoxasDiluicao { get; set; }

    public decimal? GluteosRadiesseDuo { get; set; }
    public decimal? GluteosDireita { get; set; }
    public decimal? GluteosEsquerda { get; set; }
    public decimal? GluteosQtdTotal { get; set; }
    public decimal? GluteosDiluicao { get; set; }

    public decimal? JoelhoRadiesseDuo { get; set; }
    public decimal? JoelhoDireita { get; set; }
    public decimal? JoelhoEsquerda { get; set; }
    public decimal? JoelhoQtdTotal { get; set; }
    public decimal? JoelhoDiluicao { get; set; }

    public decimal? MaosRadiesseDuo { get; set; }
    public decimal? MaosDireita { get; set; }
    public decimal? MaosEsquerda { get; set; }
    public decimal? MaosQtdTotal { get; set; }
    public decimal? MaosDiluicao { get; set; }

    public decimal? PescocoRadiesseDuo { get; set; }
    public decimal? PescocoDireita { get; set; }
    public decimal? PescocoEsquerda { get; set; }
    public decimal? PescocoQtdTotal { get; set; }
    public decimal? PescocoDiluicao { get; set; }

    public byte[] PdfAssinado { get; set; }
  }

  public class PtBioestimuladorCadVm : BaseVmEntity
  {
    [Display(Name = "Pessoa")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    public Guid PessoaId { get; set; }

    [Display(Name = "Pessoa")]
    public string PessoaNome { get; set; }

    [Display(Name = "Data do procedimento")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    [DataType(DataType.Date)]
    public DateTime? DataProcedimento { get; set; }

    public bool TratamentoFace { get; set; }

    public decimal? AnguloMandibulaRadiesseLidocaina { get; set; }
    public decimal? AnguloMandibulaRadiesseDuo { get; set; }
    public decimal? AnguloMandibulaDireita { get; set; }
    public decimal? AnguloMandibulaEsquerda { get; set; }
    public decimal? AnguloMandibulaQtdTotal { get; set; }
    public decimal? AnguloMandibulaDiluicao { get; set; }

    public decimal? LinhaMandibularRadiesseLidocaina { get; set; }
    public decimal? LinhaMandibularRadiesseDuo { get; set; }
    public decimal? LinhaMandibularDireita { get; set; }
    public decimal? LinhaMandibularEsquerda { get; set; }
    public decimal? LinhaMandibularQtdTotal { get; set; }
    public decimal? LinhaMandibularDiluicao { get; set; }

    public decimal? RegiaoMentonianaRadiesseLidocaina { get; set; }
    public decimal? RegiaoMentonianaRadiesseDuo { get; set; }
    public decimal? RegiaoMentonianaDireita { get; set; }
    public decimal? RegiaoMentonianaEsquerda { get; set; }
    public decimal? RegiaoMentonianaQtdTotal { get; set; }
    public decimal? RegiaoMentonianaDiluicao { get; set; }

    public decimal? RegiaoSubmalarRadiesseLidocaina { get; set; }
    public decimal? RegiaoSubmalarRadiesseDuo { get; set; }
    public decimal? RegiaoSubmalarDireita { get; set; }
    public decimal? RegiaoSubmalarEsquerda { get; set; }
    public decimal? RegiaoSubmalarQtdTotal { get; set; }
    public decimal? RegiaoSubmalarDiluicao { get; set; }

    public decimal? RegiaoTemporalRadiesseLidocaina { get; set; }
    public decimal? RegiaoTemporalRadiesseDuo { get; set; }
    public decimal? RegiaoTemporalDireita { get; set; }
    public decimal? RegiaoTemporalEsquerda { get; set; }
    public decimal? RegiaoTemporalQtdTotal { get; set; }
    public decimal? RegiaoTemporalDiluicao { get; set; }

    public decimal? SulcoLabiomentualRadiesseLidocaina { get; set; }
    public decimal? SulcoLabiomentualRadiesseDuo { get; set; }
    public decimal? SulcoLabiomentualDireita { get; set; }
    public decimal? SulcoLabiomentualEsquerda { get; set; }
    public decimal? SulcoLabiomentualQtdTotal { get; set; }
    public decimal? SulcoLabiomentualDiluicao { get; set; }

    public decimal? SulcoNasolabialRadiesseLidocaina { get; set; }
    public decimal? SulcoNasolabialRadiesseDuo { get; set; }
    public decimal? SulcoNasolabialDireita { get; set; }
    public decimal? SulcoNasolabialEsquerda { get; set; }
    public decimal? SulcoNasolabialQtdTotal { get; set; }
    public decimal? SulcoNasolabialDiluicao { get; set; }

    public bool TratamentoCorpo { get; set; }

    public decimal? AbdomenRadiesseDuo { get; set; }
    public decimal? AbdomenDireita { get; set; }
    public decimal? AbdomenEsquerda { get; set; }
    public decimal? AbdomenQtdTotal { get; set; }
    public decimal? AbdomenDiluicao { get; set; }

    public decimal? BracosRadiesseDuo { get; set; }
    public decimal? BracosDireita { get; set; }
    public decimal? BracosEsquerda { get; set; }
    public decimal? BracosQtdTotal { get; set; }
    public decimal? BracosDiluicao { get; set; }

    public decimal? ColoRadiesseDuo { get; set; }
    public decimal? ColoDireita { get; set; }
    public decimal? ColoEsquerda { get; set; }
    public decimal? ColoQtdTotal { get; set; }
    public decimal? ColoDiluicao { get; set; }

    public decimal? CotovelosRadiesseDuo { get; set; }
    public decimal? CotovelosDireita { get; set; }
    public decimal? CotovelosEsquerda { get; set; }
    public decimal? CotovelosQtdTotal { get; set; }
    public decimal? CotovelosDiluicao { get; set; }

    public decimal? CoxasRadiesseDuo { get; set; }
    public decimal? CoxasDireita { get; set; }
    public decimal? CoxasEsquerda { get; set; }
    public decimal? CoxasQtdTotal { get; set; }
    public decimal? CoxasDiluicao { get; set; }

    public decimal? GluteosRadiesseDuo { get; set; }
    public decimal? GluteosDireita { get; set; }
    public decimal? GluteosEsquerda { get; set; }
    public decimal? GluteosQtdTotal { get; set; }
    public decimal? GluteosDiluicao { get; set; }

    public decimal? JoelhoRadiesseDuo { get; set; }
    public decimal? JoelhoDireita { get; set; }
    public decimal? JoelhoEsquerda { get; set; }
    public decimal? JoelhoQtdTotal { get; set; }
    public decimal? JoelhoDiluicao { get; set; }

    public decimal? MaosRadiesseDuo { get; set; }
    public decimal? MaosDireita { get; set; }
    public decimal? MaosEsquerda { get; set; }
    public decimal? MaosQtdTotal { get; set; }
    public decimal? MaosDiluicao { get; set; }

    public decimal? PescocoRadiesseDuo { get; set; }
    public decimal? PescocoDireita { get; set; }
    public decimal? PescocoEsquerda { get; set; }
    public decimal? PescocoQtdTotal { get; set; }
    public decimal? PescocoDiluicao { get; set; }

    public byte[] PdfAssinado { get; set; }
    public string Observacoes { get; set; }
    public bool? AceitaCompartilhamentoDados { get; set; }
    public bool? AceitaDivulgacao { get; set; }
    public bool? AceitaDivulgacaoCongresso { get; set; }
  }

  public class AssinaturaBioestimuladorVm
  {
    public Guid Id { get; set; }
    public byte[] PdfAssinado { get; set; }
    public string Observacoes { get; set; }
    public bool? AceitaCompartilhamentoDados { get; set; }
    public bool? AceitaDivulgacao { get; set; }
    public bool? AceitaDivulgacaoCongresso { get; set; }
  }

  public class PtBioestimuadorDadosPessoaVm
  {
    public string PessoaNome { get; set; }
    public string PessoaCpf { get; set; }
    public int PessoaIdade { get; set; }
    public string PessoaTelefone { get; set; }
    public string PessoaEndereco { get; set; }
  }
}
