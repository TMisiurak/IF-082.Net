using ProjectCore.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        Task<IList<UserDTO>> GetAll();
        Task<UserDTO> GetById(int id);
        Task<int> Create(UserDTO item);
        Task<int> Update(UserDTO item);
        Task<int> DeleteById(int id);
        Task<UserDTO> GetByEmail(string email);
    }
}
