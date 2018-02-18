using DAL.Interfaces;
using Dapper;
using ProjectCore.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace DAL.Repositories.DapperRepositories
{
    public class PaymentRepoDapper : IRepository<Payment>
    {
        private IDbTransaction _transaction;
        private IDbConnection _connection { get { return _transaction.Connection; } }

        public PaymentRepoDapper(IDbTransaction transaction)
        {
            _transaction = transaction;
        }

        public Task<int> Create(Payment item)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Payment>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Payment> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Update(Payment item)
        {
            throw new System.NotImplementedException();
        }
    }
}
