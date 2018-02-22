using ProjectCore.Entities;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IPatientRepository : IRepository<Patient>
    {
        Task<Patient> GetByUserId(int id);
    }
}
