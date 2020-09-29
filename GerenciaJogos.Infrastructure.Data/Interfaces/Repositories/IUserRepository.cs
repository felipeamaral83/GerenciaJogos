using GerenciaJogos.Domain.Entities;

namespace GerenciaJogos.Infrastructure.Data.Interfaces.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        User Get(string username, string password);
        User GetByUsername(string username);
    }
}
