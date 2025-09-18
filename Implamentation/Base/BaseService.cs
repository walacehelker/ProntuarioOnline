using AutoMapper;
using Domain.Base;
using Configuration;
using Microsoft.EntityFrameworkCore;
using Models.Base;
using Services.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Implementations.Base
{
  public abstract class BaseService<TDbEntity, TVmEntity> : IBaseService<TVmEntity>
      where TDbEntity : BaseDomainEntity, new()
      where TVmEntity : BaseVmEntity, new()
  {
    protected readonly AppDbContext _context;
    protected readonly DbSet<TDbEntity> _dbSet;
    private readonly IMapper _mapper;

    protected BaseService(AppDbContext context, IMapper mapper)
    {
      _context = context;
      _dbSet = _context.Set<TDbEntity>();
      _mapper = mapper;
    }

    public virtual async Task<IEnumerable<TVmEntity>> GetAllAsync()
    {
      var entities = await _dbSet.AsNoTracking().ToListAsync();
      return _mapper.Map<IEnumerable<TVmEntity>>(entities);
    }

    public virtual async Task<TVmEntity> GetByIdAsync(Guid id)
    {
      var entity = await _dbSet.FindAsync(id);
      return entity == null ? null : _mapper.Map<TVmEntity>(entity);
    }

    public virtual async Task<TVmEntity> CreateAsync(TVmEntity vm)
    {
      var entity = _mapper.Map<TDbEntity>(vm);
      _dbSet.Add(entity);
      await _context.SaveChangesAsync();
      return _mapper.Map<TVmEntity>(entity);
    }

    public virtual async Task<TVmEntity> UpdateAsync(Guid id, TVmEntity vm)
    {
      var entity = await _dbSet.FindAsync(id);
      if (entity == null) return null;

      _mapper.Map(vm, entity);
      await _context.SaveChangesAsync();
      return _mapper.Map<TVmEntity>(entity);
    }

    public virtual async Task<bool> DeleteAsync(Guid id)
    {
      var entity = await _dbSet.FindAsync(id);
      if (entity == null) return false;

      _dbSet.Remove(entity);
      await _context.SaveChangesAsync();
      return true;
    }
  }
}