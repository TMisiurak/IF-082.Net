using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Helpers;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class DrugController : Controller
    {
        private readonly IMapper _iMapper;
        private readonly IService<DrugDTO> _drugService;

        public DrugController(IService<DrugDTO> drugService, IMapper iMapper)
        {
            _drugService = drugService;
            _iMapper = iMapper;
        }

        //[Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> CreateDrug([FromBody]DrugDTO drugDTO)
        {
            if (drugDTO == null)
            {
                return BadRequest();
            }

            int result = await _drugService.Create(drugDTO);
            if (result > 0)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        //[Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> GetDrugs()
        {
            var drugs = await _drugService.GetAll();
            if (drugs != null)
            {
                return Ok(drugs);
            }
            else
            {
                return NotFound();
            }
        }
        
        //[Authorize(Roles = "admin, patient, doctor, accountant")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            var drug = await _drugService.GetById(id.Value);
            if (drug != null)
            {
                return Ok(drug);
            }
            else
            {
                return NotFound();
            }
        }

        //[Authorize(Roles = "admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateDrugById([FromBody]DrugDTO drugDTO)
        {
            if (drugDTO == null)
            {
                return BadRequest();
            }
            
            int result = await _drugService.Update(drugDTO);
            if (result > 0)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        //[Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDrugById(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            int result = await _drugService.DeleteById(id.Value);
            if (result > 0)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        protected override void Dispose(bool disposing)
        {
            _drugService.Dispose();
            base.Dispose(disposing);
        }
    }
}
