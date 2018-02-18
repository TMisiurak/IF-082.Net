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
        private readonly IUnitOfWork DataBase;
        private readonly IMapper _mapper;

        public RoleService(IUnitOfWork uow, IMapper mapper)
        {
            DataBase = uow;
            _mapper = mapper;
        }

        public async Task<RoleDTO> GetById(int id)
        {
            Role role = await DataBase.Roles.GetById(id);
            RoleDTO result = _mapper.Map<RoleDTO>(role);
            return result;
        }

        public async Task<IList<RoleDTO>> GetAll()
        {
            IList<Role> roles = await DataBase.Roles.GetAll();
            var result = _mapper.Map<IList<RoleDTO>>(roles);
            return result;
        }

        public async Task<int> Create(RoleDTO roleDTO)
        {
            int result = await DataBase.Roles.Create(_mapper.Map<Role>(roleDTO));
            DataBase.Commit(result);
            return result;
        }

        public async Task<int> Update(RoleDTO roleDTO)
        {
            int result = await DataBase.Roles.Update(_mapper.Map<Role>(roleDTO));
            DataBase.Commit(result);
            return result;
        }

        public async Task<int> DeleteById(int id)
        {
            int result = await DataBase.Roles.Delete(id);
            DataBase.Commit(result);
            return result;
        }
    }
}
