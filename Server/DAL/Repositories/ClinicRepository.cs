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
            db = context;
        }

        public Task<int> Create(Clinic item)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Clinic>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Clinic> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Clinic item)
        {
            throw new NotImplementedException();
        }
    }
}