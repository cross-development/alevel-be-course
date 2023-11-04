using Infrastructure.Data.Interfaces;
using Catalog.Host.Data;
using Catalog.Host.Models.Requests;
using Catalog.Host.Repositories.Interfaces;

namespace Catalog.Host.Repositories;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
    where TEntity : class
{
    private readonly ApplicationDbContext _dbContext;

    protected BaseRepository(IApplicationDbContextWrapper<ApplicationDbContext> dbContextWrapper)
    {
        _dbContext = dbContextWrapper.ApplicationDbContext;
    }

    public abstract Task<IEnumerable<TEntity>> GetAllAsync(PaginatedItemRequest request);

    public abstract Task<TEntity> GetByIdAsync(int id);

    public async Task<TEntity> FindOneAsync(int id)
    {
        return await _dbContext.Set<TEntity>().FindAsync(id);
    }

    public IQueryable<TEntity> GetQueryable()
    {
        return _dbContext.Set<TEntity>();
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        var item = await _dbContext.AddAsync(entity);

        await _dbContext.SaveChangesAsync();

        return item.Entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var item = _dbContext.Set<TEntity>().Update(entity);

        await _dbContext.SaveChangesAsync();

        return item.Entity;
    }

    public async Task<bool> DeleteAsync(TEntity entity)
    {
        _dbContext.Remove(entity);

        var result = await _dbContext.SaveChangesAsync() > 0;

        return result;
    }
}