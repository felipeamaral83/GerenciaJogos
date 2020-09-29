using Microsoft.EntityFrameworkCore;

namespace GerenciaJogos.Infrastructure.Data.Context
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }
    }
}
