using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        public ManagerController(IUserService serv, IMapper iMapper, IService<RoleDTO> servRole, IService<ClinicDTO> servClinic)
        {
            _serv = serv;
            _iMapper = iMapper;
            _servRole = servRole;
            _servClinic = servClinic;
        }

        [HttpPost("create_role")]
        public async Task<IActionResult> CreateRole([FromBody]RoleDTO roleDTO)
        {
            int result = await _servRole.CreateAsync(roleDTO);
            return Ok(result);
        }

        [HttpDelete("delete_role/{id}")]
        public async Task<IActionResult> DeleteRoleById(int? id)
        {
            int result = await _servRole.DeleteByIdAsync(id.Value);
            return Ok(result);
        }

        [HttpPost("create_clinic")]
        public async Task<IActionResult> CreateClinic([FromBody]ClinicDTO clinicDTO)
        {
            int result = await _servClinic.CreateAsync(clinicDTO);
            return Ok(result);
        }

        [HttpDelete("delete_clinic/{id}")]
        public async Task<IActionResult> DeleteClinicById(int? id)
        {
            int result = await _servClinic.DeleteByIdAsync(id.Value);
            return Ok(result);
        }
    }
}
