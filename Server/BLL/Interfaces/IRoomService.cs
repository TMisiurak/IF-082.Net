using ProjectCore.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IRoomService
    {
        Task<IList<RoomDTO>> GetAll();
        Task<RoomDTO> GetById(int id);
        Task<int> Create(RoomDTO item);
        Task<int> Update(RoomDTO item);
        Task<int> DeleteById(int id);
    }
}
