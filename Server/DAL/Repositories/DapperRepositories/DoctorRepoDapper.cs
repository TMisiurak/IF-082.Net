using DAL.Interfaces;
using Dapper;
using ProjectCore.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace DAL.Repositories.DapperRepositories
{
    public class DoctorRepoDapper : IRepository<Doctor>
    {
        private IDbTransaction _transaction;
        private IDbConnection _connection { get { return _transaction.Connection; } }

        public DoctorRepoDapper(IDbTransaction transaction)
        {
            _transaction = transaction;
        }

        public async Task<int> Create(Doctor doctor)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@RoomID", doctor.RoomId);
            dynamicParameters.Add("@DepartmentId", doctor.DepartmentId);
            dynamicParameters.Add("@YearsExp", doctor.YearsExp);
            dynamicParameters.Add("@Speciality", doctor.Speciality);
            dynamicParameters.Add("@UserId", doctor.UserId);
            dynamicParameters.Add("@CreatedId", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            var result = await _connection.ExecuteAsync("sp_CreateDoctor", dynamicParameters, _transaction, commandType: CommandType.StoredProcedure);

            int createdId = dynamicParameters.Get<int>("@CreatedId");
            return createdId;
        }

        public async Task<int> Delete(int id)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Id", id);
            dynamicParameters.Add("@ResId", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            var result = await _connection.ExecuteAsync("sp_DeleteDoctor", dynamicParameters, _transaction, commandType: CommandType.StoredProcedure);

            int resetId = dynamicParameters.Get<int>("@ResId");
            return resetId;
        }

        public async Task<IList<Doctor>> GetAll()
        {
            var result = await _connection.QueryAsync<Doctor>("sp_GetAllDoctors", 0, _transaction, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<Doctor> GetById(int id)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@id", id);
            return await _connection.QuerySingleOrDefaultAsync<Doctor>("sp_GetDoctorById", dynamicParameters, _transaction, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Update(Doctor doctor)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@RoomID", doctor.RoomId);
            dynamicParameters.Add("@DepartmentId", doctor.DepartmentId);
            dynamicParameters.Add("@YearsExp", doctor.YearsExp);
            dynamicParameters.Add("@Speciality", doctor.Speciality);
            dynamicParameters.Add("@UserId", doctor.UserId);
            dynamicParameters.Add("@Id", doctor.Id);
            dynamicParameters.Add("@UpdatedCounter", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            var result = await _connection.ExecuteAsync("sp_UpdateDoctor", dynamicParameters, _transaction, commandType: CommandType.StoredProcedure);

            int updatedCounter = dynamicParameters.Get<int>("@UpdatedCounter");
            return updatedCounter;
        }
    }
}
