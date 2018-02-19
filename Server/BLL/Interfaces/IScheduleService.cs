using ProjectCore.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IScheduleService
    {
        Task<IList<ScheduleDTO>> GetAll();
        Task<ScheduleDTO> GetById(int id);
        Task<int> Create(ScheduleDTO item);
        Task<int> Update(ScheduleDTO item);
        Task<int> DeleteById(int id);
    }
}
