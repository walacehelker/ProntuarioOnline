using System.Linq.Expressions;

namespace Services.Base
{
  public interface IBaseService<TVmEntity>
  {
    Task<IEnumerable<TVmEntity>> GetAllAsync();
    Task<TVmEntity> GetByIdAsync(Guid id);
    Task<TVmEntity> CreateAsync(TVmEntity vm);
    Task<bool> DeleteAsync(Guid id);
    IEnumerable<TVmEntity> GetAll();
    TVmEntity GetById(Guid id);
    TVmEntity Create(TVmEntity vm);
    TVmEntity Update(TVmEntity vm);
    Task<TVmEntity> UpdateAsync(TVmEntity vm);
    bool Delete(Guid id);
    TVmEntity FindOne(Func<TVmEntity, bool> predicate);
    Task<TVmEntity> FindOneAsync(Func<TVmEntity, bool> predicate);
    IEnumerable<TVmEntity> Find(Func<TVmEntity, bool> predicate);
    Task<IEnumerable<TVmEntity>> FindAsync(Func<TVmEntity, bool> predicate);
  }
}
