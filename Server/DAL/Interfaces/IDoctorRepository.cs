using ProjectCore.Entities;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        Task<Doctor> GetByUserId(int id);
    }
}
