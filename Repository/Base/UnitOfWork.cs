using Domain.Interfaces.Repository.Base;
using System.Data;

namespace Repository.Base
{
    public abstract class UnitOfWork<DbConnection> : IUnitOfWork where DbConnection : IDbConnection, new()
    {
        private IDbConnection _connection;
        public IDbConnection Connection => _connection ?? CreateConnection();

        private IDbTransaction _transaction;
        public IDbTransaction Transaction => _transaction;
        public string ConnectionString { get; set; }
        public UnitOfWork() { }

        internal IDbConnection CreateConnection()
        {
            _connection = new DbConnection
            {
                ConnectionString = ConnectionString
            };

            _connection.Open();
            return _connection;
        }

        public void BeginTransaction()
        {
            _transaction = _connection.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _connection?.Dispose();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }
    }
}
