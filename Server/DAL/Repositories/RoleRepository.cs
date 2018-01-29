using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
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

        public Task<int> Create(Role item)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Role>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Role> GetById(int id)
        {
            var param = new SqlParameter("@id", id);
            Role user = await _db.Roles.FromSql($"sp_GetRoleById @id", param).FirstOrDefaultAsync();
            return user;
        }

        public Task<int> Update(Role item)
        {
            throw new NotImplementedException();
        }
    }
}