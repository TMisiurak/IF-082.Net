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
        
        [Authorize(Roles = "admin, patient, doctor, accountant")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetScheduleById(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            IList<ScheduleAppointmentDTO> schedule = await _scheduleService.GetByDoctorId(id.Value);
            if (schedule != null && schedule.Count != 0)
            {
                return Ok(schedule);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
