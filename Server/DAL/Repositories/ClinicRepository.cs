

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class ClinicRepository : IRepository<Clinic>
    {
        private readonly ClinicContext db;

        public ClinicRepository(ClinicContext context)
        {
            this.db = context;
        }

        public async Task<List<Clinic>> GetAll()
        {
            return await db.Clinics.FromSql("sp_GetAllClinics").ToListAsync();
        }

        public async Task<Clinic> Get(int id)
        {
            return await db.Clinics.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Create(Clinic clinic)
        {
            db.Clinics.Add(clinic);
        }

        public void Update(Clinic clinic)
        {
            db.Entry(clinic).State = EntityState.Modified;
        }

        public async Task<List<Clinic>> Find(Expression<Func<Clinic, bool>> predicate)
        {
            return await db.Clinics.Where(predicate).ToListAsync();
        }

        public void Delete(int id)
        {
            Clinic clinic = db.Clinics.Find(id);
            if (clinic != null)
                db.Clinics.Remove(clinic);
        }
    }
}