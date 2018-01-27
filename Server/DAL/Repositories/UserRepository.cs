using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepository<T> where T : class
    {
        private readonly ClinicContext db;
        private readonly DbSet<T> dbSet;

        public UserRepository(ClinicContext context)
        {
            db = context;
            dbSet = context.Set<T>();
        }

        public List<T> GetAll()
        {
            string x = $"sp_GetAll{typeof(T).Name}s";
            return dbSet.FromSql(x).ToList();
        }

        public async Task<User> Get(int id)
        {
            //System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@id", id);
           // return await db.Users.FromSql("sp_GetUserById @id", param).FirstOrDefaultAsync();

            return await db.Users.FirstOrDefaultAsync(x => x.Id == id);
            //return user;
        }

        public User Get(string email)
        {
            //System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@email", email);
            //User user = db.Users.FromSql("sp_GetUserByEmail @email", param).FirstOrDefault();
            return  db.Users.Where(x => x.Email == email).FirstOrDefault();
        }

        public void Create(T user)
        {
            //var sql = string.Format("dbo.sp_CreateUser @Address = {0}, @BirthDay = {1}, @Email = {2}, @FullName = {3}, @Image = {4}," +
            //" @Password = {5}, @PhoneNumber = {6}, @Sex = {7}, @RoleId = {8}",
            //user.Address, user.BirthDay, user.Email, user.FullName, user.Image, user.Password, user.PhoneNumber, user.Sex, user.RoleId);
            //var userType = db.Database.ExecuteSqlCommand(sql);
            //System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@name", "Samsung");
            //var phones = db.Set<T>().FromSql("sp_CreateUser @Address = {0}, @BirthDay = {1}, @Email = {2}, @FullName = {3}, @Image = {4}," +
            //" @Password = {5}, @PhoneNumber = {6}, @Sex = {7}, @RoleId = {8}",
            //user.Address, user.BirthDay, user.Email, user.FullName, user.Image, user.Password, user.PhoneNumber, user.Sex, user.RoleId);
            dbSet.Add(user);
        }

        public void Update(User user)
        {
            db.Entry(user).State = EntityState.Modified;
        }

        public async Task<List<User>> Find(Expression<Func<User, bool>> predicate)
        {
            return await db.Users.Where(predicate).ToListAsync();
        }

        public void Delete(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
                db.Users.Remove(user);
        }
    }
}
