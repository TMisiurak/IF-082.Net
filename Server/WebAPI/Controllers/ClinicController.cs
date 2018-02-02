using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ClinicController : Controller
    {
        private readonly IMapper _iMapper;
        private readonly IService<ClinicDTO> _servClinic;

        public ClinicController(IMapper iMapper, IService<ClinicDTO> servClinic)
        {
            _iMapper = iMapper;
            _servClinic = servClinic;
        }

        [Authorize(Roles = "admin, patient, doctor, accountant")]
        [HttpGet]
        public async Task<IActionResult> GetClinics()
        {
            var clinics = await _servClinic.GetAll();
            return Ok(clinics);
        }

        [Authorize(Roles = "admin, patient, doctor, accountant")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClinicById(int? id)
        {
            var clinic = await _servClinic.GetById(id.Value);
            return Ok(clinic);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> CreateClinic([FromBody]ClinicDTO clinicDTO)
        {
            int result = await _servClinic.Create(clinicDTO);
            return Ok(result);
        }

        [Authorize(Roles = "admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateClinicById([FromBody]ClinicDTO clinicDTO)
        {
            int result = await _servClinic.Update(clinicDTO);
            return Ok(result);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClinicById(int? id)
        {
            int result = await _servClinic.DeleteById(id.Value);
            return Ok(result);
        }
    }
}
