using GerenciaJogos.Infrastructure.Data.Interfaces.Repositories;
using GerenciaJogos.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GerenciaJogos.Infrastructure.CrossCutting.IoC
{
    public class ConfigureBindingsRepository
    {
        public static void RegisterBindings(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IFriendRepository, FriendRepository>();
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IBorrowedGameRepository, BorrowedGameRepository>();
        }
    }
}
