using GerenciaJogos.Infrastructure.Data.Context;
using GerenciaJogos.Infrastructure.Data.Interfaces.Repositories;
using GerenciaJogos.Infrastructure.Data.Interfaces.Uow;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GerenciaJogos.Infrastructure.Data.Uow
{
    public class GameUnitOfWork : UnitOfWork, IGameUnitOfWork
    {
        public IGameRepository GameRepository => _serviceProvider.GetService<IGameRepository>();

        public GameUnitOfWork(GerenciaJogosModel context, IServiceProvider serviceProvider) : base(context, serviceProvider)
        {
        }
    }
}
