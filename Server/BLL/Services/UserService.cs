using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork DataBase { get; set; }
        public object KeyDerivation { get; private set; }

        IMapper _mapper;
        public UserService(IUnitOfWork uow, IMapper mapper)
        {
            DataBase = uow;
            _mapper = mapper;
        }

        public void CreateUser(User userDTO)
        {
            DataBase.Users.Create(userDTO);
            DataBase.Save();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public UserDTO GetUserById(int? id)
        {
            var user = DataBase.Users.Get(id.Value).Result;
            return _mapper.Map<UserDTO>(user);
        }

        public UserDTO GetUserByEmail(string email)
        {
            var user = DataBase.Users.Get(email);
            return _mapper.Map<UserDTO>(user);
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            Task<List<User>> users = DataBase.Users.GetAll();
            var result = _mapper.Map<List<UserDTO>>(users);
            return result;
        }
    }
}
