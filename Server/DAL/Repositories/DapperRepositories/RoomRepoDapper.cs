using DAL.Interfaces;
using Dapper;
using ProjectCore.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace DAL.Repositories.DapperRepositories
{
    public class RoomRepoDapper : IRepository<Room>
    {
        private IDbTransaction _transaction;
        private IDbConnection _connection { get { return _transaction.Connection; } }

        public RoomRepoDapper(IDbTransaction transaction)
        {
            _transaction = transaction;
        }

        public Task<int> Create(Room item)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Room>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Room> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Update(Room item)
        {
            throw new System.NotImplementedException();
        }
    }
}
