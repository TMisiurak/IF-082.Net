using DAL.EF;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using ProjectCore.Entities;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class PrescriptionRepository : IRepository<Prescription>
    {
            private readonly ClinicContext _db;

            public PrescriptionRepository(ClinicContext context)
            {
                _db = context;
            }

            public async Task<int> Create(Prescription item)
            {
                var createdId = new SqlParameter
                {
                    ParameterName = "@CreatedId",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };

                /*string sql = $"exec @CreatedId = dbo.sp_CreatePrescription @Date = '{item.Date.ToString("yyyy-MM-dd")}', " +
                        $"@Description = '{item.Description}'" +
                        $"@DiagnosisId = '{item.DiagnosisId}'" +
                        $"@DoctorId = '{item.DoctorId}'" +
                        $"@PatientId = '{item.PatientId}'";*/
                string sql = $"exec @CreatedId = dbo.sp_CreatePrescription @Date = '{item.Date.ToString("yyyy-MM-dd")}', @Description = '{item.Description}', @DiagnosisId = {item.DiagnosisId}, @DoctorId = '{item.DoctorId}', @PatientId = '{item.PatientId}'";
            
                await _db.Database.ExecuteSqlCommandAsync(sql, createdId);
                return (int)createdId.Value;
            }

        public async Task<int> Delete(int id)
            {
                var param = new SqlParameter
                {
                    ParameterName = "@DeletedId",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };

                string sql = $"exec @DeletedId = dbo.sp_DeletePrescription @id = {id}";

                int result1 = await _db.Database.ExecuteSqlCommandAsync(sql, param);
                return (int)param.Value;
            }

            public async Task<IList<Prescription>> GetAll()
            {
                return await _db.Prescriptions.FromSql("sp_GetAllPrescriptions").ToListAsync();
            }

            public async Task<Prescription> GetById(int id)
            {
                var param = new SqlParameter("@id", id);
                Prescription prescription = await _db.Prescriptions.FromSql($"sp_GetPrescriptionById @id", param).FirstOrDefaultAsync();
                return prescription;

            }

            public async Task<int> Update(Prescription item)
            {
                string sql = $"sp_UpdatePrescription @Date = '{item.Date}',  " +
                        $"@Description = '{item.Description}'" +
                        $"@DiagnosisId = '{item.DiagnosisId}'" +
                        $"@DoctorId = '{item.DoctorId}'" +
                        $"@PatientId = '{item.PatientId}'";
                int result = await _db.Database.ExecuteSqlCommandAsync(sql);
                return result;
            }
    }
}

