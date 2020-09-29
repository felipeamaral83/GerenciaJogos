using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Threading.Tasks;

namespace GerenciaJogos.Infrastructure.Data.Interfaces
{
    public interface IUnitOfWork
    {
        void Commit();
        Task CommitAsync();
        void Detach<T>(T entity) where T : class;
        DatabaseFacade Database { get; }
    }
}
