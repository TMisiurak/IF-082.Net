using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class InfoController : Controller
    {
        private readonly IMapper _iMapper;
        private readonly IUserService _serv;
        private readonly IService<RoleDTO> _servRole;
        private readonly IService<ClinicDTO> _servClinic;
        private readonly IService<ProcedureDTO> _servProcedure;

        public InfoController(IUserService serv, IMapper iMapper, IService<RoleDTO> servRole, IService<ClinicDTO> servClinic, IService<ProcedureDTO> servProcedure)
        {
            _iMapper = iMapper;
            _servRole = servRole;
            _servClinic = servClinic;
            _servProcedure = servProcedure;
        }

        // GET api/roles
        [Authorize(Roles = "admin")]
        [HttpGet("/all_roles")]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _servRole.GetAll();
            return Ok(roles);
        }

        [Authorize(Roles = "admin")]
        [HttpGet("/all_clinics")]
        public async Task<IActionResult> GetClinics()
        {
            var clinics = await _servClinic.GetAll();
            return Ok(clinics);
        }

        [Authorize(Roles = "admin")]
        [HttpGet("/all_procedures")]
        public async Task<IActionResult> GetProcedures()
        {
            var procedures = await _servProcedure.GetAll();
            return Ok(procedures);
        }

        [Authorize(Roles = "admin, patient, doctor, accountant")]
        [HttpGet("role/{id}")]
        public async Task<IActionResult> GetRoleById(int? id)
        {
            var role = await _servRole.GetById(id.Value);
            return Ok(role);
        }

        [Authorize(Roles = "admin, patient, doctor, accountant")]
        [HttpGet("clinic/{id}")]
        public async Task<IActionResult> GetClinicById(int? id)
        {
            var clinic = await _servClinic.GetById(id.Value);
            return Ok(clinic);
        }

        [Authorize(Roles = "admin, patient, doctor, accountant")]
        [HttpGet("procedure/{id}")]
        public async Task<IActionResult> GetProcedureById(int? id)
        {
            var procedure = await _servProcedure.GetById(id.Value);
            return Ok(procedure);
        }

        protected override void Dispose(bool disposing)
        {
            _serv.Dispose();
            base.Dispose(disposing);
        }
    }
}
