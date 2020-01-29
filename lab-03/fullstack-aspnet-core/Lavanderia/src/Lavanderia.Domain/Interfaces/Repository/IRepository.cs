using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Lavanderia.Domain.Interfaces.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity, CancellationToken ct = default);
        TEntity Update(TEntity entity);
        Task RemoveAsync(long id, CancellationToken ct = default);
        Task<TEntity> FindByIdAsync(long id, CancellationToken ct = default);
        Task<TEntity> FindByIdAsync(object[] ids, CancellationToken ct = default);
        Task<IEnumerable<TEntity>> FindAllAsync(CancellationToken ct = default);
        Task<TEntity> FindByAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct = default);
        Task<TEntity> FindSingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct = default);
        Task<TEntity> FindFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct = default);
    }
}
