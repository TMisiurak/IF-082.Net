using DAL.Interfaces;
using Dapper;
using ProjectCore.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories.DapperRepositories
{
    public class ScheduleRepoDapper : IRepository<Schedule>
    {
        private IDbTransaction _transaction;
        private IDbConnection _connection { get { return _transaction.Connection; } }

        public ScheduleRepoDapper(IDbTransaction transaction)
        {
            _transaction = transaction;
        }

        public Task<IList<Schedule>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Schedule> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Create(Schedule item)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Update(Schedule item)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
