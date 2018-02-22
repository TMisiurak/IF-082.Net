using AutoMapper;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectCore.DTO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class AppointmentController : Controller
    {
        private readonly IMapper _iMapper;
        private readonly IAppointmentService _appointmService;

        public  AppointmentController(IMapper iMapper, IAppointmentService appointmService)
        {
            _iMapper = iMapper;
            _appointmService = appointmService;
        }

        [Authorize(Roles = "admin, patient, doctor, accountant")]
        [HttpGet]
        public async Task<IActionResult> GetAppointments()
        {
            var appointments = await _appointmService.GetAll();
            return Ok(appointments);
            // TODO: respond with 201 created
        }

        [Authorize(Roles = "admin, patient, doctor, accountant")]
        [HttpGet("{id}", Name = "GetAppointment")]
        public async Task<IActionResult> GetAppointmentById(int? id)
        {
            var appointment = await _appointmService.GetById(id.Value);
            return Ok(appointment);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromBody] AppointmentDTO appointemtDTO)
        {
            int result = await _appointmService.Create(appointemtDTO);
            return Ok(result);
        }

        [Authorize(Roles = "admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateAppointment([FromBody] AppointmentDTO appointmentDTO)
        {
            int result = await _appointmService.Update(appointmentDTO);
            if (result > 0)
            {
                return CreatedAtRoute("GetDiagnosis", new { id = appointmentDTO.Id }, appointmentDTO);
            }
            return NotFound();
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int? id)
        {
            int result = await _appointmService.DeleteById(id.Value);
            return Ok(result);
        }
        
    }
}
