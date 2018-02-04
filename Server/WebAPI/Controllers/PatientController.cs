using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class PatientController : Controller
    {

        private readonly IService<PatientDTO> _servPatient;

        public PatientController(IService<PatientDTO> servPatient)
        {
            _servPatient = servPatient;
        }

        //Get  api/departments
        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {
            var patients = await _servPatient.GetAll();
            return Ok(patients);
        }

        //GET api/
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientById(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            var patient = await _servPatient.GetById(id.Value);
            if (patient != null)
            { return Ok(patient); }
            else
            { return NotFound(); }
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> CreatePatient([FromBody]PatientDTO patientDTO)
        {
            if (patientDTO == null)
            {
                return BadRequest();
            }
            int result = await _servPatient.Create(patientDTO);
            if (result > 0)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }



        [Authorize(Roles = "admin")]
        [HttpPut]
        public async Task<IActionResult> UpdatePatientById([FromBody]PatientDTO patientDTO)
        {


            if (patientDTO == null)
            {
                return BadRequest();
            }

            int result = await _servPatient.Update(patientDTO);
            if (result > 0)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }



        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatientById(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            int result = await _servPatient.DeleteById(id.Value);
            // return RedirectToAction(nameof(Index));
            if (result == 0)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }

        }









    }
}
