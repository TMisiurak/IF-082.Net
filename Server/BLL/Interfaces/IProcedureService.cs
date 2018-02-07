using ProjectCore.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IProcedureService
    {
        Task<IList<ProcedureDTO>> GetAll();
        Task<ProcedureDTO> GetById(int id);
        Task<int> Create(ProcedureDTO item);
        Task<int> Update(ProcedureDTO item);
        Task<int> DeleteById(int id);
    }
}
