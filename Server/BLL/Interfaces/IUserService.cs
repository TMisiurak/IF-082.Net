using ProjectCore.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService<T> where T : UserDTO
    {
        Task<IList<T>> GetAll();
        Task<T> GetById(int id);
        Task<int> Create(T item);
        Task<int> Update(T item);
        Task<int> DeleteById(int id);
        UserDTO GetByEmail(string email);
    }
}
