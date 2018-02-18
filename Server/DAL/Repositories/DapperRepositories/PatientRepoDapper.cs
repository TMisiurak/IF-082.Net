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

        public async Task<int> Create(Patient patient)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@UserId", patient.UserId);
            dynamicParameters.Add("@CreatedId", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            await _connection.ExecuteAsync("sp_CreatePatient", dynamicParameters, _transaction, commandType: CommandType.StoredProcedure);

            int createdId = dynamicParameters.Get<int>("@CreatedId");
            return createdId;
        }

        public async Task<int> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<Patient>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Patient> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> Update(Patient item)
        {
            throw new System.NotImplementedException();
        }
    }
}
