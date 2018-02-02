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
    public class RoleService : IService<RoleDTO>
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

        public async Task<List<RoleDTO>> GetAll()
        {
            List<Role> roles = await DataBase.Roles.GetAll();
            var result = _mapper.Map<List<RoleDTO>>(roles);
            return result;
        }

        public async Task<int> Create(RoleDTO roleDTO)
        {
            int result = await DataBase.Roles.Create(_mapper.Map<Role>(roleDTO));
            return result;
        }

        public async Task<int> Update(RoleDTO roleDTO)
        {
            int result = await DataBase.Roles.Update(_mapper.Map<Role>(roleDTO));
            return result;
        }

        public async Task<int> DeleteById(int id)
        {
            int result = await DataBase.Roles.Delete(id);
            return result;
        }
    }
}
