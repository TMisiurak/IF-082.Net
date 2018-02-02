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
    public class RoleRepository : IRepository<Role>
    {
        private readonly ClinicContext _db;

        public RoleRepository(ClinicContext db)
        {
            _db = db;
        }

        public async Task<int> Create(Role role)
        {
            var param = new SqlParameter
            {
                ParameterName = "@CreatedId",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            string sql = $"exec @CreatedId = sp_CreateRole @Name = '{role.Name}'";
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

            string sql = $"exec @resid = dbo.sp_DeleteRole @id = {id}";

            //string sql = $"sp_DeleteUser @id = {id}";
            int result1 = await _db.Database.ExecuteSqlCommandAsync(sql, param);
            return (int)param.Value;
        }

        public async Task<List<Role>> GetAll()
        {
            return await _db.Roles.FromSql("sp_GetAllRoles").ToListAsync();
        }

        public async Task<Role> GetById(int id)
        {
            var param = new SqlParameter("@id", id);
            Role user = await _db.Roles.FromSql($"sp_GetRoleById @id", param).FirstOrDefaultAsync();
            return user;
        }

        public async Task<int> Update(Role role)
        {
            var updateCounter = new SqlParameter
            {
                ParameterName = "@UpdateCounter",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            string sql = $"exec @UpdateCounter = dbo.sp_UpdateRole @Name = '{role.Name}', @Id = {role.Id}";
            await _db.Database.ExecuteSqlCommandAsync(sql, updateCounter);
            return (int)updateCounter.Value;
        }
    }
}