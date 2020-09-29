using GerenciaJogos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerenciaJogos.Infrastructure.Data.Context
{
    public partial class GerenciaJogosModel : BaseContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Friend> Friend { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<BorrowedGame> BorrowedGame { get; set; }
    }
}
