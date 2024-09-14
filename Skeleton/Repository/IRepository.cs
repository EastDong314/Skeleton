using System.Linq.Expressions;
using Skeleton.Entity;

namespace Skeleton.Repository;

public interface IRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(string id);
    
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? conditions = null, bool withTracking = true);
    
    Task<T?> GetSingleOrDefaultAsync(Expression<Func<T, bool>>? conditions = null, bool withTracking = true);

    Task<int> AddAsync(T obj);
    
    Task<int> UpdateAsync(T obj);
    
    Task RemoveAsync(T obj);

    Task<int> CountAsync(Expression<Func<T, bool>>? conditions = null);
}