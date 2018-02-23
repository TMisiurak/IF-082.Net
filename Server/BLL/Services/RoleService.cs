using AutoMapper;
using BLL.Interfaces;
using DAL.Interfaces;
using ProjectCore.DTO;
using ProjectCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoleService(IUnitOfWork uow, IMapper mapper)
        {
            _unitOfWork = uow;
            _mapper = mapper;
        }

        public async Task<RoleDTO> GetById(int id)
        {
            Role role = await _unitOfWork.Roles.GetById(id);
            RoleDTO result = _mapper.Map<RoleDTO>(role);
            return result;
        }

        public async Task<IList<RoleDTO>> GetAll()
        {
            IList<Role> roles = await _unitOfWork.Roles.GetAll();
            var result = _mapper.Map<IList<RoleDTO>>(roles);
            return result;
        }

        public async Task<int> Create(RoleDTO roleDTO)
        {
            int result = await _unitOfWork.Roles.Create(_mapper.Map<Role>(roleDTO));
            _unitOfWork.Commit();
            return result;
        }

        public async Task<int> Update(RoleDTO roleDTO)
        {
            int result = await _unitOfWork.Roles.Update(_mapper.Map<Role>(roleDTO));
            _unitOfWork.Commit();
            return result;
        }

        public async Task<int> DeleteById(int id)
        {
            int result = await _unitOfWork.Roles.Delete(id);
            _unitOfWork.Commit();
            return result;
        }
    }
}
