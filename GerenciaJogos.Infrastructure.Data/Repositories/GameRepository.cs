using GerenciaJogos.Domain.Entities;
using GerenciaJogos.Infrastructure.Data.Context;
using GerenciaJogos.Infrastructure.Data.Interfaces.Repositories;
using System;
using System.Linq;

namespace GerenciaJogos.Infrastructure.Data.Repositories
{
    public class GameRepository : RepositoryBase<Game, GerenciaJogosModel>, IGameRepository
    {
        public GameRepository(GerenciaJogosModel context) : base(context) { }

        public Game GetByName(string name, Guid? id = null)
        {
            if (id == null)
                return _context.Game.Where(x => x.Name == name).FirstOrDefault();
            else
                return _context.Game.Where(x => x.Id != id && x.Name == name).FirstOrDefault();
        }
    }
}
