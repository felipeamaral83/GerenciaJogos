using Microsoft.EntityFrameworkCore;

namespace GerenciaJogos.Infrastructure.Data.Context
{
    public partial class GerenciaJogosModel : BaseContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public GerenciaJogosModel(DbContextOptions options)
            : base(options)
        {
        }
    }
}
