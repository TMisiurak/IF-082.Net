using DAL.Interfaces;
using Dapper;
using ProjectCore.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories.DapperRepositories
{
    public class ScheduleRepoDapper : IScheduleRepository
    {
        private IDbTransaction _transaction;
        private IDbConnection _connection { get { return _transaction.Connection; } }

        public ScheduleRepoDapper(IDbTransaction transaction)
        {
            _transaction = transaction;
        }

        public async Task<IList<Schedule>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Schedule> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<Schedule>> GetByDoctorId(int id)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DoctorId", id);
            var schedule = await _connection.QueryAsync<Schedule>("sp_GetScheduleByDoctorId", dynamicParameters, _transaction, commandType: CommandType.StoredProcedure);
            return schedule.ToList();
        }

        public async Task<int> Create(Schedule item)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> Update(Schedule item)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
