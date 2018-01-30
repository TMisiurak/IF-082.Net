using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ClinicContext _db;

        public UserRepository(ClinicContext db)
        {
            _db = db;
        }

        public async Task<List<User>> GetAll()
        {
            return await _db.Users.FromSql("sp_GetAllUsers").ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            var param = new SqlParameter("@id", id);
            User user = await _db.Users.FromSql($"sp_GetUserById @id", param).FirstOrDefaultAsync();
            return user;
        }

        public async Task<User> GetByEmail(string email)
        {
            var param = new SqlParameter("@email", email);
            User user = await _db.Users.FromSql($"sp_GetUserByEmail @email", param).FirstOrDefaultAsync();
            return user;
        }

        public async Task<int> Create(User user)
        {
            string sql = $"sp_CreateUser @BirthDay = '{user.BirthDay.ToString("yyyy-MM-dd")}', @Email = '{user.Email}', @FullName = '{user.FullName}', @Password = '{user.Password}', @RoleId = {user.RoleId}, @Address = '{user.Address}', @Image = '{user.Image}', @PhoneNumber = '{user.PhoneNumber}', @Sex = '{user.Sex}'";
            int result = await _db.Database.ExecuteSqlCommandAsync(sql);
            return result;
        }

        public async Task<int> Update(User user)
        {
            string sql = $"sp_UpdateUser @BirthDay = '{user.BirthDay.ToString("yyyy-MM-dd")}', @Email = '{user.Email}', @FullName = '{user.FullName}', @Password = '{user.Password}', @RoleId = {user.RoleId}, @Address = '{user.Address}', @Image = '{user.Image}', @PhoneNumber = '{user.PhoneNumber}', @Sex = '{user.Sex}'";
            int result = await _db.Database.ExecuteSqlCommandAsync(sql);
            //_db.Entry(user).State = EntityState.Modified;
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

            string sql = $"exec @resid = dbo.sp_DeleteUser @id = {id}";

            //string sql = $"sp_DeleteUser @id = {id}";
            int result1 = await _db.Database.ExecuteSqlCommandAsync(sql, param);
            return (int)param.Value;
        }
    }
}
