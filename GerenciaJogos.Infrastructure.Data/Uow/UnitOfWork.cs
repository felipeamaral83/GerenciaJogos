using GerenciaJogos.Infrastructure.Data.Context;
using GerenciaJogos.Infrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Threading.Tasks;

namespace GerenciaJogos.Infrastructure.Data.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        protected BaseContext Context { get; set; }
        protected readonly IServiceProvider _serviceProvider;
        public UnitOfWork(BaseContext context, IServiceProvider serviceProvider)
        {
            Context = context;
            _serviceProvider = serviceProvider;
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public virtual Task CommitAsync()
        {
            return Context.SaveChangesAsync();
        }

        public void Detach<T>(T entity) where T : class
        {
            Context.Entry(entity).State = EntityState.Detached;
        }

        public DatabaseFacade Database { get { return Context.Database; } }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
