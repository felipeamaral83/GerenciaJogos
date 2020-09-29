using GerenciaJogos.ApplicationService.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GerenciaJogos.Infrastructure.CrossCutting.IoC
{
    public class ConfigureBindingsApplicationService
    {
        public static void RegisterBindings(IServiceCollection services)
        {
            services.AddScoped<AccountApplicationService>();
            services.AddScoped<FriendApplicationService>();
            services.AddScoped<GameApplicationService>();
            services.AddScoped<BorrowedGameApplicationService>();
        }
    }
}
