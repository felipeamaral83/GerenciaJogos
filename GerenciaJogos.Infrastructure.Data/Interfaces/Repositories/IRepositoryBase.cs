using System;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciaJogos.Infrastructure.Data.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity>
    {
        void Add(TEntity entity);
        void Edit(TEntity entity);
        void Delete(TEntity entity);
        TEntity GetById(Guid id);
        Task<TEntity> GetByIdAsync(Guid id);
        IQueryable<TEntity> GetAllReadOnly();
    }
}
