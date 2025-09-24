using AutoMapper;
using Configuration;
using Domain.Base;
using Microsoft.EntityFrameworkCore;
using Models.Base;
using Services.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
      vm.Id = id;
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

    public virtual IEnumerable<TVmEntity> GetAll()
    {
      var entities = _dbSet.AsNoTracking().ToList();
      return _mapper.Map<IEnumerable<TVmEntity>>(entities);
    }

    public virtual TVmEntity GetById(Guid id)
    {
      var entity = _dbSet.Find(id);
      return entity == null ? null : _mapper.Map<TVmEntity>(entity);
    }

    public virtual TVmEntity Create(TVmEntity vm)
    {
      var entity = _mapper.Map<TDbEntity>(vm);
      _dbSet.Add(entity);
      _context.SaveChanges();
      return _mapper.Map<TVmEntity>(entity);
    }

    public virtual TVmEntity Update(Guid id, TVmEntity vm)
    {
      var entity = _dbSet.Find(id);
      if (entity == null) return null;

      _mapper.Map(vm, entity);
      _context.SaveChanges();
      return _mapper.Map<TVmEntity>(entity);
    }

    public virtual bool Delete(Guid id)
    {
      var entity = _dbSet.Find(id);
      if (entity == null) return false;

      _dbSet.Remove(entity);
      _context.SaveChanges();
      return true;
    }

    public virtual TVmEntity FindOne(Func<TVmEntity, bool> predicate)
    {
      var entities = _dbSet.AsNoTracking().ToList();
      var vms = _mapper.Map<IEnumerable<TVmEntity>>(entities);
      return vms.FirstOrDefault(predicate);
    }

    public virtual async Task<TVmEntity> FindOneAsync(Func<TVmEntity, bool> predicate)
    {
      var entities = await _dbSet.AsNoTracking().ToListAsync();
      var vms = _mapper.Map<IEnumerable<TVmEntity>>(entities);
      return vms.FirstOrDefault(predicate);
    }

    public virtual IEnumerable<TVmEntity> Find(Func<TVmEntity, bool> predicate)
    {
      var entities = _dbSet.AsNoTracking().ToList();
      var vms = _mapper.Map<IEnumerable<TVmEntity>>(entities);
      return vms.Where(predicate);
    }

    public virtual async Task<IEnumerable<TVmEntity>> FindAsync(Func<TVmEntity, bool> predicate)
    {
      var entities = await _dbSet.AsNoTracking().ToListAsync();
      var vms = _mapper.Map<IEnumerable<TVmEntity>>(entities);
      return vms.Where(predicate);
    }
  }
}