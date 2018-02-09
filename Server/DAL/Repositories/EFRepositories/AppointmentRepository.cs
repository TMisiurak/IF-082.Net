using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Interfaces;
using ProjectCore.Entities;

namespace DAL.Repositories.EFRepositories
{
    public class AppointmentRepository : IRepository<Appointment>
    {
        private ClinicContext _db;

        public AppointmentRepository(ClinicContext clinicContext)
        {
            _db = clinicContext;
        }

        public Task<int> Create(Appointment item)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Appointment>> GetAll()
        {
            throw new NotImplementedException();
            /*
            IList<Appointment> test = new List<Appointment>
            {
                new Appointment()
                {
                    Id = 1, CabinetId = 1, Date = DateTime.Now, Description = " ", DoctorId = 1, PatientId = 1, PrescriptionId = 1, Status = 2
                }
            };
            return (Task<IList<Appointment>>)test;
            */
        }

        public Task<Appointment> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Appointment item)
        {
            throw new NotImplementedException();
        }
    }
}
