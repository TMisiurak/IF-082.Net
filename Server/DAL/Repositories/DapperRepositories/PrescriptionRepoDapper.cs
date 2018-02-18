using DAL.Interfaces;
using Dapper;
using ProjectCore.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories.DapperRepositories
{
    public class PrescriptionRepoDapper : IRepository<Prescription>
    {
        private IDbTransaction _transaction;
        private IDbConnection _connection { get { return _transaction.Connection; } }

        public PrescriptionRepoDapper(IDbTransaction transaction)
        {
            _transaction = transaction;
        }

        public Task<int> Create(Prescription item)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Prescription>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Prescription> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Update(Prescription item)
        {
            throw new System.NotImplementedException();
        }
    }
}
