using ProjectCore.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDrugService
    {
        Task<IList<DrugDTO>> GetAll();
        Task<DrugDTO> GetById(int id);
        Task<int> Create(DrugDTO item);
        Task<int> Update(DrugDTO item);
        Task<int> DeleteById(int id);
    }
}
