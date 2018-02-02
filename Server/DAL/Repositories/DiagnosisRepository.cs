using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.EF;
using DAL.Entities;

namespace DAL.Repositories
{
    class DiagnosisRepository : IRepository<Diagnosis>
    {
        private readonly ClinicContext _db;

        public DiagnosisRepository (ClinicContext context)
        {
            _db = context;
        }

        public Task<int> Create(Diagnosis item)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Diagnosis>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Diagnosis> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Diagnosis item)
        {
            throw new NotImplementedException();
        }
    }
}
