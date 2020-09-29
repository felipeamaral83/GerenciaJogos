using GerenciaJogos.Domain.Entities;
using System;

namespace GerenciaJogos.Infrastructure.Data.Interfaces.Repositories
{
    public interface IGameRepository : IRepositoryBase<Game>
    {
        Game GetByName(string name, Guid? id = null);
    }
}
