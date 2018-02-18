using DAL.Interfaces;
using Dapper;
using ProjectCore.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace DAL.Repositories.DapperRepositories
{
    public class DepartmentRepoDapper : IRepository<Department>
    {
        private IDbTransaction _transaction;
        private IDbConnection _connection { get { return _transaction.Connection; } }

        public DepartmentRepoDapper(IDbTransaction transaction)
        {
            _transaction = transaction;
        }

        public async Task<int> Create(Department department)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Name", department.Name);
            dynamicParameters.Add("@ClinicId", department.ClinicId);
            dynamicParameters.Add("@CreatedId", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            var result = await _connection.ExecuteAsync("sp_CreateDepartment", dynamicParameters, _transaction, commandType: CommandType.StoredProcedure);

            int createdId = dynamicParameters.Get<int>("@CreatedId");
            return createdId;
        }

        public async Task<int> Delete(int id)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Id", id);
            dynamicParameters.Add("@ResId", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            var result = await _connection.ExecuteAsync("sp_DeleteDepartment", dynamicParameters, _transaction, commandType: CommandType.StoredProcedure);

            int resetId = dynamicParameters.Get<int>("@ResId");
            return resetId;
        }

        public async Task<IList<Department>> GetAll()
        {
            var result = await _connection.QueryAsync<Department>("sp_GetAllDepartments", 0, _transaction, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<Department> GetById(int id)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@id", id);
            return await _connection.QuerySingleOrDefaultAsync<Department>("sp_GetDepartmentById", dynamicParameters, _transaction, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Update(Department department)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Name", department.Name);
            dynamicParameters.Add("@ClinicId", department.ClinicId);
            dynamicParameters.Add("@Id", department.Id);
            dynamicParameters.Add("@UpdatedCounter", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            var result = await _connection.ExecuteAsync("sp_UpdateDepartment", dynamicParameters, _transaction, commandType: CommandType.StoredProcedure);

            int updatedCounter = dynamicParameters.Get<int>("@UpdatedCounter");
            return updatedCounter;
        }
    }
}
