using ProjectCore.DTO;

namespace BLL.Interfaces
{
    public interface IUserService : IService<UserDTO>
    {
        UserDTO GetByEmail(string email);
    }
}
