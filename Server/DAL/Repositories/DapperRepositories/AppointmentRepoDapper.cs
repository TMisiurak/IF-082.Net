using DAL.Interfaces;
using Dapper;
using ProjectCore.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories.DapperRepositories
{
    public class AppointmentRepoDapper : IRepository<Appointment>
    {
        private IDbTransaction _transaction;
        private IDbConnection _connection { get { return _transaction.Connection; } }

        public AppointmentRepoDapper(IDbTransaction transaction)
        {
            _transaction = transaction;
        }

        public Task<int> Create(Appointment item)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Appointment>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Appointment> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Update(Appointment item)
        {
            throw new System.NotImplementedException();
        }
    }
}
