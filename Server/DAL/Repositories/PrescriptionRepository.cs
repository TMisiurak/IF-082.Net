using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.EF;

namespace DAL.Repositories
{
    public class PrescriptionRepository : IRepository<PrescriptionRepository>
    {
            private readonly ClinicContext _db;

            public PrescriptionRepository(ClinicContext context)
            {
                _db = context;
            }

            public Task<int> Create(PrescriptionRepository item)
            {
                throw new NotImplementedException();
            }

            public Task<int> Delete(int id)
            {
                throw new NotImplementedException();
            }

            public Task<List<PrescriptionRepository>> GetAll()
            {
                throw new NotImplementedException();
            }

            public Task<PrescriptionRepository> GetById(int id)
            {
                throw new NotImplementedException();
            }

            public Task<int> Update(PrescriptionRepository item)
            {
                throw new NotImplementedException();
            }
    }
}

