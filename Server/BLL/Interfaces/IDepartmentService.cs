using ProjectCore.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDepartmentService
    {
        Task<IList<DepartmentDTO>> GetAll();
        Task<DepartmentDTO> GetById(int id);
        Task<int> Create(DepartmentDTO item);
        Task<int> Update(DepartmentDTO item);
        Task<int> DeleteById(int id);
    }
}
