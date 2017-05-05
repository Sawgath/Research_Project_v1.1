using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;
using WebApplication1.Interfaces;

namespace WebApplication1.Repositories
{
    public class DbContext
    {

        private readonly IDbConnection _connection;
        private readonly IConnectionFactory _connectionFactory;
        private readonly ReaderWriterLockSlim _rwLock = new ReaderWriterLockSlim();
        private readonly LinkedList<DbUnitOfWork> _uows = new LinkedList<DbUnitOfWork>();

        public DbContext(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
            _connection = _connectionFactory.Create();
        }

        public IUnitOfWork CreateUnitOfWork()
        {
            var transaction = _connection.BeginTransaction();
            var uow = new DbUnitOfWork(transaction, RemoveTransaction, RemoveTransaction);

            _rwLock.EnterWriteLock();
            _uows.AddLast(uow);
            _rwLock.ExitWriteLock();

            return uow;
        }

        public IDbCommand CreateCommand()
        {
            var cmd = _connection.CreateCommand();

            _rwLock.EnterReadLock();
            if (_uows.Count > 0)
                cmd.Transaction = _uows.First.Value.Transaction;
            _rwLock.ExitReadLock();

            return cmd;
        }

        private void RemoveTransaction(DbUnitOfWork obj)
        {
            _rwLock.EnterWriteLock();
            _uows.Remove(obj);
            _rwLock.ExitWriteLock();
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }

}