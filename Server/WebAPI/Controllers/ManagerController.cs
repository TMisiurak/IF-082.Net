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
        private readonly IService<ProcedureDTO> _servProcedure;
        private readonly IService<DiagnosisDTO> _servDiagnosis;
        private readonly IService<RoomDTO> _servRoom;

        // TODO: update ctor
        public ManagerController(IUserService serv, IMapper iMapper, IService<RoleDTO> servRole, IService<ClinicDTO> servClinic, IService<ProcedureDTO> servProcedure, IService<DiagnosisDTO> servDiagnosis)
        {
            _serv = serv;
            _iMapper = iMapper;
            _servRole = servRole;
            _servClinic = servClinic;
            _servProcedure = servProcedure;
            _servDiagnosis = servDiagnosis;
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

        [HttpPost("create_diagnosis")]
        public async Task<IActionResult> CreateDiagnosis([FromForm] DiagnosisDTO diagnosisDTO)
        {
            int result = await _servDiagnosis.Create(diagnosisDTO);
            return Ok(result);
        }

        [HttpDelete("delete_diagnosis/{id}")]
        public async Task<IActionResult> DeleteDiagnosisById(int? id)
        {
            int result = await _servDiagnosis.DeleteById(id.Value);
            return Ok(result);
        }
    }
}
