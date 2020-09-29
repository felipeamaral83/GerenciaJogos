using GerenciaJogos.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GerenciaJogos.Infrastructure.CrossCutting.IoC
{
    public class ConfigureBindingsDatabaseContext
    {
        public static void RegisterBindings(IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddEntityFrameworkSqlServer()
                .AddDbContext<GerenciaJogosModel>(
                        options => options.UseSqlServer(configuration.GetConnectionString("dbserver"))
                );
        }
    }
}
