using GerenciaJogos.Infrastructure.Data.Interfaces.Repositories;

namespace GerenciaJogos.Infrastructure.Data.Interfaces.Uow
{
    public interface IUserUnitOfWork : IUnitOfWork
    {
        IUserRepository UserRepository { get; }
    }
}
