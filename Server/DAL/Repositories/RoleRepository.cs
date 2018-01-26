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
    public class RoleRepository : IRepository<Role>
    {
        private readonly ClinicContext db;

        public RoleRepository(ClinicContext context)
        {
            this.db = context;
        }

        public async Task<List<Role>> GetAll()
        {
            return await db.Roles.FromSql("sp_GetAllRoles").ToListAsync();
        }

        public async Task<Role> Get(int id)
        {
            return await db.Roles.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Create(Role role)
        {
            db.Roles.Add(role);
        }

        public void Update(Role role)
        {
            db.Entry(role).State = EntityState.Modified;
        }

        public async Task<List<Role>> Find(Expression<Func<Role, bool>> predicate)
        {
            return await db.Roles.Where(predicate).ToListAsync();
        }

        public void Delete(int id)
        {
            Role role = db.Roles.Find(id);
            if (role != null)
                db.Roles.Remove(role);
        }
    }
}