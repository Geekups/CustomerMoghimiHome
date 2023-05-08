using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace CustomerMoghimiHome.Server.EntityFramework.Common;


public interface IRepository<TEntity> where TEntity : class, IBaseEntity
{
    Task<bool> ExistsAsync(long id);
    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);

    void Add(TEntity entity);
    void AddRange(IEnumerable<TEntity> entities);
    void Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);
    void Update(TEntity entity);
    void UpdateRange(IEnumerable<TEntity> entities);

    Task AddAsync(TEntity entity);
    Task AddRangeAsync(IEnumerable<TEntity> entities);

    Task<TEntity> AddAsyncReturnId(TEntity entity);
}

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IBaseEntity
{
    protected readonly DbContext DbContext;

    protected Repository(DataContext dbContext)
    {
        DbContext = dbContext;
    }

    #region Queries

    public async Task<bool> ExistsAsync(long id)
    {
        return await DbContext.Set<TEntity>().AnyAsync();
    }

    public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await DbContext.Set<TEntity>().AnyAsync(predicate);
    }

    #endregion

    #region Sync Commands

    public void Add(TEntity entity)
    {
        DbContext.Set<TEntity>().Add(entity);
    }

    public void AddRange(IEnumerable<TEntity> entities)
    {
        DbContext.Set<TEntity>().AddRange(entities);
    }

    public void Remove(TEntity entity)
    {
        DbContext.Set<TEntity>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        DbContext.Set<TEntity>().RemoveRange(entities);
    }

    public void Update(TEntity entity)
    {
        DbContext.Set<TEntity>().Update(entity);
    }

    public void UpdateRange(IEnumerable<TEntity> entities)
    {
        DbContext.Set<TEntity>().UpdateRange(entities);
    }

    #endregion

    #region Async Commands

    public async Task AddAsync(TEntity entity)
    {
        await DbContext.Set<TEntity>().AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await DbContext.Set<TEntity>().AddRangeAsync(entities);
    }


    public async Task<TEntity> AddAsyncReturnId(TEntity entity)
    {
        await DbContext.Set<TEntity>().AddAsync(entity);
        return entity;
    }
    #endregion
}