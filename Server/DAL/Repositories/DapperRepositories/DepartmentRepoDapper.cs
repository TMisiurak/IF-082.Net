using DAL.Interfaces;
using Dapper;
using ProjectCore.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace DAL.Repositories.DapperRepositories
{
    public class DepartmentRepoDapper : IRepository<Department>
    {
        private IDbTransaction _transaction;
        private IDbConnection _connection { get { return _transaction.Connection; } }

        public DepartmentRepoDapper(IDbTransaction transaction)
        {
            _transaction = transaction;
        }

        public Task<int> Create(Department item)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Department>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Department> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Update(Department item)
        {
            throw new System.NotImplementedException();
        }
    }
}
