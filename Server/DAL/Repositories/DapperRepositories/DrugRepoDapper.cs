using DAL.Interfaces;
using Dapper;
using ProjectCore.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace DAL.Repositories.DapperRepositories
{
    public class DrugRepoDapper : IRepository<Drug>
    {
        private IDbTransaction _transaction;
        private IDbConnection _connection { get { return _transaction.Connection; } }

        public DrugRepoDapper(IDbTransaction transaction)
        {
            _transaction = transaction;
        }

        public Task<int> Create(Drug item)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Drug>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Drug> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Update(Drug item)
        {
            throw new System.NotImplementedException();
        }
    }
}
