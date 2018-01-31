using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IMapper _iMapper;
        private readonly IUserService _serv;
        private readonly IService<RoleDTO> _servRole;
        private readonly IService<DepartmentDTO> _servDepartment;

        //private readonly IService<ClinicDTO> _servClinic;

        public ValuesController(IUserService serv, IMapper iMapper, IService<RoleDTO> servRole,  
            IService<DepartmentDTO> servDepartment /*, IService<ClinicDTO> servClinic*/)
        {
            _serv = serv;
            _iMapper = iMapper;
            _servRole = servRole;
            _servDepartment = servDepartment;
            //_servClinic = servClinic;
        }

        // GET api/users
        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _serv.GetAll();
            return Ok(users);
        }

        // GET api/roles
        [Authorize(Roles = "admin")]
        [HttpGet("/all_roles")]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _servRole.GetAll();
            return Ok(roles);
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

        //// GET api/roles
        //[Authorize(Roles = "admin")]
        //[HttpGet("/all_clinics")]
        //public async Task<IActionResult> GetClinics()
        //{
        //    var clinics = await _servClinic.GetAll();
        //    return Ok(clinics);
        //}

        // GET api/values/5
        [Authorize(Roles = "admin, patient, doctor, accountant")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int? id)
        {
            var user = await _serv.GetById(id.Value);
            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            _serv.Dispose();
            _servDepartment.Dispose();
            base.Dispose(disposing);
        }
    }
}
