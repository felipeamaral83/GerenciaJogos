using GerenciaJogos.Infrastructure.Data.Interfaces.Repositories;

namespace GerenciaJogos.Infrastructure.Data.Interfaces.Uow
{
    public interface IFriendUnitOfWork : IUnitOfWork
    {
        IFriendRepository FriendRepository { get; }
    }
}
