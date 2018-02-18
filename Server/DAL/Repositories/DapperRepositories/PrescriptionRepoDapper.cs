using DAL.Interfaces;
using Dapper;
using ProjectCore.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories.DapperRepositories
{
    public class PrescriptionRepoDapper : IRepository<Prescription>
    {
        private IDbTransaction _transaction;
        private IDbConnection _connection { get { return _transaction.Connection; } }

        public PrescriptionRepoDapper(IDbTransaction transaction)
        {
            _transaction = transaction;
        }

        public async Task<int> Create(Prescription prescription)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Date", prescription.Date.ToString("yyyy-MM-dd"));
            dynamicParameters.Add("@Description", prescription.Description);
            dynamicParameters.Add("@DiagnosisId", prescription.DiagnosisId);
            dynamicParameters.Add("@DoctorId", prescription.DoctorId);
            dynamicParameters.Add("@PatientId", prescription.PatientId);
            dynamicParameters.Add("@CreatedId", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            var result = await _connection.ExecuteAsync("sp_CreatePrescription", dynamicParameters, _transaction, commandType: CommandType.StoredProcedure);

            int createdId = dynamicParameters.Get<int>("@CreatedId");
            return createdId;
        }

        public async Task<int> Delete(int id)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Id", id);
            dynamicParameters.Add("@ResId", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            var result = await _connection.ExecuteAsync("sp_DeletePrescription", dynamicParameters, _transaction, commandType: CommandType.StoredProcedure);

            int resetId = dynamicParameters.Get<int>("@ResId");
            return resetId;
        }

        public async Task<IList<Prescription>> GetAll()
        {
            var result = await _connection.QueryAsync<Prescription>("sp_GetAllPrescriptions", 0, _transaction, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<Prescription> GetById(int id)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@id", id);
            return await _connection.QuerySingleOrDefaultAsync<Prescription>("sp_GetPrescriptionById", dynamicParameters, _transaction, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Update(Prescription prescription)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Date", prescription.Date.ToString("yyyy-MM-dd"));
            dynamicParameters.Add("@Description", prescription.Description);
            dynamicParameters.Add("@DiagnosisId", prescription.DiagnosisId);
            dynamicParameters.Add("@DoctorId", prescription.DoctorId);
            dynamicParameters.Add("@PatientId", prescription.PatientId);
            dynamicParameters.Add("@Id", prescription.Id);
            dynamicParameters.Add("@UpdatedCounter", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            var result = await _connection.ExecuteAsync("sp_UpdatePrescription", dynamicParameters, _transaction, commandType: CommandType.StoredProcedure);

            int updatedCounter = dynamicParameters.Get<int>("@UpdatedCounter");
            return updatedCounter;
        }
    }
}
