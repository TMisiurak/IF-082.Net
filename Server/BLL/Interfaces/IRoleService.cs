using ProjectCore.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IRoleService
    {
        Task<IList<RoleDTO>> GetAll();
        Task<RoleDTO> GetById(int id);
        Task<int> Create(RoleDTO item);
        Task<int> Update(RoleDTO item);
        Task<int> DeleteById(int id);
    }
}
