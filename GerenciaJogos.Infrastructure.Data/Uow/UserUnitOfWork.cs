using GerenciaJogos.Infrastructure.Data.Context;
using GerenciaJogos.Infrastructure.Data.Interfaces.Repositories;
using GerenciaJogos.Infrastructure.Data.Interfaces.Uow;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GerenciaJogos.Infrastructure.Data.Uow
{
    public class UserUnitOfWork : UnitOfWork, IUserUnitOfWork
    {
        public IUserRepository UserRepository => _serviceProvider.GetService<IUserRepository>();

        public UserUnitOfWork(GerenciaJogosModel context, IServiceProvider serviceProvider) : base(context, serviceProvider)
        {
        }
    }
}
