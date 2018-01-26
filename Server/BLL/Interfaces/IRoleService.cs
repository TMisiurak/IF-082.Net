using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IRoleService
    {
        void CreateRole(RoleDTO roleDTO);
        string GetRoleById(int? id);
        void Dispose();
    }
}
