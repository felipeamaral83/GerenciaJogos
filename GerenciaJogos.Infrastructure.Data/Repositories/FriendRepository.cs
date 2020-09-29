using GerenciaJogos.Domain.Entities;
using GerenciaJogos.Infrastructure.Data.Context;
using GerenciaJogos.Infrastructure.Data.Interfaces.Repositories;

namespace GerenciaJogos.Infrastructure.Data.Repositories
{
    public class FriendRepository : RepositoryBase<Friend, GerenciaJogosModel>, IFriendRepository
    {
        public FriendRepository(GerenciaJogosModel context) : base(context) { }
    }
}
