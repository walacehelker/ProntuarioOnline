namespace Models.Base
{
  public class BaseVmEntity
  {
    public Guid Id { get; set; }
    public DateTime DataInsercao { get; set; }
    public bool Excluido { get; set; }
    public DateTime? ExcluidoEm { get; set; }
  }
}
