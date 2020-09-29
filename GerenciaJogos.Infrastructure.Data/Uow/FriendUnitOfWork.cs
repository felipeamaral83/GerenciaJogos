using GerenciaJogos.Infrastructure.Data.Context;
using GerenciaJogos.Infrastructure.Data.Interfaces.Repositories;
using GerenciaJogos.Infrastructure.Data.Interfaces.Uow;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GerenciaJogos.Infrastructure.Data.Uow
{
    public class FriendUnitOfWork : UnitOfWork, IFriendUnitOfWork
    {
        public IFriendRepository FriendRepository => _serviceProvider.GetService<IFriendRepository>();

        public FriendUnitOfWork(GerenciaJogosModel context, IServiceProvider serviceProvider) : base(context, serviceProvider)
        {
        }
    }
}
