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
    public class PrescriptionListRepository: IRepository<PrescriptionList>
    {
        private readonly ClinicContext _db;


        public PrescriptionListRepository(ClinicContext context)
        {
            _db = context;
        }

        public async Task<int> Create(PrescriptionList item)
        {
            var createdId = new SqlParameter
            {
                ParameterName = "@CreatedId",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            string sql = $"exec @CreatedId = dbo.sp_CreatePrescriptionList @ProcedureId = '{item.ProcedureId}', @DrugId = {item.DrugId}, @PrescriptionId = '{item.PrescriptionId}'";
            
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

            string sql = $"exec @DeletedId = dbo.sp_DeletePrescriptionList @id = {id}";

            int result1 = await _db.Database.ExecuteSqlCommandAsync(sql, param);
            return (int)param.Value;
        }

        public async Task<IList<PrescriptionList>> GetAll()
        {
            return await _db.PrescriptionLists.FromSql("sp_GetAllPrescriptionLists").ToListAsync();
        }

        public async Task<PrescriptionList> GetById(int id)
        {
            var param = new SqlParameter("@id", id);
            PrescriptionList prescriptionList = await _db.PrescriptionLists.FromSql($"sp_GetPrescriptionListById @id", param).FirstOrDefaultAsync();
            return prescriptionList;

        }
        
        public async Task<int> Update(PrescriptionList item)
        {
            var param = new SqlParameter
            {
                ParameterName = "@UpdateId",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            string sql = $"exec @UpdateId = dbo.sp_UpdatePrescriptionList @Id = '{item.Id}', " +
                            $"@ProcedureId = '{item.ProcedureId}',  " +
                            $"@DrugId = '{item.DrugId}', " +
                            $"@PrescriptionId = '{item.PrescriptionId}'";
            await _db.Database.ExecuteSqlCommandAsync(sql, param);
            return (int)param.Value; ;
        }
    }
}

