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
    public class ProcedureRepoDapper : IRepository<Procedure>
    {
        private IDbTransaction _transaction;
        private IDbConnection _connection { get { return _transaction.Connection; } }

        public ProcedureRepoDapper(IDbTransaction transaction)
        {
            _transaction = transaction;
        }

        public async Task<int> Create(Procedure procedure)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Name", procedure.Name);
            dynamicParameters.Add("@Price", procedure.Price);
            dynamicParameters.Add("@Room", procedure.Room);
            dynamicParameters.Add("@CreatedId", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            var result = await _connection.ExecuteAsync("sp_CreateProcedure", dynamicParameters, _transaction, commandType: CommandType.StoredProcedure);

            int createdId = dynamicParameters.Get<int>("@CreatedId");
            return createdId;
        }

        public async Task<int> Delete(int id)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Id", id);
            dynamicParameters.Add("@ResId", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            var result = await _connection.ExecuteAsync("sp_DeleteProcedure", dynamicParameters, _transaction, commandType: CommandType.StoredProcedure);

            int resetId = dynamicParameters.Get<int>("@ResId");
            return resetId;
        }

        public async Task<IList<Procedure>> GetAll()
        {
            var result = await _connection.QueryAsync<Procedure>("sp_GetAllProcedures", 0, _transaction, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<Procedure> GetById(int id)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@id", id);
            return await _connection.QuerySingleOrDefaultAsync<Procedure>("sp_GetProcedureById", dynamicParameters, _transaction, commandType: CommandType.StoredProcedure);
        }

        public Task<int> Update(Procedure item)
        {
            throw new NotImplementedException();
        }
    }
}
