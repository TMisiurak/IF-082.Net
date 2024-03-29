﻿using DAL.Interfaces;
using Dapper;
using ProjectCore.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories.DapperRepositories
{
    public class PatientRepoDapper : IPatientRepository
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
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Id", id);
            dynamicParameters.Add("@ResId", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            var result = await _connection.ExecuteAsync("sp_DeletePatient", dynamicParameters, _transaction, commandType: CommandType.StoredProcedure);

            int resetId = dynamicParameters.Get<int>("@ResId");
            return resetId;
        }

        public async Task<IList<Patient>> GetAll()
        {
            var result = await _connection.QueryAsync<Patient>("sp_GetAllPatients", 0, _transaction, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<Patient> GetById(int id)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@id", id);
            return await _connection.QuerySingleOrDefaultAsync<Patient>("sp_GetPatientById", dynamicParameters, _transaction, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Update(Patient patient)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@UserId", patient.UserId);
            dynamicParameters.Add("@Id", patient.Id);
            dynamicParameters.Add("@UpdatedCounter", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            var result = await _connection.ExecuteAsync("sp_UpdatePatient", dynamicParameters, _transaction, commandType: CommandType.StoredProcedure);

            int updatedCounter = dynamicParameters.Get<int>("@UpdatedCounter");
            return updatedCounter;
        }

        public async Task<Patient> GetByUserId(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
