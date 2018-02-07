using AutoMapper;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectCore.DTO;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class DiagnosisController : Controller
    {
        private readonly IMapper _iMapper;
        private readonly IDiagnosisService _servDiagnosis;

        public DiagnosisController(IMapper iMapper, IDiagnosisService servDiagnosis)
        {
            _iMapper = iMapper;
            _servDiagnosis = servDiagnosis;
        }

        [Authorize(Roles = "admin, patient, doctor, accountant")]
        [HttpGet]
        public async Task<IActionResult> GetDiagnoses()
        {
            var diagnoses = await _servDiagnosis.GetAll();
            return Ok(diagnoses);
        }

        [Authorize(Roles = "admin, patient, doctor, accountant")]
        [HttpGet("{id}", Name = "GetDiagnosis")]
        public async Task<IActionResult> GetDiagnosisById(int? id)
        {
            var diagnosis = await _servDiagnosis.GetById(id.Value);
            return Ok(diagnosis);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> CreateDiagnosis([FromForm] DiagnosisDTO diagnosisDTO)
        {
            int result = await _servDiagnosis.Create(diagnosisDTO);
            return Ok(result);
        }

        [Authorize(Roles = "admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateDiagnosis([FromBody] DiagnosisDTO diagnosisDTO)
        {
            int result = await _servDiagnosis.Update(diagnosisDTO);
            if (result > 0)
            {
                return CreatedAtRoute("GetDiagnosis", new { id = diagnosisDTO.Id }, diagnosisDTO);
            }
            return NotFound();
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiagnosisById(int? id)
        {
            int result = await _servDiagnosis.DeleteById(id.Value);
            return Ok(result);
        }
    }
}
