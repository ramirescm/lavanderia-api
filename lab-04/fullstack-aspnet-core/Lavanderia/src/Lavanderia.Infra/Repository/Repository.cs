using Lavanderia.Domain.Interfaces.Repository;
using Lavanderia.Domain.Models;
using Lavanderia.Infra.Context;
using Lavanderia.Infra.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Lavanderia.Infra.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly LavanderiaContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(LavanderiaContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken ct = default)
        {
            await _context.AddAsync(entity, ct);
            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> FindAllAsync(CancellationToken ct = default)
        {
            return await _dbSet.ToListAsync(ct);
        }

        public virtual async Task<IEnumerable<TEntity>> FindByAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct = default)
        {
            return await _dbSet.Where(predicate).ToListAsync(ct);
        }

        public virtual async Task<TEntity> FindByIdAsync(long id, CancellationToken ct = default)
        {
            return await _dbSet.FindAsync(new object[] { id }, ct);
        }

        public virtual async Task<TEntity> FindByIdAsync(object[] ids, CancellationToken ct = default)
        {
            return await _dbSet.FindAsync(ids, ct);
        }

        public virtual async Task<TEntity> FindFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct = default)
        {
            return await _dbSet.Where(predicate).FirstOrDefaultAsync(ct);
        }

        public virtual async Task<TEntity> FindSingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct = default)
        {
            return await _dbSet.Where(predicate).SingleOrDefaultAsync(ct);
        }

        public virtual async Task RemoveAsync(long id, CancellationToken ct = default)
        {
            var entity = await FindByIdAsync(id, ct);
            if (entity == null)
            {
                throw new NotFoundException();
            }

            _context.Remove(entity);
        }

        public virtual TEntity Update(TEntity entity)
        {
            _context.Update(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
