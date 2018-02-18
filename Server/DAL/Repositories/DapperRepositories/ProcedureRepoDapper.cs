using DAL.Interfaces;
using Dapper;
using ProjectCore.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace DAL.Repositories.DapperRepositories
{
    public class ProcedureRepoDapper : IRepository<Procedure>
    {
        private IDbTransaction _transaction;
        private IDbConnection _connection { get { return _transaction.Connection; } }

        public ProcedureRepoDapper(IDbTransaction transaction)
        {
            _transaction = transaction;
        }

        public Task<int> Create(Procedure item)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Procedure>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Procedure> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Update(Procedure item)
        {
            throw new System.NotImplementedException();
        }
    }
}
