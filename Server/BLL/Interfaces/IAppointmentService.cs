using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProjectCore.DTO;

namespace BLL.Interfaces
{
    public interface IAppointmentService
    {
        Task<IList<AppointmentDTO>> GetAll();
        Task<AppointmentDTO> GetById(int id);
        Task<int> Create(AppointmentDTO item);
        Task<int> Update(AppointmentDTO item);
        Task<int> DeleteById(int id);
    }
}
