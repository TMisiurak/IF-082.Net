using BLL.DTO;
using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService : IService<UserDTO>
    {
        UserDTO GetByEmail(string email);
    }
}
