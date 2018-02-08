using ProjectCore.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IClinicService
    {
        Task<IList<ClinicDTO>> GetAll();
        Task<ClinicDTO> GetById(int id);
        Task<int> Create(ClinicDTO item);
        Task<int> Update(ClinicDTO item);
        Task<int> DeleteById(int id);
    }
}
