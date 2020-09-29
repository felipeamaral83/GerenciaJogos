using GerenciaJogos.Infrastructure.Data.Interfaces.Uow;
using GerenciaJogos.Infrastructure.Data.Uow;
using Microsoft.Extensions.DependencyInjection;

namespace GerenciaJogos.Infrastructure.CrossCutting.IoC
{
    public static class ConfigureBindingsUnitOfWork
    {
        public static void RegisterBindings(IServiceCollection services)
        {
            services.AddScoped<IUserUnitOfWork, UserUnitOfWork>();
            services.AddScoped<IFriendUnitOfWork, FriendUnitOfWork>();
            services.AddScoped<IGameUnitOfWork, GameUnitOfWork>();
            services.AddScoped<IBorrowedGameUnitOfWork, BorrowedGameUnitOfWork>();
        }
    }
}
