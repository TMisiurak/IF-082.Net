using DAL.Interfaces;
using Dapper;
using ProjectCore.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories.DapperRepositories
{
    public class PatientRepoDapper : IRepository<Patient>
    {
        private IDbTransaction _transaction;
        private IDbConnection _connection { get { return _transaction.Connection; } }

        public PatientRepoDapper(IDbTransaction transaction)
        {
            _transaction = transaction;
        }

        public Task<int> Create(Patient item)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Patient>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Patient> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Update(Patient item)
        {
            throw new System.NotImplementedException();
        }
    }
}
