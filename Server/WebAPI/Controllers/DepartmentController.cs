using AutoMapper;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectCore.DTO;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class DepartmentController : Controller
    {
        //private readonly IMapper _iMapper;

        private readonly IDepartmentService _servDepartment;

        public DepartmentController(IMapper iMapper, IDepartmentService servDepartment)
        {
          //_iMapper = iMapper;
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
            if (departmentDTO == null)
            {
                return BadRequest();
            }
            int result = await _servDepartment.Create(departmentDTO);
            if (result >= 0)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }



        [Authorize(Roles = "admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateDepartmnetById([FromBody]DepartmentDTO departmentDTO)
        {
       

            if (departmentDTO == null )
            {
                return BadRequest();
            }

            int result = await _servDepartment.Update(departmentDTO);
            if (result >= 0)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }



        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartmentById(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            int result = await _servDepartment.DeleteById(id.Value);
            // return RedirectToAction(nameof(Index));
            if (result == 0)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }

        }


       






    }
}
