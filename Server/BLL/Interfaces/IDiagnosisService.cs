using ProjectCore.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDiagnosisService<T> where T : DiagnosisDTO
    {
        Task<IList<T>> GetAll();
        Task<T> GetById(int id);
        Task<int> Create(T item);
        Task<int> Update(T item);
        Task<int> DeleteById(int id);
    }
}
