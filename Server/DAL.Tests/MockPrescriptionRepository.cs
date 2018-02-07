using DAL.Interfaces;
using ProjectCore.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Tests
{
    public class MockPrescriptionRepository : IRepository<Prescription>
    {
            IList<Prescription> mockPrescriptions;

            public MockPrescriptionRepository()
            {
                mockPrescriptions = new List<Prescription>
                {
                    new Prescription{ DoctorId = 1, PatientId = 1, Description = "tablets",
                    Date = DateTime.Now, DiagnosisId = 1},
                    new Prescription{ DoctorId = 1, PatientId = 1, Description = "tea",
                    Date = DateTime.Now, DiagnosisId = 2},
                    new Prescription{ DoctorId = 1, PatientId = 1, Description = "nimesil",
                    Date = DateTime.Now, DiagnosisId = 3},
                };
            }

            public Task<IList<Prescription>> GetAll()
            {
                Task.Delay(1000);
                return Task.Run(() => mockPrescriptions);
            }
            //
            public Task<int> Create(Prescription item)
            {
                throw new NotImplementedException();
            }

            public Task<int> Delete(int id)
            {
                throw new NotImplementedException();
            }

            public Task<Role> GetById(int id)
            {
                throw new NotImplementedException();
            }

            public Task<int> Update(Prescription item)
            {
                throw new NotImplementedException();
            }

        Task<Prescription> IRepository<Prescription>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
