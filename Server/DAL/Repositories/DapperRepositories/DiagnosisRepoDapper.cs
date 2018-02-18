using DAL.Interfaces;
using Dapper;
using ProjectCore.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace DAL.Repositories.DapperRepositories
{
    public class DiagnosisRepoDapper : IRepository<Diagnosis>
    {
        private IDbTransaction _transaction;
        private IDbConnection _connection { get { return _transaction.Connection; } }

        public DiagnosisRepoDapper(IDbTransaction transaction)
        {
            _transaction = transaction;
        }

        public Task<int> Create(Diagnosis item)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Diagnosis>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Diagnosis> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Update(Diagnosis item)
        {
            throw new System.NotImplementedException();
        }
    }
}
