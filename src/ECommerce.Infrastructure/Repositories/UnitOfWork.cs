using ECommerce.Infrastructure.Context;
using Framework.Domain.Core;
using System;
using System.Data.Entity;

namespace ECommerce.Domain.Core
{
    public sealed class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DbContext dbContext;

        public UnitOfWork()
        {
            this.dbContext = DataContextFactory.GetDataContext();
        }

        public void Commit()
        {
            this.dbContext.SaveChanges();
        }

        public void Rollback()
        {
            dbContext.UndoChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (disposing && this.dbContext != null)
                this.dbContext.Dispose();
        }
    }
}
