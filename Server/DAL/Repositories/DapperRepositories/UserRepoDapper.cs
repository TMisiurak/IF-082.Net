using DAL.Interfaces;
using Dapper;
using ProjectCore.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories.DapperRepositories
{
    public class UserRepoDapper : IUserRepository
    {
        private IDbTransaction _transaction;
        private IDbConnection _connection { get { return _transaction.Connection; } }

        public UserRepoDapper(IDbTransaction transaction)
        {
            _transaction = transaction;
        }

        public async Task<int> Create(User user)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Address", user.Address);
            dynamicParameters.Add("@BirthDay", user.BirthDay);
            dynamicParameters.Add("@Email", user.Email);
            dynamicParameters.Add("@FullName", user.FullName);
            dynamicParameters.Add("@Image", user.Image);
            dynamicParameters.Add("@Password", user.Password);
            dynamicParameters.Add("@PhoneNumber", user.PhoneNumber);
            dynamicParameters.Add("@Sex", user.Sex);
            dynamicParameters.Add("@RoleId", user.RoleId);
            dynamicParameters.Add("@CreatedId", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            await _connection.ExecuteAsync("sp_CreateUser", dynamicParameters, _transaction, commandType: CommandType.StoredProcedure);

            int createdId = dynamicParameters.Get<int>("@CreatedId");
            return createdId;
        }

        public async Task<int> Delete(int id)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Id", id);
            dynamicParameters.Add("@ResId", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            var result = await _connection.ExecuteAsync("sp_DeleteUser", dynamicParameters, _transaction, commandType: CommandType.StoredProcedure);

            int resetId = dynamicParameters.Get<int>("@ResId");
            return resetId;
        }

        public async Task<IList<User>> GetAll()
        {
            var result = await _connection.QueryAsync<User>("sp_GetAllUsers", 0, _transaction, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<User> GetByEmail(string email)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Email", email);
            User user = await _connection.QuerySingleOrDefaultAsync<User>("sp_GetUserByEmail", dynamicParameters, _transaction, commandType: CommandType.StoredProcedure);
            return user;
        }

        public async Task<User> GetById(int id)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Id", id);
            User user = await _connection.QuerySingleOrDefaultAsync<User>("sp_GetUserById", dynamicParameters, _transaction, commandType: CommandType.StoredProcedure);
            return user;
        }

        public async Task<int> Update(User user)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Address", user.Address);
            dynamicParameters.Add("@BirthDay", user.BirthDay);
            dynamicParameters.Add("@Email", user.Email);
            dynamicParameters.Add("@FullName", user.FullName);
            dynamicParameters.Add("@Image", user.Image);
            dynamicParameters.Add("@Password", user.Password);
            dynamicParameters.Add("@PhoneNumber", user.PhoneNumber);
            dynamicParameters.Add("@Sex", user.Sex);
            dynamicParameters.Add("@RoleId", user.RoleId);
            dynamicParameters.Add("@Id", user.Id);
            dynamicParameters.Add("@UpdatedCounter", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            await _connection.ExecuteAsync("sp_UpdateUser", dynamicParameters, _transaction, commandType: CommandType.StoredProcedure);

            int updatedCounter = dynamicParameters.Get<int>("@UpdatedCounter");
            return updatedCounter;
        }
    }
}
