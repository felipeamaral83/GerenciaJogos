using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GerenciaJogos.Infrastructure.CrossCutting.IoC
{
    public static class ConfigureBindingsIoC
    {
        public static void RegisterBindings(IServiceCollection services, IConfiguration configuration)
        {
            ConfigureBindingsDatabaseContext.RegisterBindings(services, configuration);

            #region "ApplicationService"

            ConfigureBindingsApplicationService.RegisterBindings(services);

            #endregion

            #region "Repository"

            ConfigureBindingsRepository.RegisterBindings(services);

            #endregion

            #region "UnitOfWork"

            ConfigureBindingsUnitOfWork.RegisterBindings(services);

            #endregion

            #region "Validation"

            ConfigureBindingsValidation.RegisterBindings(services);

            #endregion
        }
    }
}
