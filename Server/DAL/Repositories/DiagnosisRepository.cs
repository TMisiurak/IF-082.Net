using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using ProjectCore.Entities;
using System.Data.SqlClient;
using System.Data;

namespace DAL.Repositories
{
    class DiagnosisRepository : IRepository<Diagnosis>
    {
        private readonly ClinicContext _db;

        public DiagnosisRepository(ClinicContext context)
        {
            _db = context;
        }

        public async Task<int> Create(Diagnosis diagnosis)
        {
            var param = new SqlParameter
            {
                ParameterName = "@CreatedId",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };
            string sql = $"exec @CreatedId = sp_CreateDiagnosis @DiagnosisName = '{diagnosis.DiagnosisName}', @Description = '{diagnosis.Description}'";
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
            string sql = $"exec @resid = dbo.sp_DeleteDiagnosis @Id = {id}";
            int result = await _db.Database.ExecuteSqlCommandAsync(sql, param);
            return (int)param.Value;
        }

        public async Task<IList<Diagnosis>> GetAll()
        {
            return await _db.Diagnoses.FromSql("sp_GetAllDiagnoses").ToListAsync();
        }

        public async Task<Diagnosis> GetById(int id)
        {
            var param = new SqlParameter("@id", id);
            Diagnosis diagnosis = await _db.Diagnoses.FromSql($"sp_GetDiagnosisById @id", param).FirstOrDefaultAsync();
            return diagnosis;
        }

        public async Task<int> Update(Diagnosis diagnosis)
        {
            var updateCounter = new SqlParameter
            {
                ParameterName = "@UpdateCounter",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };
            string sql = $"exec @UpdateCounter = dbo.sp_UpdateDiagnosis @Id = '{diagnosis.Id}', @DiagnosisName = '{diagnosis.DiagnosisName}', @Description = '{diagnosis.Description}'";
            await _db.Database.ExecuteSqlCommandAsync(sql, updateCounter);
            return (int)updateCounter.Value;
        }
    }
}
