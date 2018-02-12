using AutoMapper;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectCore.DTO;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class PrescriptionListController : Controller
    {
        private readonly IMapper _iMapper;
        private readonly IPrescriptionListService _servPrescriptionList;

        public PrescriptionListController(IMapper iMapper, IPrescriptionListService servPrescriptionList)
        {
            _iMapper = iMapper;
            _servPrescriptionList = servPrescriptionList;
        }

        // GET: api/PrescriptionList
        [Authorize(Roles = "admin, doctor, accountant")]
        [HttpGet]
        public async Task<IActionResult> GetPrescriptionLists()
        {
            var prescriptionLists = await _servPrescriptionList.GetAll();
            return Ok(prescriptionLists);
        }

        // GET: api/PrescriptionList/5
        [Authorize(Roles = "admin, patient, doctor, accountant")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPrescriptionListById(int? id)
        {
            var prescriptionList = await _servPrescriptionList.GetById(id.Value);
            return Ok(prescriptionList);
        }

        [Authorize(Roles = "admin, doctor")]
        [HttpPost]
        public async Task<IActionResult> CreatePrescriptionList([FromBody]PrescriptionListDTO prescriptionListDTO)
        {
            int result = await _servPrescriptionList.Create(prescriptionListDTO);
            return Ok(result);
        }

        [Authorize(Roles = "admin, doctor")]
        [HttpPut]
        public async Task<IActionResult> UpdatePrescriptionList([FromBody]PrescriptionListDTO prescriptionListDTO)
        {
            int result = await _servPrescriptionList.Update(prescriptionListDTO);
            return Ok(result);
        }

        [Authorize(Roles = "admin, doctor")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrescriptionListById(int? id)
        {
            int result = await _servPrescriptionList.DeleteById(id.Value);
            return Ok(result);
        }
    }
}
