﻿using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ProjectCore.Entities;

namespace DAL.Repositories.EFRepositories
{
    public class ClinicRepository : IRepository<Clinic>
    {
        private ClinicContext _db;

        public ClinicRepository(ClinicContext db)
        {
            _db = db;
        }

        public async Task<int> Create(Clinic clinic)
        {
            var param = new SqlParameter
            {
                ParameterName = "@CreatedId",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            string sql = $"exec @CreatedId = sp_CreateClinic @Name = '{clinic.Name}', @Address = '{clinic.Address}'";
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

            string sql = $"exec @resid = dbo.sp_DeleteClinic @id = {id}";

            int result1 = await _db.Database.ExecuteSqlCommandAsync(sql, param);
            return (int)param.Value;
        }

        public async Task<IList<Clinic>> GetAll()
        {
            return await _db.Clinics.FromSql("sp_GetAllClinics").ToListAsync();
        }

        public async Task<Clinic> GetById(int id)
        {
            var param = new SqlParameter("@id", id);
            Clinic clinic = await _db.Clinics.FromSql($"sp_GetClinicById @id", param).FirstOrDefaultAsync();

            return clinic;
        }

        public async Task<int> Update(Clinic clinic)
        {
            var updateCounter = new SqlParameter
            {
                ParameterName = "@UpdateCounter",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            string sql = $"exec @UpdateCounter = dbo.sp_UpdateClinic @Name = '{clinic.Name}', @Address = '{clinic.Address}', @Id = {clinic.Id}";
            await _db.Database.ExecuteSqlCommandAsync(sql, updateCounter);
            return (int)updateCounter.Value;
        }
    }
}