using GerenciaJogos.Domain.Entities;
using GerenciaJogos.Infrastructure.Data.Context;
using GerenciaJogos.Infrastructure.Data.Interfaces.Repositories;
using System.Linq;

namespace GerenciaJogos.Infrastructure.Data.Repositories
{
    public class UserRepository : RepositoryBase<User, GerenciaJogosModel>, IUserRepository
    {
        public UserRepository(GerenciaJogosModel context) : base(context) { }
        
        public User Get(string username, string password)
        {
            var user = _context.User
                .Where(x => x.Username == username
                         && x.Password == password)
                .FirstOrDefault();

            return user;
        }

        public User GetByUsername(string username)
        {
            var user = _context.User.Where(x => x.Username == username).FirstOrDefault();
            return user;
        }
    }
}
