using GerenciaJogos.Infrastructure.Data.Interfaces.Repositories;

namespace GerenciaJogos.Infrastructure.Data.Interfaces.Uow
{
    public interface IBorrowedGameUnitOfWork : IUnitOfWork
    {
        IBorrowedGameRepository BorrowedGameRepository { get; }
    }
}
