using DAL.Interfaces;
using Dapper;
using ProjectCore.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories.DapperRepositories
{
    public class AppointmentRepoDapper : IRepository<Appointment>
    {
        private IDbTransaction _transaction;
        private IDbConnection _connection { get { return _transaction.Connection; } }

        public AppointmentRepoDapper(IDbTransaction transaction)
        {
            _transaction = transaction;
        }

        public async Task<int> Create(Appointment appointment)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@PatientId", appointment.PatientId);
            dynamicParameters.Add("@DoctorId", appointment.DoctorId);
            dynamicParameters.Add("@Description", appointment.Description);
            dynamicParameters.Add("@Date", appointment.Date);
            dynamicParameters.Add("@Status", appointment.Status);
            dynamicParameters.Add("@CreatedId", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            var result = await _connection.ExecuteAsync("sp_CreateAppointment", dynamicParameters, _transaction, commandType: CommandType.StoredProcedure);

            int createdId = dynamicParameters.Get<int>("@CreatedId");
            return createdId;
        }

        public async Task<int> Delete(int id)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Id", id);
            dynamicParameters.Add("@ResId", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            var result = await _connection.ExecuteAsync("sp_DeleteAppointment", dynamicParameters, _transaction, commandType: CommandType.StoredProcedure);

            int resetId = dynamicParameters.Get<int>("@ResId");
            return resetId;
        }

        public async Task<IList<Appointment>> GetAll()
        {
            var result = await _connection.QueryAsync<Appointment>("sp_GetAllAppointments", 0, _transaction, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<Appointment> GetById(int id)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@id", id);
            return await _connection.QuerySingleOrDefaultAsync<Appointment>("sp_GetAppointmentById", dynamicParameters, _transaction, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Update(Appointment appointment)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@PatientId", appointment.PatientId);
            dynamicParameters.Add("@DoctorId", appointment.DoctorId);
            dynamicParameters.Add("@Description", appointment.Description);
            dynamicParameters.Add("@Date", appointment.Date);
            dynamicParameters.Add("@Status", appointment.Status);
            dynamicParameters.Add("@Id", appointment.Id);
            dynamicParameters.Add("@UpdatedCounter", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            var result = await _connection.ExecuteAsync("sp_UpdateAppointment", dynamicParameters, _transaction, commandType: CommandType.StoredProcedure);

            int updatedCounter = dynamicParameters.Get<int>("@UpdatedCounter");
            return updatedCounter;
        }
    }
}
