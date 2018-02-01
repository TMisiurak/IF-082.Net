using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ProcedureRepository : IRepository<Procedure>
    {
        private readonly ClinicContext _db;

        public ProcedureRepository(ClinicContext context)
        {
            _db = context;
        }

        public async Task<int> Create(Procedure procedure)
        {
            var param = new SqlParameter
            {
                ParameterName = "@CreatedId",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            decimal price = procedure.Price;

            string sql = $"exec @CreatedId = sp_CreateProcedure @Name = '{procedure.Name}', @Price = {price}, @Room = {procedure.Room}";
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

            string sql = $"exec @resid = dbo.sp_DeleteProcedure @id = {id}";

            int result1 = await _db.Database.ExecuteSqlCommandAsync(sql, param);
            return (int)param.Value;
        }

        public async Task<List<Procedure>> GetAll()
        {
            return await _db.Procedures.FromSql("sp_GetAllProcedures").ToListAsync();
        }

        public async Task<Procedure> GetById(int id)
        {
            var param = new SqlParameter("@id", id);
            Procedure procedure = await _db.Procedures.FromSql($"sp_GetProcedureById @id", param).FirstOrDefaultAsync();

            return procedure;
        }

        public Task<int> Update(Procedure item)
        {
            throw new NotImplementedException();
        }
    }
}
