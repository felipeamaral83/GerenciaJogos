using GerenciaJogos.Infrastructure.Data.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciaJogos.Infrastructure.Data.Repositories
{
    public class RepositoryBase<TEntity, TContext> : IRepositoryBase<TEntity>
            where TEntity : class
            where TContext : DbContext
    {
        protected readonly TContext _context;

        private readonly DbSet<TEntity> _dbSet;

        public RepositoryBase(TContext context)
        {
            _dbSet = context.Set<TEntity>();
            _context = context;
        }

        public virtual void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual void Edit(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<TEntity> GetAllReadOnly()
        {
            return _dbSet.AsNoTracking();
        }

        public TEntity GetById(Guid id)
        {
            return _dbSet.Find(id);
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}
