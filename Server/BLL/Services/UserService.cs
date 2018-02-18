using AutoMapper;
using BLL.Interfaces;
using DAL.Interfaces;
using ProjectCore.DTO;
using ProjectCore.Entities;
using ProjectCore.Helpers;
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

        public async Task<IList<UserDTO>> GetAll()
        {
            IList<User> users = await DataBase.Users.GetAll();
            IList<UserDTO> result = _mapper.Map<IList<UserDTO>>(users);
            return result;
        }

        public async Task<UserDTO> GetById(int id)
        {
            User user = await DataBase.Users.GetById(id);
            UserDTO result = _mapper.Map<UserDTO>(user);
            return result;
        }

        public async Task<UserDTO> GetByEmail(string email)
        {
            User user = await DataBase.Users.GetByEmail(email);
            UserDTO result = _mapper.Map<UserDTO>(user);
            return result;
        }

        public async Task<int> Create(UserDTO userDTO)
        {
            userDTO.Password = HashService.HashPassword(userDTO.Password);
            int result = await DataBase.Users.Create(_mapper.Map<User>(userDTO));
            DataBase.Commit();
            return result;
        }

        public async Task<int> Update(UserDTO userDTO)
        {
            userDTO.Password = HashService.HashPassword(userDTO.Password);
            int result = await DataBase.Users.Update(_mapper.Map<User>(userDTO));
            DataBase.Commit();
            return result;
        }

        public async Task<int> DeleteById(int id)
        {
            int result = await DataBase.Users.Delete(id);
            DataBase.Commit();
            return result;
        }
    }
}
