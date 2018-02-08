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
    public class UserRepository : IUserRepository
    {
        private readonly ClinicContext _db;

        public UserRepository(ClinicContext db)
        {
            _db = db;
        }

        public async Task<IList<User>> GetAll()
        {
            return await _db.Users.FromSql("sp_GetAllUsers").ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            var param = new SqlParameter("@Id", id);
            User user = await _db.Users.FromSql($"sp_GetUserById @Id", param).FirstOrDefaultAsync();
            return user;
        }

        public async Task<User> GetByEmail(string email)
        {
            var param = new SqlParameter("@Email", email);
            User user = await _db.Users.FromSql($"sp_GetUserByEmail @Email", param).FirstOrDefaultAsync();
            return user;
        }

        public async Task<int> Create(User user)
        {
            var createdId = new SqlParameter
            {
                ParameterName = "@CreatedId",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            string sql = $"exec @CreatedId = dbo.sp_CreateUser @BirthDay = '{user.BirthDay.ToString("yyyy-MM-dd")}', @Email = '{user.Email}', @FullName = '{user.FullName}', @Password = '{user.Password}', @RoleId = {user.RoleId}, @Address = '{user.Address}', @Image = '{user.Image}', @PhoneNumber = '{user.PhoneNumber}', @Sex = '{user.Sex}'";
            await _db.Database.ExecuteSqlCommandAsync(sql, createdId);
            return (int)createdId.Value;
        }

        public async Task<int> Update(User user)
        {
            var updateCounter = new SqlParameter
            {
                ParameterName = "@UpdateCounter",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            string sql = $"exec @UpdateCounter = dbo.sp_UpdateUser @Id = {user.Id},  @Email = '{user.Email}', @FullName = '{user.FullName}', @Password = '{user.Password}', @RoleId = {user.RoleId}, @Address = '{user.Address}', @Image = '{user.Image}', @PhoneNumber = '{user.PhoneNumber}', @Sex = '{user.Sex}'";
            await _db.Database.ExecuteSqlCommandAsync(sql, updateCounter);
            return (int)updateCounter.Value;
        }

        public async Task<int> Delete(int id)
        {
            var delCounter = new SqlParameter
            {
                ParameterName = "@DelCounter",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            string sql = $"exec @DelCounter = dbo.sp_DeleteUser @Id = {id}";            
            await _db.Database.ExecuteSqlCommandAsync(sql, delCounter);
            return (int)delCounter.Value;
        }
    }
}
