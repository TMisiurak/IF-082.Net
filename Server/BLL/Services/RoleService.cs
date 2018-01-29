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
            throw new NotImplementedException();
        }

        public Task<int> Create(RoleDTO item)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(RoleDTO item)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
