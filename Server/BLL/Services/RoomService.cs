using AutoMapper;
using BLL.Interfaces;
using DAL.Interfaces;
using ProjectCore.DTO;
using ProjectCore.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RoomService : IRoomService<RoomDTO>
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

        public async Task<IList<RoomDTO>> GetAll()
        {
            IList<Room> rooms = await DataBase.Rooms.GetAll();
            var result = _mapper.Map<IList<RoomDTO>>(rooms);
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
