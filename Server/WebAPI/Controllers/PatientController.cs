using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjectCore.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class PatientController : Controller
    {

        private readonly IPatientService _servPatient;

        public PatientController(IPatientService servPatient)
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

        [HttpGet("{fullName}")]
        public async Task<IActionResult> Get(string fullName)
        {
            var patient = await _servPatient.SearchPatient(fullName);
            return Ok(patient);
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
