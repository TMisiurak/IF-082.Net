using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectCore.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ScheduleController : Controller
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }
        
        [Authorize(Roles = "admin, patient, doctor")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            IList<FreeTimeSlotsDTO> freeTimeSlots = await _scheduleService.GetByDoctorId(id.Value);
            if (freeTimeSlots != null && freeTimeSlots.Count != 0)
            {
                return Ok(freeTimeSlots);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
