using ProjectCore.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPrescriptionService
    {
        Task<IList<PrescriptionDTO>> GetAll();
        Task<PrescriptionDTO> GetById(int id);
        Task<int> Create(PrescriptionDTO item);
        Task<int> Update(PrescriptionDTO item);
        Task<int> DeleteById(int id);
    }
}
