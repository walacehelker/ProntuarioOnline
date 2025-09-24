using System.Linq.Expressions;

namespace Services.Base
{
  public interface IBaseService<TVm>
  {
    Task<IEnumerable<TVm>> GetAllAsync();
    Task<TVm> GetByIdAsync(Guid id);
    Task<TVm> CreateAsync(TVm vm);
    Task<TVm> UpdateAsync(Guid id, TVm vm);
    Task<bool> DeleteAsync(Guid id);
    IEnumerable<TVm> GetAll();
    TVm GetById(Guid id);
    TVm Create(TVm vm);
    TVm Update(Guid id, TVm vm);
    bool Delete(Guid id);
    TVm FindOne(Func<TVm, bool> predicate);
    Task<TVm> FindOneAsync(Func<TVm, bool> predicate);
    IEnumerable<TVm> Find(Func<TVm, bool> predicate);
    Task<IEnumerable<TVm>> FindAsync(Func<TVm, bool> predicate);
  }
}
