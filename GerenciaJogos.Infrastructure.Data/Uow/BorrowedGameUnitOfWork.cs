using GerenciaJogos.Infrastructure.Data.Context;
using GerenciaJogos.Infrastructure.Data.Interfaces.Repositories;
using GerenciaJogos.Infrastructure.Data.Interfaces.Uow;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GerenciaJogos.Infrastructure.Data.Uow
{
    public class BorrowedGameUnitOfWork : UnitOfWork, IBorrowedGameUnitOfWork
    {
        public IBorrowedGameRepository BorrowedGameRepository => _serviceProvider.GetService<IBorrowedGameRepository>();

        public BorrowedGameUnitOfWork(GerenciaJogosModel context, IServiceProvider serviceProvider) : base(context, serviceProvider)
        {
        }
    }
}
