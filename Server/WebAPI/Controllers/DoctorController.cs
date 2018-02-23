using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ProjectCore.DTO;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService servDoctor)
        {
            _doctorService = servDoctor;
        }

        //[Authorize(Roles = "admin, patient, doctor, accountant")]
        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            var doctors = await _doctorService.GetAll();
            return Ok(doctors);
        }

        [HttpGet("{fullName}")]
        public async Task<IActionResult> Get(string fullName)
        {
            var doctor = await _doctorService.SearchDotor(fullName);
            return Ok(doctor);
        }

        //[Authorize(Roles = "admin, patient, doctor, accountant")]
        [HttpPost]
        public async Task<IActionResult> CreateDoctor([FromBody] DoctorDTO doctorDTO)
        {
            if (doctorDTO == null)
            {
                return BadRequest();
            }

            int result = await _doctorService.Create(doctorDTO);
            if (result > 0)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        //[Authorize(Roles = "admin, patient, doctor, accountant")]
        [HttpPut]
        public async Task<IActionResult> UpdateDoctorById([FromBody]DoctorDTO doctorDTO)
        {
            if (doctorDTO == null)
            {
                return BadRequest();
            }

            int result = await _doctorService.Update(doctorDTO);
            if (result > 0)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        //[Authorize(Roles = "admin, patient, doctor, accountant")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctorById(int? id)
        {
            int result = await _doctorService.DeleteById(id.Value);
            return Ok(result);
        }
    }
}