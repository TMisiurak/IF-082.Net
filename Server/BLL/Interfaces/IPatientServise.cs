using ProjectCore.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPatientService
    {
        Task<IList<PatientDTO>> GetAll();
        Task<PatientDTO> GetById(int id);
        Task<IList<PatientUserDTO>> SearchPatient(string fullName);
        Task<int> Create(PatientDTO item);
        Task<int> Update(PatientDTO item);
        Task<int> DeleteById(int id);
    }
}
