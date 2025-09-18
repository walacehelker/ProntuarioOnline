namespace Services.Base
{
  public interface IBaseService<TVm>
  {
    Task<IEnumerable<TVm>> GetAllAsync();
    Task<TVm> GetByIdAsync(Guid id);
    Task<TVm> CreateAsync(TVm vm);
    Task<TVm> UpdateAsync(Guid id, TVm vm);
    Task<bool> DeleteAsync(Guid id);

  }
}
