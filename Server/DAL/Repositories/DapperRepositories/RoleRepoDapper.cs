using DAL.Interfaces;
using Dapper;
using ProjectCore.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories.DapperRepositories
{
    public class RoleRepoDapper : IRepository<Role>
    {
        private IDbTransaction _transaction;
        private IDbConnection _connection { get { return _transaction.Connection; } }

        public RoleRepoDapper(IDbTransaction transaction)
        {
            _transaction = transaction;
        }

        public async Task<int> Create(Role role)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Name", role.Name);
            dynamicParameters.Add("@CreatedId", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            await _connection.ExecuteAsync("sp_CreateRole", dynamicParameters, _transaction, commandType: CommandType.StoredProcedure);

            int createdId = dynamicParameters.Get<int>("@CreatedId");
            return createdId;
        }

        public async Task<int> Delete(int id)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Id", id);
            dynamicParameters.Add("@ResId", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            await _connection.ExecuteAsync("sp_DeleteRole", dynamicParameters, _transaction, commandType: CommandType.StoredProcedure);

            int resetId = dynamicParameters.Get<int>("@ResId");
            return resetId;
        }

        public async Task<IList<Role>> GetAll()
        {
            var result = await _connection.QueryAsync<Role>("sp_GetAllRoles", 0, _transaction, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<Role> GetById(int id)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Id", id);
            Role role = await _connection.QuerySingleOrDefaultAsync<Role>("sp_GetRoleById", dynamicParameters, _transaction, commandType: CommandType.StoredProcedure);
            return role;
        }

        public async Task<int> Update(Role role)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Name", role.Name);
            dynamicParameters.Add("@Id", role.Id);
            dynamicParameters.Add("@UpdatedCounter", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            await _connection.ExecuteAsync("sp_UpdateRole", dynamicParameters, _transaction, commandType: CommandType.StoredProcedure);

            int updatedCounter = dynamicParameters.Get<int>("@UpdatedCounter");
            return updatedCounter;
        }
    }
}
