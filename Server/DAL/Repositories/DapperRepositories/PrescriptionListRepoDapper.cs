using DAL.Interfaces;
using Dapper;
using ProjectCore.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace DAL.Repositories.DapperRepositories
{
    public class PrescriptionListRepoDapper : IRepository<PrescriptionList>
    {
        private IDbTransaction _transaction;
        private IDbConnection _connection { get { return _transaction.Connection; } }

        public PrescriptionListRepoDapper(IDbTransaction transaction)
        {
            _transaction = transaction;
        }

        public Task<IList<PrescriptionList>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<PrescriptionList> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Create(PrescriptionList item)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Update(PrescriptionList item)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
