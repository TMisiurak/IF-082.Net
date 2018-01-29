using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork DataBase;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork uow, IMapper mapper)
        {
            DataBase = uow;
            _mapper = mapper;
        }

        public async Task<List<UserDTO>> GetAll()
        {
            List<User> users = await DataBase.Users.GetAll();
            var result = _mapper.Map<List<UserDTO>>(users);
            return result;
        }

        public async Task<UserDTO> GetById(int id)
        {
            User user = await DataBase.Users.GetById(id);
            return _mapper.Map<UserDTO>(user);
        }

        public UserDTO GetByEmail(string email)
        {
            var user = DataBase.Users.GetByEmail(email);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<int> Create(UserDTO userDTO)
        {
            int result = await DataBase.Users.Create(_mapper.Map<User>(userDTO));
            //DataBase.Save();
            return result;
        }

        public Task<int> Update(UserDTO item)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteById(int id)
        {
            int result = await DataBase.Users.Delete(id);
            return result;
        }

        public void Dispose()
        {
            DataBase.Dispose();
        }
    }
}
