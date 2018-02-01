using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProcedureController : Controller
    {
        private readonly IMapper _iMapper;
        private readonly IService<ProcedureDTO> _servProcedure;

        public ProcedureController(IMapper iMapper, IService<ProcedureDTO> servProcedure)
        {
            _iMapper = iMapper;
            _servProcedure = servProcedure;
        }

        [Authorize(Roles = "admin, patient, doctor, accountant")]
        [HttpGet]
        public async Task<IActionResult> GetProcedures()
        {
            var procedures = await _servProcedure.GetAll();
            return Ok(procedures);
        }

        [Authorize(Roles = "admin, patient, doctor, accountant")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProcedureById(int? id)
        {
            var procedure = await _servProcedure.GetById(id.Value);
            return Ok(procedure);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> CreateProcedure([FromBody]ProcedureDTO procedureDTO)
        {
            int result = await _servProcedure.Create(procedureDTO);
            return Ok(result);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProcedureById(int? id)
        {
            int result = await _servProcedure.DeleteById(id.Value);
            return Ok(result);
        }
    }
}
