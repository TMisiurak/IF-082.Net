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
    public class DepartmentRepository : IRepository<Department>
    {
        private readonly ClinicContext _db;

        public DepartmentRepository(ClinicContext db)
        {
            _db = db;
        }


        public async Task<int> Create(Department department)
        {
            string sql = $"sp_CreateDepartment   @Name = '{department.Name}',  @ClinicId = '{department.ClinicId}'";
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

            string sql = $"exec @resid = dbo.sp_DeleteDepartment @id = {id}";

            int result = await _db.Database.ExecuteSqlCommandAsync(sql, param);
            return (int)param.Value;
        }



        public async Task<IList<Department>> GetAll()
        {
            return await _db.Departments.FromSql("sp_GetAllDepartments").ToListAsync();
        }



        public async Task<Department> GetById(int id)
        {
            var param = new SqlParameter("@id", id);
            Department department = await _db.Departments.FromSql($"sp_GetDepartmentById @id", param).FirstOrDefaultAsync();
            return department;
        }

        public async Task<int> Update(Department department)
        {
            var updateCounter = new SqlParameter
            {
                ParameterName = "@UpdateCounter",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            string sql = $"exec @UpdateCounter = dbo.sp_UpdateDepartment @ClinicId = {department.ClinicId}, @Name = '{department.Name}',  @Id = {department.Id}";
            await _db.Database.ExecuteSqlCommandAsync(sql, updateCounter);
            return (int)updateCounter.Value;

            //string sql = $"sp_UpdateDepartment   @DepName = '{department.Name}',  @ClinicId = '{department.ClinicId}'";
            //int result = await _db.Database.ExecuteSqlCommandAsync(sql);
            //return result;
            //db.Entry(department).State = EntityState.Modified;

        }
    }
}
