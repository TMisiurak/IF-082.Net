using System.Collections.Generic;
using DAL.Interfaces;
using System.Threading.Tasks;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Data;
using ProjectCore.Entities;

namespace DAL.Repositories.EFRepositories
{
    public class PatientRepository : IRepository<Patient>
    {
        private readonly ClinicContext _db;

        public PatientRepository(ClinicContext db)
        {
            _db = db;
        }

        public async Task<int> Create(Patient patient)
        {
            var createdId = new SqlParameter
            {
                ParameterName = "@CreatedId",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            string sql = $"exec @CreatedId = sp_CreatePatient @UserId = {patient.UserId}";
            await _db.Database.ExecuteSqlCommandAsync(sql, createdId);
            return (int)createdId.Value;
        }

        public async Task<IList<Patient>> GetAll()
        {
            return await _db.Patients.FromSql("sp_GetAllPatients").ToListAsync();
        }

        public async Task<int> Delete(int id)
        {
            var param = new SqlParameter
            {
                ParameterName = "@resid",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            string sql = $"exec @resid = dbo.sp_DeletePatient @id = {id}";

            int result1 = await _db.Database.ExecuteSqlCommandAsync(sql, param);
            return (int)param.Value;
        }

        public async Task<Patient> GetById(int id)
        {
            var param = new SqlParameter("@id", id);
            Patient patient = await _db.Patients.FromSql($"sp_GetPatientById @id", param).FirstOrDefaultAsync();
            return patient;
        }

        public async Task<int> Update(Patient patient)
        {
            var updateCounter = new SqlParameter
            {
                ParameterName = "@UpdateCounter",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            string sql = $"exec @UpdateCounter = dbo.sp_UpdatePatient @UserId = {patient.UserId},  @Id = {patient.Id}";
            await _db.Database.ExecuteSqlCommandAsync(sql, updateCounter);
            return (int)updateCounter.Value;
        }
    }
}
