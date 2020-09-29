using GerenciaJogos.Infrastructure.Data.Interfaces.Repositories;

namespace GerenciaJogos.Infrastructure.Data.Interfaces.Uow
{
    public interface IGameUnitOfWork : IUnitOfWork
    {
        IGameRepository GameRepository { get; }
    }
}
