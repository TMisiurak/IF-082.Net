using DAL.Interfaces;
using Dapper;
using ProjectCore.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories.DapperRepositories
{
    public class ClinicRepoDapper : IRepository<Clinic>
    {
        private readonly string connectionString = null;

        public ClinicRepoDapper(string conn)
        {
            connectionString = conn;
        }

        public async Task<int> Create(Clinic clinic)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                //SqlTransaction sqltrans = connection.BeginTransaction();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Name", clinic.Name);
                dynamicParameters.Add("@Address", clinic.Address);
                dynamicParameters.Add("@CreatedId", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                await connection.ExecuteAsync("sp_CreateClinic", dynamicParameters, commandType: CommandType.StoredProcedure);

                int createdId = dynamicParameters.Get<int>("@CreatedId");
                return createdId;
            }
        }

        public async Task<int> Delete(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Id", id);
                dynamicParameters.Add("@ResId", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                await connection.ExecuteAsync("sp_DeleteClinic", dynamicParameters, commandType: CommandType.StoredProcedure);

                int resetId = dynamicParameters.Get<int>("@ResId");
                return resetId;
            }
        }

        public async Task<IList<Clinic>> GetAll()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var result = await connection.QueryAsync<Clinic>("sp_GetAllClinics");
                return result.ToList();
            }
        }

        public async Task<Clinic> GetById(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@id", id);
                return await connection.QuerySingleOrDefaultAsync<Clinic>(
                    "sp_GetClinicById",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> Update(Clinic clinic)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                //SqlTransaction sqltrans = connection.BeginTransaction();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Name", clinic.Name);
                dynamicParameters.Add("@Address", clinic.Address);
                dynamicParameters.Add("@Id", clinic.Id);
                dynamicParameters.Add("@UpdatedCounter", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                await connection.ExecuteAsync("sp_UpdateClinic", dynamicParameters, commandType: CommandType.StoredProcedure);

                int updatedCounter = dynamicParameters.Get<int>("@UpdatedCounter");
                return updatedCounter;
            }
        }
    }
}
