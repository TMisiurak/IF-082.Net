using DAL.Interfaces;
using Dapper;
using ProjectCore.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace DAL.Repositories.DapperRepositories
{
    public class DoctorRepoDapper : IRepository<Doctor>
    {
        private IDbTransaction _transaction;
        private IDbConnection _connection { get { return _transaction.Connection; } }

        public DoctorRepoDapper(IDbTransaction transaction)
        {
            _transaction = transaction;
        }

        public Task<int> Create(Doctor item)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Doctor>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Doctor> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Update(Doctor item)
        {
            throw new System.NotImplementedException();
        }
    }
}
