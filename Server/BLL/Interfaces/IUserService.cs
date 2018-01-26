using BLL.DTO;
using DAL.Entities;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        void CreateUser(User userDTO);
        UserDTO GetUserById(int? id);
        UserDTO GetUserByEmail(string email);
        IEnumerable<UserDTO> GetUsers();
        void Dispose();
    }
}
