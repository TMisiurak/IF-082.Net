using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebAPI.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    public class ManagerController : Controller
    {
        private readonly IMapper _iMapper;
        private readonly IUserService _serv;
        private readonly IService<RoleDTO> _servRole;
        private readonly IService<ClinicDTO> _servClinic;
        private readonly IService<DepartmentDTO> _servDepartment;

        public ManagerController(IUserService serv, IMapper iMapper, IService<RoleDTO> servRole, IService<ClinicDTO> servClinic, IService<DepartmentDTO> servDepartment)
        {
            _serv = serv;
            _iMapper = iMapper;
            _servRole = servRole;
            _servClinic = servClinic;
            _servDepartment = servDepartment;
        }

        [HttpPost("create_role")]
        public async Task<IActionResult> CreateRole([FromBody]RoleDTO roleDTO)
        {
            int result = await _servRole.Create(roleDTO);
            return Ok(result);
        }

        [HttpDelete("delete_role/{id}")]
        public async Task<IActionResult> DeleteRoleById(int? id)
        {
            int result = await _servRole.DeleteById(id.Value);
            return Ok(result);
        }

        [HttpPost("create_clinic")]
        public async Task<IActionResult> CreateClinic([FromBody]ClinicDTO clinicDTO)
        {
            int result = await _servClinic.Create(clinicDTO);
            return Ok(result);
        }

        [HttpDelete("delete_clinic/{id}")]
        public async Task<IActionResult> DeleteClinicById(int? id)
        {
            int result = await _servClinic.DeleteById(id.Value);
            return Ok(result);
        }
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

    }
}
