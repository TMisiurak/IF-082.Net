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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork uow, IMapper mapper)
        {
            _unitOfWork = uow;
            _mapper = mapper;
        }

        public async Task<IList<UserDTO>> GetAll()
        {
            IList<User> users = await _unitOfWork.Users.GetAll();
            IList<UserDTO> result = _mapper.Map<IList<UserDTO>>(users);
            return result;
        }

        public async Task<UserDTO> GetById(int id)
        {
            User user = await _unitOfWork.Users.GetById(id);
            UserDTO result = _mapper.Map<UserDTO>(user);
            return result;
        }

        public async Task<UserDTO> GetByEmail(string email)
        {
            User user = await _unitOfWork.Users.GetByEmail(email);
            UserDTO result = _mapper.Map<UserDTO>(user);
            return result;
        }

        public async Task<int> Create(UserDTO userDTO)
        {
            userDTO.Password = HashService.HashPassword(userDTO.Password);
            int userId = await _unitOfWork.Users.Create(_mapper.Map<User>(userDTO));
            int result = await _unitOfWork.Patients.Create(new Patient() { UserId = userId });
            _unitOfWork.Commit();
            return result;
        }

        public async Task<int> Update(UserDTO userDTO)
        {
            userDTO.Password = HashService.HashPassword(userDTO.Password);
            int result = await _unitOfWork.Users.Update(_mapper.Map<User>(userDTO));
            _unitOfWork.Commit();
            return result;
        }

        public async Task<int> DeleteById(int id)
        {
            int result = await _unitOfWork.Users.Delete(id);
            _unitOfWork.Commit();
            return result;
        }
    }
}
