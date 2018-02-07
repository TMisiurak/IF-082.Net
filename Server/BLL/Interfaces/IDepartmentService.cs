using ProjectCore.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDepartmentService<T> where T : DepartmentDTO
    {
        Task<IList<T>> GetAll();
        Task<T> GetById(int id);
        Task<int> Create(T item);
        Task<int> Update(T item);
        Task<int> DeleteById(int id);
    }
}
