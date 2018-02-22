using ProjectCore.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDoctorService
    {
        Task<IList<DoctorDTO>> GetAll();
        Task<DoctorDTO> GetById(int id);
        Task<int> Create(DoctorDTO doctorDTO);
        Task<int> Update(DoctorDTO doctorDTO);
        Task<IList<DoctorUserDTO>> SearchDotor(string fullName);
        Task<int> DeleteById(int id);
    }
}
