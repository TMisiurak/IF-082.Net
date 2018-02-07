using AutoMapper;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectCore.DTO;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/Prescription")]
    public class PrescriptionController : Controller
    {
        private readonly IMapper _iMapper;
        private readonly IPrescriptionService<PrescriptionDTO> _servPrescription;

        public PrescriptionController(IMapper iMapper, IPrescriptionService<PrescriptionDTO> servPrescription)
        {
            _iMapper = iMapper;
            _servPrescription = servPrescription;
        }

        // GET: api/Prescription
        [Authorize(Roles = "admin, doctor, accountant")]
        [HttpGet]
        public async Task<IActionResult> GetPrescriptions()
        {
            var prescriptions = await _servPrescription.GetAll();
            return Ok(prescriptions);
        }

        // GET: api/Prescription/5
        [Authorize(Roles = "admin, patient, doctor, accountant")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPrescriptionById(int? id)
        {
            var prescription = await _servPrescription.GetById(id.Value);
            return Ok(prescription);
        }

        [Authorize(Roles = "admin, doctor")]
        [HttpPost]
        public async Task<IActionResult> CreatePrescription([FromBody]PrescriptionDTO prescriptionDTO)
        {
            int result = await _servPrescription.Create(prescriptionDTO);
            return Ok(result);
        }

        [Authorize(Roles = "admin, doctor")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrescriptionById(int? id)
        {
            int result = await _servPrescription.DeleteById(id.Value);
            return Ok(result);
        }
    }
}