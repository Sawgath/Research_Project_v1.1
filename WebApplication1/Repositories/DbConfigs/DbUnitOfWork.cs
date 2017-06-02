using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebApplication1.Interfaces;

namespace WebApplication1.Repositories
{
    public class DbUnitOfWork : IUnitOfWork, IDisposable
    {
        private IDbTransaction _transaction;
        private readonly Action<DbUnitOfWork> _rolledBack;
        private readonly Action<DbUnitOfWork> _committed;

        public DbUnitOfWork(IDbTransaction transaction, Action<DbUnitOfWork> rolledBack, Action<DbUnitOfWork> committed)
        {
            Transaction = transaction;
            _transaction = transaction;
            _rolledBack = rolledBack;
            _committed = committed;
        }

        public IDbTransaction Transaction { get; private set; }

        //public void Dispose()
        //{
        //    if (_transaction == null)
        //        return;

        //    _transaction.Rollback();
        //    _transaction.Dispose();
        //    _rolledBack(this);
        //    _transaction = null;
        //}

        public void SaveChanges()
        {
            if (_transaction == null)
                throw new InvalidOperationException("May not call save changes twice.");

            _transaction.Commit();
            _committed(this);
            _transaction = null;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _transaction.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}