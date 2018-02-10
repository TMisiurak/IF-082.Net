using ProjectCore.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPrescriptionListService
    {
        Task<IList<PrescriptionListDTO>> GetAll();
        Task<PrescriptionListDTO> GetById(int id);
        Task<int> Create(PrescriptionListDTO item);
        Task<int> Update(PrescriptionListDTO item);
        Task<int> DeleteById(int id);
    }
}
