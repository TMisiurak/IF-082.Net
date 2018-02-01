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
        private readonly IService<ProcedureDTO> _servProcedure;

        public ManagerController(IUserService serv, IMapper iMapper, IService<RoleDTO> servRole, IService<ClinicDTO> servClinic, IService<ProcedureDTO> servProcedure)
        {
            _serv = serv;
            _iMapper = iMapper;
            _servRole = servRole;
            _servClinic = servClinic;
            _servProcedure = servProcedure;
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

        [HttpPost("create_procedure")]
        public async Task<IActionResult> CreateProcedure([FromBody]ProcedureDTO procedureDTO)
        {
            int result = await _servProcedure.Create(procedureDTO);
            return Ok(result);
        }

        [HttpDelete("delete_procedure/{id}")]
        public async Task<IActionResult> DeleteProcedureById(int? id)
        {
            int result = await _servProcedure.DeleteById(id.Value);
            return Ok(result);
        }
    }
}
