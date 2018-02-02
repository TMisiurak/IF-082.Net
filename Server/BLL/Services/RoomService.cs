using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RoomService : IService<RoomDTO>
    {
        private readonly IUnitOfWork DataBase;
        private readonly IMapper _mapper;

        public RoomService(IUnitOfWork uow, IMapper mapper)
        {
            DataBase = uow;
            _mapper = mapper;
        }

        public async Task<int> Create(RoomDTO roomDTO)
        {
            int result = await DataBase.Rooms.Create(_mapper.Map<Room>(roomDTO));
            return result;
        }

        public async Task<int> DeleteById(int id)
        {
            int result = await DataBase.Rooms.Delete(id);
            return result;
        }

        public async Task<List<RoomDTO>> GetAll()
        {
            List<Room> rooms = await DataBase.Rooms.GetAll();
            var result = _mapper.Map<List<RoomDTO>>(rooms);
            return result;
        }

        public async Task<RoomDTO> GetById(int id)
        {
            Room room = await DataBase.Rooms.GetById(id);
            RoomDTO result = _mapper.Map<RoomDTO>(room);
            return result;
        }

        public Task<int> Update(RoomDTO item)
        {
            throw new NotImplementedException();
        }
    }
}
