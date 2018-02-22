using ProjectCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IScheduleRepository : IRepository<Schedule>
    {
        Task<IList<Schedule>> GetByDoctorId(int id);
    }
}
