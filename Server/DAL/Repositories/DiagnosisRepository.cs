using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.EF;

namespace DAL.Repositories
{
    class DiagnosisRepository : IRepository<DiagnosisRepository>
    {
        private readonly ClinicContext _db;

        public DiagnosisRepository (ClinicContext context)
        {
            _db = context;
        }

        public Task<int> Create(DiagnosisRepository item)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<DiagnosisRepository>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<DiagnosisRepository> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(DiagnosisRepository item)
        {
            throw new NotImplementedException();
        }
    }
}
