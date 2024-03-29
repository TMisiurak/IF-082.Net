﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using DAL.Interfaces;
using ProjectCore.DTO;
using ProjectCore.Entities;

namespace BLL.Services

{
    public class DepartmentService : IDepartmentService
    {
        IUnitOfWork _unitOfWork { get; set; }
        IMapper _mapper;

        public DepartmentService(IUnitOfWork uow, IMapper mapper)
        {
            _unitOfWork = uow;
            _mapper = mapper;
        }

        public async Task<int> Create(DepartmentDTO departmentDTO)
        {
            int result = await _unitOfWork.Departments.Create(_mapper.Map<Department>(departmentDTO));
            _unitOfWork.Commit();
            return result;
        }


        public async  Task<int> DeleteById(int id)
        {
            int result = await _unitOfWork.Departments.Delete(id);
            _unitOfWork.Commit();
            return result;
        }

        public async Task<IList<DepartmentDTO>> GetAll()
        {
            IEnumerable<Department> departments = await _unitOfWork.Departments.GetAll();
            return _mapper.Map<IList<DepartmentDTO>>(departments);
        }

        public  async Task<DepartmentDTO> GetById(int id)
        {
            Department department = await _unitOfWork.Departments.GetById(id);
            DepartmentDTO result = _mapper.Map<DepartmentDTO>(department);
            return result;
        }

        public async Task<int> Update(DepartmentDTO departmentDTO)
        {
            ////int result = await Database.Departments.Update(_mapper.Map<Department>(departmentDTO));
            ////return result;
       
            //var department = Database.Departments.GetById(departmentDTO.Id);

            //// валидация
            //if (department == null)
            //    throw new ValidationException("the department does not exist ");
            

            int result = await _unitOfWork.Departments.Update(_mapper.Map<Department>(departmentDTO));
            _unitOfWork.Commit();
            return result;
        }
    }
}
