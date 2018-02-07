using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using ProjectCore.Entities;

namespace DAL.Repositories
{
    public class DrugRepository : IRepository<Drug>
    {
        private readonly ClinicContext _db;

        public DrugRepository(ClinicContext context)
        {
            _db = context;
        }


        public async Task<int> Create(Drug drug)
        {
            var param = new SqlParameter
            {
                ParameterName = "@CreatedId",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            string sql = $"exec @CreatedId = sp_CreateDrug @DrugName = '{drug.DrugName}'";
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

            string sql = $"exec @resid = dbo.sp_DeleteDrug @id = {id}";

            int result1 = await _db.Database.ExecuteSqlCommandAsync(sql, param);
            return (int)param.Value;
        }

        public async Task<IList<Drug>> GetAll()
        {
            return await _db.Drugs.FromSql("sp_GetAllDrugs").ToListAsync();  
        }

        public async Task<Drug> GetById(int id)
        {
            var param = new SqlParameter("@id", id);
            Drug drug = await _db.Drugs.FromSql($"sp_GetDrugById @id", param).FirstOrDefaultAsync();

            return drug;
        }

        public async Task<int> Update(Drug drug)
        {
            var updateCounter = new SqlParameter
            {
                ParameterName = "@UpdateCounter",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            string sql = $"exec @UpdateCounter = dbo.sp_UpdateDrug @Id = {drug.Id}, @DrugName = {drug.DrugName}";
            await _db.Database.ExecuteSqlCommandAsync(sql, updateCounter);
            return (int)updateCounter.Value;
        }
    }
}
