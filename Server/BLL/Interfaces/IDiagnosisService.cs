using ProjectCore.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDiagnosisService
    {
        Task<IList<DiagnosisDTO>> GetAll();
        Task<DiagnosisDTO> GetById(int id);
        Task<int> Create(DiagnosisDTO item);
        Task<int> Update(DiagnosisDTO item);
        Task<int> DeleteById(int id);
    }
}
