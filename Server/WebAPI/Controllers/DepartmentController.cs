using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class DepartmentController : Controller
    {
        private readonly IMapper _iMapper;

        private readonly IService<DepartmentDTO> _servDepartment;

        public DepartmentController(IMapper iMapper, IService<DepartmentDTO> servDepartment)
        {
            _iMapper = iMapper;
            _servDepartment = servDepartment;
        }


        //// UPDATE api/values/5
        //[HttpPut("update")]
        //public async Task<IActionResult> UpdateDepartmentById([FromBody]DepartmentDTO departmentDTO)
        //{
        //    //userDTO.Password = HashService.HashPassword(userDTO.Password);
        //    int result = await _servDepartment.Update(departmentDTO);
        //    return Ok(result);
        //}

        [HttpPost("create_department")]
        public async Task<IActionResult> CreateDepartment([FromBody]DepartmentDTO departmentDTO)
        {
            int result = await _servDepartment.Create(departmentDTO);
            return Ok(result);
        }

        [HttpDelete("delete_department/{id}")]
        public async Task<IActionResult> DeleteDepartmentById(int? id)
        {

            int result = await _servDepartment.DeleteById(id.Value);
            // return RedirectToAction(nameof(Index));
            return Ok(result);

        }


        //Get  api/departments
        [HttpGet("/all_departments")]
        public async Task<IActionResult> GetDepartments()
        {
            var departments = await _servDepartment.GetAll();
            return Ok(departments);
        }

        //GET api/
        [HttpGet("/department/{id}")]
        public async Task<IActionResult> GetDepartmentById(int? id)
        {
            var department = await _servDepartment.GetById(id.Value);
            return Ok(department);
        }






    }
}
