using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class RoleService : IRoleService
    {
        IUnitOfWork DataBase { get; set; }
        IMapper _mapper;
        public RoleService(IUnitOfWork uow, IMapper mapper)
        {
            DataBase = uow;
            _mapper = mapper;
        }

        public void CreateRole(RoleDTO roleDTO)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public string GetRoleById(int? id)
        {
            //RoleDTO role = DataBase.Role.Get(id.Value);
            return "admin";
        }
    }
}
