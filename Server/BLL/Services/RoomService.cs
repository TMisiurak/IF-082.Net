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
    public class RoomService : IRoomService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoomService(IUnitOfWork uow, IMapper mapper)
        {
            _unitOfWork = uow;
            _mapper = mapper;
        }

        public async Task<int> Create(RoomDTO roomDTO)
        {
            int result = await _unitOfWork.Rooms.Create(_mapper.Map<Room>(roomDTO));
            _unitOfWork.Commit();
            return result;
        }

        public async Task<int> DeleteById(int id)
        {
            int result = await _unitOfWork.Rooms.Delete(id);
            _unitOfWork.Commit();
            return result;
        }

        public async Task<IList<RoomDTO>> GetAll()
        {
            IList<Room> rooms = await _unitOfWork.Rooms.GetAll();
            var result = _mapper.Map<IList<RoomDTO>>(rooms);
            return result;
        }

        public async Task<RoomDTO> GetById(int id)
        {
            Room room = await _unitOfWork.Rooms.GetById(id);
            RoomDTO result = _mapper.Map<RoomDTO>(room);
            return result;
        }

        public Task<int> Update(RoomDTO item)
        {
            throw new NotImplementedException();
        }
    }
}
