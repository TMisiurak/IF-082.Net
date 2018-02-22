using ProjectCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        Task<IList<Appointment>> GetByDoctorId(int id);
    }
}
