﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class ClinicRepository : IRepository<Clinic>
    {
        private readonly ClinicContext _db;

        public ClinicRepository(ClinicContext context)
        {
            _db = context;
        }

        public async Task<int> Create(Clinic clinic)
        {
            string sql = $"sp_CreateClinic @Name = '{clinic.Name}', @Address = '{clinic.Address}'";
            int result = await _db.Database.ExecuteSqlCommandAsync(sql);
            return result;
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

        public async Task<List<Clinic>> GetAll()
        {
            return await _db.Clinics.FromSql("sp_GetAllClinics").ToListAsync();
        }

        public async Task<Clinic> GetById(int id)
        {
            var param = new SqlParameter("@id", id);
            Clinic clinic = await _db.Clinics.FromSql($"sp_GetClinicById @id", param).FirstOrDefaultAsync();

            return clinic;
        }

        public Task<int> Update(Clinic item)
        {
            throw new NotImplementedException();
        }
    }
}