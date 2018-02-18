using DAL.Interfaces;
using Dapper;
using ProjectCore.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace DAL.Repositories.DapperRepositories
{
    public class PrescriptionListRepoDapper : IRepository<PrescriptionList>
    {
        private IDbTransaction _transaction;
        private IDbConnection _connection { get { return _transaction.Connection; } }

        public PrescriptionListRepoDapper(IDbTransaction transaction)
        {
            _transaction = transaction;
        }

        public async Task<IList<PrescriptionList>> GetAll()
        {
            var result = await _connection.QueryAsync<PrescriptionList>("sp_GetAllPrescriptionLists", 0, _transaction, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<PrescriptionList> GetById(int id)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@id", id);
            return await _connection.QuerySingleOrDefaultAsync<PrescriptionList>("sp_GetPrescriptionListById", dynamicParameters, _transaction, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Create(PrescriptionList prescriptionList)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ProcedureId", prescriptionList.ProcedureId);
            dynamicParameters.Add("@DrugId", prescriptionList.DrugId);
            dynamicParameters.Add("@PrescriptionId", prescriptionList.PrescriptionId);
            dynamicParameters.Add("@CreatedId", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            var result = await _connection.ExecuteAsync("sp_CreatePrescriptionList", dynamicParameters, _transaction, commandType: CommandType.StoredProcedure);

            int createdId = dynamicParameters.Get<int>("@CreatedId");
            return createdId;
        }

        public async Task<int> Update(PrescriptionList prescriptionList)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ProcedureId", prescriptionList.ProcedureId);
            dynamicParameters.Add("@DrugId", prescriptionList.DrugId);
            dynamicParameters.Add("@PrescriptionId", prescriptionList.PrescriptionId);
            dynamicParameters.Add("@Id", prescriptionList.Id);
            dynamicParameters.Add("@UpdatedCounter", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            var result = await _connection.ExecuteAsync("sp_UpdatePrescriptionList", dynamicParameters, _transaction, commandType: CommandType.StoredProcedure);

            int updatedCounter = dynamicParameters.Get<int>("@UpdatedCounter");
            return updatedCounter;
        }

        public async Task<int> Delete(int id)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Id", id);
            dynamicParameters.Add("@ResId", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            var result = await _connection.ExecuteAsync("sp_DeletePrescriptionList", dynamicParameters, _transaction, commandType: CommandType.StoredProcedure);

            int resetId = dynamicParameters.Get<int>("@ResId");
            return resetId;
        }
    }
}
