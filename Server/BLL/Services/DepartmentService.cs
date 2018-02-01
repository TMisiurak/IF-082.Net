using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services

{
    public class DepartmentService : IService<DepartmentDTO>
    {
        IUnitOfWork Database { get; set; }
        IMapper _mapper;

        public DepartmentService(IUnitOfWork uow, IMapper mapper)
        {
            Database = uow;
            _mapper = mapper;
        }

        public async Task<int> Create(DepartmentDTO departmentDTO)
        {
            Task<Clinic> clinic = Database.Clinics.GetById(departmentDTO.ClinicId);

            // валидация
            if (clinic == null)
                throw new ValidationException("the clinic does not exist ");
            Department department = new Department
            {

                Name = departmentDTO.Name,
                ClinicId = departmentDTO.ClinicId
            };

            int result = await Database.Departments.Create(_mapper.Map<Department>(departmentDTO));
            return result;
        }

        public async  Task<int> DeleteById(int id)
        {
            int result = await Database.Departments.Delete(id);
            return result;
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public async Task<List<DepartmentDTO>> GetAll()
        {
            IEnumerable<Department> departments = await Database.Departments.GetAll();
            return _mapper.Map<List<DepartmentDTO>>(departments);
        }

        public  async Task<DepartmentDTO> GetById(int id)
        {
            Department department = await Database.Departments.GetById(id);
            DepartmentDTO result = _mapper.Map<DepartmentDTO>(department);
            return result;
        }

        public async Task<int> Update(DepartmentDTO departmentDTO)
        {
            //int result = await Database.Departments.Update(_mapper.Map<Department>(departmentDTO));
            //return result;
       
            Task<Department> department = Database.Departments.GetById(departmentDTO.Id);

            // валидация
            if (department == null)
                throw new ValidationException("the department does not exist ");
            

            int result = await Database.Departments.Update(_mapper.Map<Department>(departmentDTO));
            return result;
        }
    }
}
