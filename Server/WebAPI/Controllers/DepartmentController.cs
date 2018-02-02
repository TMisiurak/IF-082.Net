using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
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

        //Get  api/departments
        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            var departments = await _servDepartment.GetAll();
            return Ok(departments);
        }

        //GET api/
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentById(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            var department = await _servDepartment.GetById(id.Value);
            if (department != null)
            { return Ok(department); }
            else
            { return NotFound(); }
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody]DepartmentDTO departmentDTO)
        {
            int result = await _servDepartment.Create(departmentDTO);
            return Ok();
        }
        


        ////[Authorize(Roles = "admin, patient, doctor, accountant")]
        [HttpPut("{id}")]
        //public async Task<IActionResult> UpdateDepartment([FromBody]DepartmentDTO departmentDTO)
        //{
        //    if (departmentDTO == null )
        //    {
        //        return BadRequest();
        //    }

        //    int result = await _servDepartment.Update(departmentDTO);
        //    if (result > 0)
        //    {
        //        return Ok();
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}
        public async Task<IActionResult> UpdateDepartmentById([FromBody]DepartmentDTO departmentDTO)
        {

            int result = await _servDepartment.Update(departmentDTO);

            return Ok(result);

        }



        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartmentById(int? id)
        {

            int result = await _servDepartment.DeleteById(id.Value);
            // return RedirectToAction(nameof(Index));
            return Ok(result);

        }


       






    }
}
