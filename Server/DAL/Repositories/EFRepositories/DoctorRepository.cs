using DAL.EF;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using ProjectCore.Entities;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DAL.Repositories.EFRepositories
{
    public class DoctorRepository : IRepository<Doctor>
    {
        private readonly ClinicContext _db;

        public DoctorRepository(ClinicContext db)
        {
            _db = db;
        }

        public async Task<int> Create(Doctor doctor)
        {
            var param = new SqlParameter
            {
                ParameterName = "@CreatedId",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };


            string sql = $"exec @CreatedId = sp_CreateDoctor @RoomID = {doctor.RoomId}, @DepartmentId = {doctor.DepartmentId}, @YearsExp = {doctor.YearsExp}, @Speciality = '{doctor.Speciality}', @UserId = {doctor.UserId}";
            int result = await _db.Database.ExecuteSqlCommandAsync(sql, param);
            return (int)param.Value;
        }

        public async Task<int> Delete(int id)
        {
            var delCounter = new SqlParameter
            {
                ParameterName = "@DelCounter",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            string sql = $"exec @DelCounter = dbo.sp_DeleteDoctor @Id = {id}";
            await _db.Database.ExecuteSqlCommandAsync(sql, delCounter);
            return (int)delCounter.Value;
        }

        public async Task<IList<Doctor>> GetAll()
        {
            return await _db.Doctors.FromSql("sp_GetAllDoctors").ToListAsync();
        }

        public async Task<Doctor> GetById(int id)
        {
            var param = new SqlParameter("@Id", id);
            Doctor doctor = await _db.Doctors.FromSql($"sp_GetDoctorById @Id", param).FirstOrDefaultAsync();
            return doctor;
        }

        public async Task<int> Update(Doctor doctor)
        {
            var updateCounter = new SqlParameter
            {
                ParameterName = "@UpdateDoctor",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            string sql = $"exec @UpdateDoctor = dbo.sp_UpdateDoctor @Id = {doctor.Id}, @RoomID = {doctor.RoomId}, @DepartmentId = {doctor.DepartmentId}, @YearsExp = {doctor.YearsExp}, @Speciality = '{doctor.Speciality}', @UserId = {doctor.UserId}";
            await _db.Database.ExecuteSqlCommandAsync(sql, updateCounter);
            return (int)updateCounter.Value;
        }
    }
}
