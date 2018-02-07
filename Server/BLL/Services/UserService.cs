﻿using AutoMapper;
using BLL.Interfaces;
using DAL.Interfaces;
using ProjectCore.DTO;
using ProjectCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService<UserDTO>
    {
        private readonly IUnitOfWork DataBase;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork uow, IMapper mapper)
        {
            DataBase = uow;
            _mapper = mapper;
        }

        public async Task<IList<UserDTO>> GetAll()
        {
            IList<User> users = await DataBase.Users.GetAll();
            var result = _mapper.Map<IList<UserDTO>>(users);
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
            return result;
        }

        public async Task<int> Update(UserDTO userDTO)
        {
            int result = await DataBase.Users.Update(_mapper.Map<User>(userDTO));
            return result;
        }

        public async Task<int> DeleteById(int id)
        {
            int result = await DataBase.Users.Delete(id);
            return result;
        }
    }
}
