using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Skeleton.Entity;

namespace Skeleton.Repository;

public class Repository<T>(SkeletonDbContext dbContext) : IRepository<T>
    where T : BaseEntity
{
    public Task<T?> GetByIdAsync(string id)
    {
        return dbContext.Set<T>().FirstOrDefaultAsync(entity => entity.Id.Equals(id));
    }

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? conditions = null, bool withTracking = true)
    {
        var result = conditions != null ? dbContext.Set<T>().Where(conditions) : dbContext.Set<T>();

        if (!withTracking)
        {
            return await result.AsNoTracking().ToListAsync();
        }

        return await result.ToListAsync();
    }

    public async Task<T?> GetSingleOrDefaultAsync(Expression<Func<T, bool>>? conditions = null, bool withTracking = true)
    {
        var result = conditions != null ? dbContext.Set<T>().Where(conditions) : dbContext.Set<T>();

        if (!withTracking)
        {
            return await result.AsNoTracking().FirstOrDefaultAsync();
        }

        return await result.FirstOrDefaultAsync();
    }

    public async Task<int> AddAsync(T obj)
    {
        await dbContext.Set<T>().AddAsync(obj);
        return await dbContext.SaveChangesAsync();
    }

    public Task<int> UpdateAsync(T obj)
    {
        dbContext.Set<T>().Update(obj);
        return dbContext.SaveChangesAsync();
    }

    public Task RemoveAsync(T obj)
    {
        dbContext.Set<T>().Remove(obj);
        return dbContext.SaveChangesAsync();
    }

    public Task<int> CountAsync(Expression<Func<T, bool>>? conditions = null)
    {
        return conditions == null ? 
            dbContext.Set<T>().CountAsync() : 
            dbContext.Set<T>().CountAsync(conditions);
    }
}