using GerenciaJogos.ApplicationService.Validation.AccountValidation;
using GerenciaJogos.ApplicationService.Validation.BorrowedGameValidation;
using GerenciaJogos.ApplicationService.Validation.FriendValidation;
using GerenciaJogos.ApplicationService.Validation.GameValidation;
using Microsoft.Extensions.DependencyInjection;

namespace GerenciaJogos.Infrastructure.CrossCutting.IoC
{
    public class ConfigureBindingsValidation
    {
        public static void RegisterBindings(IServiceCollection services)
        {
            services.AddScoped<AccountValidation>();
            services.AddScoped<AccountCreateValidation>();
            services.AddScoped<FriendCreateValidation>();
            services.AddScoped<FriendUpdateValidation>();
            services.AddScoped<FriendDeleteValidation>();
            services.AddScoped<FriendValidation>();
            services.AddScoped<GameCreateValidation>();
            services.AddScoped<GameUpdateValidation>();
            services.AddScoped<GameDeleteValidation>();
            services.AddScoped<GameValidation>();
            services.AddScoped<BorrowedGameLendValidation>();
            services.AddScoped<BorrowedGameGiveBackValidation>();
            services.AddScoped<BorrowedGameValidation>();
        }
    }
}
