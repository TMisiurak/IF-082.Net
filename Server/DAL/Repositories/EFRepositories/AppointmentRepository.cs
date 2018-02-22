using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using ProjectCore.Entities;

namespace DAL.Repositories.EFRepositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private ClinicContext _db;

        public AppointmentRepository(ClinicContext clinicContext)
        {
            _db = clinicContext;
        }

        public async Task<IList<Appointment>> GetByDoctorId(int id)
        {
            var doctorId = new SqlParameter("@DoctorId", id);
            var appointments = await _db.Appointments.FromSql($"sp_GetAppointmentByDoctorId @DoctorId", doctorId).ToListAsync();

            return appointments;
        }

        public async Task<int> Create(Appointment appointment)
        {
            var param = new SqlParameter
            {
                ParameterName = "@CreatedId",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };
            string sql = $"exec @CreatedId = sp_CreateAppointment @PatientId = '{appointment.PatientId}', @DoctorId = '{appointment.DoctorId}', @Description = '{appointment.Description}', @Date = '{appointment.Date.ToString("yyyy-MM-dd")}', @Status = '{appointment.Status}'";
            int result = await _db.Database.ExecuteSqlCommandAsync(sql, param);
            return (int)param.Value;
        }

        public async Task<int> Delete(int id)
        {
            var param = new SqlParameter
            {
                ParameterName = "@resid",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };
            string sql = $"exec @resid = dbo.sp_DeleteAppointment @Id = {id}";
            int result = await _db.Database.ExecuteSqlCommandAsync(sql, param);
            return (int)param.Value;
        }

        public async Task<IList<Appointment>> GetAll()
        {
            return await _db.Appointments.FromSql("sp_GetAllAppointments").ToListAsync();
        }

        public async Task<Appointment> GetById(int id)
        {
            var param = new SqlParameter("@id", id);
            Appointment appointment = await _db.Appointments.FromSql($"sp_GetAppointmentById @id", param).FirstOrDefaultAsync();
            return appointment;
        }

        public async Task<int> Update(Appointment appointment)
        {

            var updateCounter = new SqlParameter
            {
                ParameterName = "@UpdateCounter",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };
            string sql = $"exec @UpdateCounter = dbo.sp_UpdateAppointment @Id = '{appointment.Id}', @PatientId = '{appointment.PatientId}', @DoctorId = '{appointment.DoctorId}', @Description = '{appointment.Description}', @Date = '{appointment.Date}', @Status = '{appointment.Status}'";
            await _db.Database.ExecuteSqlCommandAsync(sql, updateCounter);
            return (int)updateCounter.Value;
        }
    }
}
