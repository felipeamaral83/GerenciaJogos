using GerenciaJogos.Domain.Entities;
using GerenciaJogos.Infrastructure.Data.Context;
using GerenciaJogos.Infrastructure.Data.Interfaces.Repositories;

namespace GerenciaJogos.Infrastructure.Data.Repositories
{
    public class BorrowedGameRepository : RepositoryBase<BorrowedGame, GerenciaJogosModel>, IBorrowedGameRepository
    {
        public BorrowedGameRepository(GerenciaJogosModel context) : base(context) { }
    }
}
